using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvemERP.BasePage
{
    public class BasePage
    {
        protected Dsl dsl;
        private static Random _random;
        private static readonly object SyncObj = new object();

        public BasePage()
        {
            dsl = new Dsl();
        }


        private static string GenerateRandomNumber()
        {
            lock (SyncObj)
            {
                if (_random == null)
                    _random = new Random(); // Or exception...
                return _random.Next(100000000, 999999999).ToString();
            }
        }
        public static string NewCpf()

        {
            var sum = 0;
            var rest = 0;
            var multiplier1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplier2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var seed = GenerateRandomNumber();

            for (var i = 0; i < 9; i++)
                sum += int.Parse(seed[i].ToString()) * multiplier1[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            seed += rest;
            sum = 0;

            for (var i = 0; i < 10; i++)
                sum += int.Parse(seed[i].ToString()) * multiplier2[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            seed += rest;

            return seed;
        }
    }
}
