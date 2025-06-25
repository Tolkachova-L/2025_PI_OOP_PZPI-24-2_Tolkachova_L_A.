using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json.Serialization;

namespace ConsoleApp3
{
    internal static class Helpers
    {
        public static bool TryReadDate(ref string error, out DateTime date)
        {
            bool IsValid;
            string format = "yyyy-MM-dd";
            var noteManager = new NoteManager();

            Console.WriteLine("Введiть дату та час у форматi: рiк-мiсяць-день");
            Console.WriteLine("Приклад: 2026-01-11");

            PrintErrorIfNeeded(error);

            string input = Console.ReadLine();

            if (input == "CANCEL")
            {
                error = "CANCEL";
                date = DateTime.MinValue;
                return false;
            }
            else IsValid = DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (!IsValid)
            {
                error = "ПОМИЛКА\n" +
                    "Введiть дату вiдповiдно до формату\n" +
                    "Повторiть спробу";
                return false;
            }
            else if (!noteManager.ValidateStartTime(date))
            {
                error = "ПОМИЛКА\n" +
                    "Невiрно введена дата\n" +
                    "Виберiть iншу дату\n" +
                    "Повторiть спробу";
                return false;
            }
            error = null;
            return true;
        }

        public static bool TryReadDateTime(ref string error, out DateTime date)
        {
            bool IsValid;
            string format = "yyyy-MM-dd HH:mm";
            var noteManager = new NoteManager();

            Console.WriteLine("Введiть дату та час у форматi: рiк-мiсяць-день година:хвилини");
            Console.WriteLine("Приклад: 2026-01-11 09:11");

            PrintErrorIfNeeded(error);

            string input = Console.ReadLine();

            if (input == "CANCEL")
            {
                error = "CANCEL";
                date = DateTime.MinValue;
                return false;
            }
            else IsValid = DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (!IsValid)
            {
                error = "ПОМИЛКА\n" +
                    "Введiть дату вiдповiдно до формату\n" +
                    "Повторiть спробу";
                return false;
            }
            else if (!noteManager.ValidateStartTime(date))
            {
                error = "ПОМИЛКА\n" +
                    "Невiрно введенi дата або час\n" +
                    "Виберiть iншу дату\n" +
                    "Повторiть спробу";
                return false;
            }
            error = null;
            return true;
        }

        public static void PrintErrorIfNeeded(string error)
        {
            if (error != null && error.Length != 0)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(error);
                Console.ResetColor();
            }
        }
    }
}
