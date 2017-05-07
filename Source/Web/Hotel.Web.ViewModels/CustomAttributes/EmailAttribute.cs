namespace Hotel.Web.Hotel.Web.ViewModels.CustomAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class EmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string emailString = (string)value;

            if (emailString == null)
            {
                throw new ArgumentException("The email is not of string type.");
            }

            string regularExpressinString = @"([a-zA-Z0-9][a-zA-Z_\-.]*[a-zA-Z0-9])@([a-zA-Z-]+\.[a-zA-Z-]+(\.[a-zA-Z-]+)*)";
            Regex regex = new Regex(regularExpressinString);

            if (regex.IsMatch(emailString))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The email is not valid.");
        }
    }
}