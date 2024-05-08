using HRMangmentSystem.DataAccessLayer.Context;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMangmentSystem.DataAccessLayer.CustomValidators
{
    public class HolidaysCheckerValidation : ValidationAttribute
    {
       



        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _hRMangmentCotext = (HRMangmentCotext)validationContext.GetService(typeof(HRMangmentCotext));
            
            if (value is DateOnly date)
            {
                var holiday = _hRMangmentCotext.AnnualHolidays.FirstOrDefault(x => x.HolidayDate == date);
                var settings = _hRMangmentCotext.GeneralSettings.FirstOrDefault();
                if (settings == null)
                {
                     return new ValidationResult("The date is a holiday.");
                }

                var holidayday1 = settings.WeeklyHoliday1;
                var holidayday2 = settings.WeeklyHoliday2;
                DayOfWeek firstDayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), holidayday1);
                DayOfWeek secondDayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), holidayday2);

                 

                if (holiday!=null)
                {
                    return new ValidationResult("The date is a holiday.");
                }
                

                if (date.DayOfWeek == firstDayOfWeek || date.DayOfWeek == secondDayOfWeek)
                {
                    return new ValidationResult("The date is a weekend holiday.");
                }
            }

            return ValidationResult.Success;
        }

        
    }
}
