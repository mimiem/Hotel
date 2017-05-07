namespace Hotel.Web.Hotel.Web.ViewModels.CustomAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string phoneString = (string)value;

            if (phoneString == null)
            {
                throw new ArgumentException("The phone number is not of string type.");
            }

            string regularExpressinString = @"^\+[0-9]{10,12}$";
            Regex regex = new Regex(regularExpressinString);

            if (regex.IsMatch(phoneString))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The phone number is not valid.");
        }
    }
}
