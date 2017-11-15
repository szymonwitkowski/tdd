using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddShop.Cli.Shipment
{
    public class NumeralsConvereter : INumeralsConvereter
    {
        public string ArabicToRomanNumeralsConverter(int arabicNumber)
        {
            var arabicNumberString = arabicNumber.ToString();
            int[] digits = new int[arabicNumberString.Count()+1];
            for (int i = 0; i < arabicNumberString.Count(); i++)
            {
                digits[i] = (int)Char.GetNumericValue(arabicNumberString[i]);
            }


            string thousandsRoman;
            string hundredsRoman;
            string tensRoman;
            string onesRoman;

            if (arabicNumberString.Count() == 4 && digits[0] <= 3)
            {
                thousandsRoman = ThousandsArabicToRoman(digits[0]);
                hundredsRoman = HundredsArabicToRoman(digits[1]);
                tensRoman = TensArabicToRoman(digits[2]);
                onesRoman = OnesArabicToRoman(digits[3]);
                return thousandsRoman + hundredsRoman + tensRoman + onesRoman;
            }

            else if (arabicNumberString.Count() == 3)
            {
                hundredsRoman = HundredsArabicToRoman(digits[0]);
                tensRoman = TensArabicToRoman(digits[1]);
                onesRoman = OnesArabicToRoman(digits[2]);
                return hundredsRoman + tensRoman + onesRoman;
            }

            else if (arabicNumberString.Count() == 2)
            {
                tensRoman = TensArabicToRoman(digits[0]);
                onesRoman = OnesArabicToRoman(digits[1]);
                return tensRoman + onesRoman;
            }
            else if (arabicNumberString.Count() == 1 && digits[0] > 0)
            {
                onesRoman = OnesArabicToRoman(digits[0]);
                return onesRoman;
            }

            else
            {
                return "Can't convert";
            }

        }

        private string OnesArabicToRoman(int ones)
        {
            switch (ones)
            {
                case 1:
                    return "I";
                case 2:
                    return "II";
                case 3:
                    return "III";
                case 4:
                    return "IV";
                case 5:
                    return "V";
                case 6:
                    return "VI";
                case 7:
                    return "VII";
                case 8:
                    return "VIII";
                case 9:
                    return "IX";
            }
            return "Something went wrong on ones";
        }

        private string TensArabicToRoman(int tens)
        {
            switch (tens)
            {
                case 1:
                    return "X";
                case 2:
                    return "XX";
                case 3:
                    return "XXX";
                case 4:
                    return "XL";
                case 5:
                    return "L";
                case 6:
                    return "LX";
                case 7:
                    return "LXX";
                case 8:
                    return "LXXX";
                case 9:
                    return "XC";
            }
            return "Something went wrong on tens";
        }

        private string HundredsArabicToRoman(int hundreds)
        {
            switch (hundreds)
            {
                case 1:
                    return "C";
                case 2:
                    return "CC";
                case 3:
                    return "CCC";
                case 4:
                    return "CD";
                case 5:
                    return "D";
                case 6:
                    return "DC";
                case 7:
                    return "DCC";
                case 8:
                    return "DCCC";
                case 9:
                    return "CM";
            }
            return "Something went wrong on hundreds";
        }

        private string ThousandsArabicToRoman(int thousands)
        {
            switch (thousands)
            {
                case 1:
                    return "M";
                case 2:
                    return "MM";
                case 3:
                    return "MM";
            }
            return "Something went wrong on thousands";
        }
    }
}
