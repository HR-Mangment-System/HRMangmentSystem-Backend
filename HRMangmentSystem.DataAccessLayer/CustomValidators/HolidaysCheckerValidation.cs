using HRMangmentSystem.DataAccessLayer.Context;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangmentSystem.DataAccessLayer.CustomValidators
{
    public class HolidaysCheckerValidation : ValidationAttribute
    {
        private readonly HRMangmentCotext _hRMangmentCotext;

        public HolidaysCheckerValidation(HRMangmentCotext hRMangmentCotext)
        {
            _hRMangmentCotext = hRMangmentCotext ?? throw new ArgumentNullException(nameof(hRMangmentCotext));
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateOnly date)
            {
                if (CheckIfHoliday(date))
                {
                    return new ValidationResult("The date is a holiday.");
                }

                if (CheckIfWeekendHoliday(date))
                {
                    return new ValidationResult("The date is a weekend holiday.");
                }
            }

            return ValidationResult.Success;
        }

        private bool CheckIfHoliday(DateOnly date)
        {
            var holiday = _hRMangmentCotext.AnnualHolidays.FirstOrDefault(x => x.HolidayDate == date);
            return holiday != null;
        }

        private bool CheckIfWeekendHoliday(DateOnly date)
        {
            var settings = _hRMangmentCotext.GeneralSettings.FirstOrDefault();
            if (settings == null)
            {
                return false;
            }

            var holidayday1 = settings.WeeklyHoliday1;
            var holidayday2 = settings.WeeklyHoliday2;
            DayOfWeek firstDayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), holidayday1);
            DayOfWeek secondDayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), holidayday2);

            return date.DayOfWeek == firstDayOfWeek || date.DayOfWeek == secondDayOfWeek;
        }
    }
}
