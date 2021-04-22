using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLog;

using static System.Console;

using SixthTask.Controllers;
using SixthTask.Views;
using SixthTask.Logic.Components.Builders;
using SixthTask.Logic.UserInterface.Abstracts;
using LibToTasks.Validation.Interfaces;
using LibToTasks.Builders;

namespace SixthTask
{
    public class Startup
    {
        public const int TICKET_MAX_VALUE = 1000000;
        public const int TICKET_MIN_VALUE = 0;
        public const int TICKET_MAX_SIZE = 6;

        private readonly IValidator _validator;
        private readonly ITransformator _transformator;
        private readonly ILogger _logger;

        public Startup() 
        {
            _validator = new DefaultValidatorBuilder().Create();
            _transformator = new DefaultTransformatorBuilder().Create();

            _logger = LogManager.GetCurrentClassLogger();
        }

        public void Start(string[] mainArguments) 
        {
            if ((mainArguments.Length != 3) 
                || !uint.TryParse(mainArguments[0], out _)
                || !uint.TryParse(mainArguments[1], out _)
                || !uint.TryParse(mainArguments[2], out _)) 
            {
                WriteLine("You must enter three values: [min_ticket_value] [max_ticket_value] [ticket_size]\n" +
                    "And all of these have ot be uint");

                return;
            }

            try
            {
                string luckyTicketType = GetLuckyTicketType();
                int minTicketValue = GetMaxOrMinValue(mainArguments[0]);
                int maxTicketValue = GetMaxOrMinValue(mainArguments[1]);
                int ticketSize = _transformator.ConfirmConversion<int, string>(mainArguments[2]) > TICKET_MAX_SIZE
                    ? _transformator.ConfirmConversion<int, string>(mainArguments[2]) : TICKET_MAX_SIZE;

                Controller ticketController = GetController(maxTicketValue, minTicketValue, ticketSize, luckyTicketType);

                ticketController.SetModel();

                ticketController.Display();
            }
            catch (Exception ex)
            {
                WriteLine("You must enter three values: [min_ticket_value] [max_ticket_value] [ticket_size]\n" +
                    "And all of these have ot be uint");

                _logger.Error("You must enter three values: [min_ticket_value] [max_ticket_value] [ticket_size]\n" +
                    "And all of these have ot be uint\n" + 
                    "{0}: {1}", ex, ex.Message);
            }

            _logger.Info("Progrem is finalized");
        }

        private Controller GetController(int maxTicketValue, int minTicketValue, int ticketSize, string luckyTicketType) 
        {
            return new LuckyTicketController(
                viewToDisplay: new LuckyTicketView(),
                ticketCreater: new TicketBuidler(minTicketValue, maxTicketValue, ticketSize),
                luckyTicketCreater: new LuckyTicketBuilder(luckyTicketType));
        }

        private int GetMaxOrMinValue(string valueToCheckAndConvert) 
        {
            int convertingValue = _transformator.ConfirmConversion<int, string>(valueToCheckAndConvert);

            if (!CheckMaxOrMinValue(convertingValue))
            {
                throw new FormatException("You must enter three values: [min_ticket_value] [max_ticket_value] [ticket_size]\n" +
                    "And all of these have ot be uint");
            }

            return convertingValue;
        }

        private bool CheckMaxOrMinValue(int valueToCheck) 
        {
            return _validator.CheckValue(convertValue =>
            {
                if (TICKET_MAX_VALUE < valueToCheck || valueToCheck < TICKET_MIN_VALUE)
                {
                    return false;
                }

                return true;
            }, valueToCheck, false);
        }

        private string GetLuckyTicketType() 
        {
            return File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "LuckyTicketType.txt"));
        }
    }
}
