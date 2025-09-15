using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using MandrilAPI.Aplication.Service;
using MandrilAPI.Infrastructure.DTOs;

namespace MandrilAPI.Infrastructure.CustomAnnotations
{
    public class OnlyLetterCount(int minLettersToValidate) : ValidationAttribute
    {
        
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext
        )
        {
            if (value is null)
            {

                return new ValidationResult(MessageDefaultsUsers.NullObject);
            }
            else
            {
                var valueString = value.ToString().Trim();
         
                if (valueString.Length < minLettersToValidate)
                {
                    return new ValidationResult(MessageDefaultsUsers.EntryMinLength);
                }
                else
                {
                    
                    return ValidationResult.Success;
                } 
            }
            
            
        }

    }
}
