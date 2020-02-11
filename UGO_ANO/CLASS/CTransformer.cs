using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGO_ANO.CLASS
{
    public static class CTransformer
    {

        private static Random random = new Random();

        public static String TInt(this String str)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, str.Length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static String TBolo(this String str)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, str.Length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //Génération d'une date aléatoire entre datemini et aujourdhui
        public static DateTime TDate()
        { 
            DateTime datemini = new DateTime(1950, 1, 1);
            int range = (DateTime.Today - datemini).Days;
            return datemini.AddDays(random.Next(range));
        }


        public static DateTime TDateNaissance(this DateTime date)
        {

            DateTime datemini = date.AddDays(-60);
            int range = (date.AddDays(120) - datemini).Days;
            return datemini.AddDays(random.Next(range));
        }


    }
}
