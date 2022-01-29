using System;
using System.Linq;

namespace AnalyseMeAPI.Helpers {
    public class ResultsHelper {

        private static Random random = new Random();

        public static string CreateID(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}