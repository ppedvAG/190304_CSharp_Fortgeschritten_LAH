using Domain;
using System;
using System.Text.RegularExpressions;

namespace Logik
{
    public class RegexParser : IParser
    {
        public Formel Parse(string input)
        {
            Regex regex = new Regex(@"(\d+)\s*(\D)\s*(\d+)");
            var result = regex.Match(input);
            if (result.Success)
            {
                int op1 = Convert.ToInt32(result.Groups[1].Value);
                string op = result.Groups[2].Value;
                int op2 = Convert.ToInt32(result.Groups[3].Value);

                return new Formel(op1, op2, op);
            }
            throw new FormatException("Ungültiges Formelformat");
        }
    }
}
