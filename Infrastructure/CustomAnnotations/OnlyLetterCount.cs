using System.ComponentModel.DataAnnotations;

using MandrilAPI.Aplication.Service;
using MandrilAPI.Infrastructure.DTOs;

namespace MandrilAPI.Infrastructure.CustomAnnotations
{
    public class OnlyLetterCount(int minLettersToValidate) : ValidationAttribute
    {
        
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext
        )
        {
            var valueString = value.ToString();
         
                if (valueString.Length < minLettersToValidate)
                {
                    return new ValidationResult(ErrorMessage = MessageDefaultsUsers.EntryMinLength);
                }
                else
                {
                    
                    return ValidationResult.Success;
                }
        }

    }
}
