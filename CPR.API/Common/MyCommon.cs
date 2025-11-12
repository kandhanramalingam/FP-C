using AstuteServiceReference;
using CPR.API.Models;

namespace CPR.API.Common
{
    public class MyCommon
    {
        public static List<ApiKeyModel> GetApiKeys()
        {
            return
            [
                new ApiKeyModel("dev", "1779d06f-6713-47ad-8ab7-c5900f729f58")
            ];
        }

        public static DateTime GetDOB(string idNumber)
        {
            if (idNumber.Length > 6)
            {
                string yearString = idNumber.Substring(0, 2);
                string monthString = idNumber.Substring(2, 2);
                string dayString = idNumber.Substring(4, 2);
                int year = int.Parse(yearString);
                int month = int.Parse(monthString);
                int day = int.Parse(dayString);
                int currentYearLastTwoDigits = DateTime.Now.Year % 100;
                int century = (year <= currentYearLastTwoDigits) ? 2000 : 1900;
                year += century;
                return new DateTime(year, month, day);
            }
            else
            {
                throw new ArgumentException("ID number is too short to extract date of birth.");
            }
        }

        public static ProviderDetail[] GetAllProviders()
        {
            return
            [
                new ProviderDetail() { ProviderCode = "AMAS" },
                new ProviderDetail() { ProviderCode = "ABSA" },
                new ProviderDetail() { ProviderCode = "DSL" },
                new ProviderDetail() { ProviderCode = "FMI" },
                new ProviderDetail() { ProviderCode = "ALT" },
                new ProviderDetail() { ProviderCode = "LIB" },
                new ProviderDetail() { ProviderCode = "MOM" },
                new ProviderDetail() { ProviderCode = "NGL" },
                new ProviderDetail() { ProviderCode = "OMU" },
                new ProviderDetail() { ProviderCode = "SLMNA" },
                new ProviderDetail() { ProviderCode = "PPS" },
                new ProviderDetail() { ProviderCode = "SLM" },
                new ProviderDetail() { ProviderCode = "FNB" },
                new ProviderDetail() { ProviderCode = "AG" },
                new ProviderDetail() { ProviderCode = "OMGP" },
                new ProviderDetail() { ProviderCode = "DSI" },
                new ProviderDetail() { ProviderCode = "MOMW" },
                new ProviderDetail() { ProviderCode = "OMGP" },
                new ProviderDetail() { ProviderCode = "STLB" },
                new ProviderDetail() { ProviderCode = "SET" },
                new ProviderDetail() { ProviderCode = "INN8" },
                new ProviderDetail() { ProviderCode = "MOME" },
                new ProviderDetail() { ProviderCode = "SANE" }
            ];
        }
    }
}