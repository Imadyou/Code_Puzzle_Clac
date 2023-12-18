using System;
using System.Collections.Generic;
using System.Linq;

namespace Calibration_Document_calculator.Data
{
    public class CalibrationService
    {
        public int CalculateCombinedFirstLastDigitsSum(string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
            {
                return 0;
            }

            List<int> combinedDigitsList = new List<int>();

            string[] separators = { "\r\n", "\r", "\n" };
            string[] lines = inputText.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                List<char> digits = new List<char>();

                foreach (char c in line)
                {
                    if (char.IsDigit(c))
                    {
                        digits.Add(c);
                    }
                }

                if (digits.Any())
                {
                    int firstDigit = int.Parse(digits.First().ToString());
                    int lastDigit = int.Parse(digits.Last().ToString());
                    int combinedDigits = int.Parse($"{firstDigit}{lastDigit}");
                    combinedDigitsList.Add(combinedDigits);
                }
            }

            int sum = combinedDigitsList.Sum();
            return sum;
        }
    }
}
