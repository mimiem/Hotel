namespace Hotel.Web.ViewModels.CustomAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property)]
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        public DateGreaterThanAttribute(string dateToCompareToFieldName)
        {
            DateToCompareToFieldName = dateToCompareToFieldName;
        }

        private string DateToCompareToFieldName { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime startDate = (DateTime)value;

            DateTime endDate = (DateTime)validationContext.ObjectType.GetProperty(DateToCompareToFieldName).GetValue(validationContext.ObjectInstance, null);

            if (endDate > startDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date is not later");
            }
        }
    }
}
