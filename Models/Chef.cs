using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace chefsanddishes
{
    public class Chef
    {
        [Key]
        public int ChefId {get;set;}
        [Required]
        [Display(Name = "First Name")]
        [MinLength(2)]
        public string FName {get;set;}
        [Required]
        [Display(Name = "Last Name")]
        [MinLength(2)]
        public string LName {get;set;}
        [Required]
        [Display(Name = "Date of Birth")]
        [NoFutureDates]
        public DateTime DofB {get;set;}
        public List<Dish> ChefDishes {get;set;}

    }

    public class NoFutureDates : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is DateTime)
            {
                DateTime dateToBeChecked = (DateTime)value;

                if(dateToBeChecked > DateTime.Now)
                {
                    return new ValidationResult("Date must be in the past");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("Not a valid datetime!");
            }
        }
    }
}