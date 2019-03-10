using System;
using System.Collections.Generic;
using System.Linq;

namespace Visma.Models
{
    public class BankAccount : IBankAccount
    {
        private string shortAccountNumber;
        private List<int> bankCodes = new List<int>() { 1, 2, 31, 33, 34, 36, 37, 38, 39, 4, 5, 6, 8 };
        private List<int> sevenDigitPartBankCodes = new List<int>() { 4, 5 };
        public BankAccount(string number)
        {
            shortAccountNumber = number.Trim();
        }

        public string GetLongFormat()
        {
            this.ValidateInput();
            var parts = this.ConvertShortNumberToIntParts();
            var longNumber = this.BringLengthToElectronicFormat(parts[0], parts[1]);
            
            if(!IsCheckDigitCorrect(longNumber)) {
                this.Error("Incorrect check digit");
            }

            return longNumber;
        }

        private void ValidateInput()
        {
            if(this.shortAccountNumber == null) {
                this.Error("Given input is empty");
            }

            if (!this.shortAccountNumber.Contains("-"))
            {
                this.Error("Wrong input format: no hyphen");
            }
        }

        private List<int> ConvertShortNumberToIntParts()
        {
            var parts = this.shortAccountNumber.Split("-");
            if (parts.Length != 2)
            {
                this.Error("Wrong input format: incorrect number parts count");
            }
            int part1;
            int part2;

            if (!int.TryParse(parts[0], out part1))
            {
                this.Error("Wrong input format: first part is not correct int");
            }

            if (!int.TryParse(parts[1], out part2))
            {
                this.Error("Wrong input format: second part is not correct int");
            }

            return new List<int>() { part1, part2 };
        }

        private string BringLengthToElectronicFormat(int part1, int part2)
        {
            var result = part1.ToString();
            var part2string = part2.ToString();
            var singleDigitBankCode = (int)Math.Floor((double)part1 / 100000);
            if (sevenDigitPartBankCodes.Contains(singleDigitBankCode))
            {
                result += part2string[0];
                part2string = part2string.Substring(1, part2string.Length - 1);
                for (var i = 0; i < 7 - part2string.Length; i++)
                {
                    result += "0";
                }
            }
            else
            {
                for (var i = 0; i < 8 - part2string.Length; i++)
                {
                    result += "0";
                }
            }
            result += part2string;

            return result;
        }

        private bool IsCheckDigitCorrect(string longNumber)
        {
            if (longNumber.Length != 14)
            {
                this.Error("Check digit validation error: account number incorrect");
            }

            var basic = longNumber.Substring(0, 13);
            var checkDigit = longNumber.Substring(13, 1);
            return CalculateCheckDigit(basic).ToString() == checkDigit;
        }

        public bool IsCheckDigitCorrect() {
            var longFormat = this.GetLongFormat();
            return IsCheckDigitCorrect(longFormat);
        }

        private int CalculateCheckDigit(string basic)
        {
            var digits = new Dictionary<int, List<int>>();
            
            for (var i = 12; i >= 0; i--)
            {
                var weight = (i % 2 == 0) ? 2 : 1;
                digits.Add(i, new List<int>() { int.Parse(basic[i].ToString()), weight});
            }

            var products = new List<int>();

            foreach (var item in digits)
            {
                products.Add(item.Value[0] * item.Value[1]);
            }

            var sum = 0;
            foreach (var item in products)
            {
                if (item < 10)
                {
                    sum += item;
                }
                else
                {
                    var first = (int)Math.Floor((decimal)item / 10);
                    var last = item % 10;
                    sum += first;
                    sum += last;
                }
            }

            if(sum%10 == 0) {
                return 0;
            }

            var nextDec = (((int) Math.Floor((decimal) sum / 10)) + 1) * 10;
            return nextDec - sum;
        }

        private void Error(string msg)
        {
            throw new Exception(msg);
        }
    }
}