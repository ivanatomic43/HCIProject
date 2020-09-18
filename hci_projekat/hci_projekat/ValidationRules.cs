using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace hci_projekat
{
    public class CheckIfEmptyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                if (!string.IsNullOrWhiteSpace(s))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Obavezan unos");
            }
            catch
            {
                return new ValidationResult(false, "Obavezan unos");
            }
        }
    }

    public class CheckStringRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                int pom = 0;
                bool canConvert = false;
                canConvert = int.TryParse(s, out pom);
                if (canConvert == false)
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Ne sme biti broj");
            }
            catch
            {
                return new ValidationResult(false, "Ne sme biti broj");
            }
        }
    }

    public class CheckIfDateFormatRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                string[] parts;
                string dan; int iDan;
                string mesec; int iMesec;
                string godina; int iGodina;
                parts = s.Split('/');
                dan = parts[0];
                mesec = parts[1];
                godina = parts[2];

                int.TryParse(dan, out iDan);
                int.TryParse(mesec, out iMesec);
                int.TryParse(godina, out iGodina);

                if (iDan < 1 || iDan > 31)
                {
                    return new ValidationResult(false, "Pogresna vrednost dana");
                }
                if (iMesec < 1 || iMesec > 12)
                {
                    return new ValidationResult(false, "Pogresna vrednost meseca");
                }
                if (iGodina < 1000 || iGodina > 2018)
                {
                    return new ValidationResult(false, "Pogresna vrednost godine");
                }

                Regex r1 = new Regex(@"^\d{1,2}\/\d{1,2}\/\d{1,4}$");
                Regex r2 = new Regex(@"^\d{1,2}\-\d{1,2}\-\d{1,4}$");
                if (r1.IsMatch(s) || r2.IsMatch(s))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Pogresan format datuma");
            }
            catch
            {
                return new ValidationResult(false, "Pogresan format datuma");
            }
        }
    }

    public class CheckIfOnlyNumbersRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                Regex r = new Regex(@"^\d+$");
                if (r.IsMatch(s))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Mora biti pozitivan broj");
            }
            catch
            {
                return new ValidationResult(false, "Mora biti pozitivan broj");
            }
        }

    }
    public class CheckSpace : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;

                if (!s.Contains(" "))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Ne sme sadrzati razmak");
            }
            catch
            {
                return new ValidationResult(false, "Ne sme sadrzati razmak");
            }
        }

    }

    public class DatePickerValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var date = (DateTime)value;

            return date.Date.CompareTo(DateTime.Now) < 0
                ? new ValidationResult(false, "the date can not be before today")
                : new ValidationResult(true, null);
        }
    }
}