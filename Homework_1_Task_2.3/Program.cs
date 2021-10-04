using System;

namespace Homework_1_Task_2._3
{
    class Program
    {
        static DateTime ReadTime()
        {
            string[] formats = { "dd.MM.yyyy HH:mm" };
            DateTime parsedDate;
            do
            {
                Console.WriteLine("Введите время и дату события в формате dd.MM.yyyy HH:mm");
            } while (!DateTime.TryParseExact(Console.ReadLine(), formats, null,

                               System.Globalization.DateTimeStyles.AllowWhiteSpaces |
                               System.Globalization.DateTimeStyles.AdjustToUniversal,
                               out parsedDate));
            return parsedDate;
        }
        static void ParseMinutes(int mins, out int days, out int hours, out int minutes)
        {
            days = mins / (24 * 60);
            hours = (mins / 60) % 24;
            minutes = mins % 60;
        }
        static string MinsToStr(int mins)
        {
            if (mins <= 0)
            {
                return "Уже началось!";
            }
            int days;
            int hours;
            int minutes;

            ParseMinutes(mins, out days, out hours, out minutes);

            string answer = "До события соталось ";
            if (days > 0)
            {
                answer += days + " " + GetTextForTime(days, "день", "дня", "дней");
                if (hours > 0 || minutes > 0)
                {
                    answer += ", ";
                }
            }
            if (hours > 0)
            {
                answer += hours + " " + GetTextForTime(hours, "час", "часа", "часов");
                if (minutes > 0)
                {
                    answer += ", ";
                }
            }
            if (minutes > 0)
            {
                answer += minutes + " " + GetTextForTime(minutes, "минута", "минуты", "минут");
            }
            answer += "!";
            return answer;

        }
        static void Main(string[] args)
        {
            int mins;
            DateTime eventData;
            if (args.Length == 2)
            {
                DateTime date;
                DateTime time;
                if (DateTime.TryParse(args[0], out date) && DateTime.TryParse(args[1], out time))
                {
                    eventData = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                    mins = (int)Math.Round((eventData - DateTime.Now).TotalMinutes, 0);
                }
                else
                    eventData = ReadTime();

            }
            else
                eventData = ReadTime();

            mins = (int)Math.Round((eventData - DateTime.Now).TotalMinutes, 0);

            Console.WriteLine(MinsToStr(mins));
        }


        static string GetTextForTime(int num, string f_arg, string s_arg, string t_arg)
        {
            int secondDigit = num % 100 / 10;

            if (secondDigit == 1)
            {
                return t_arg;
            }

            switch (num % 10)
            {
                case 1:
                    return f_arg;
                case 2:
                case 3:
                case 4:
                    return s_arg;
                default:
                    return t_arg;
            }

        }

    }
}