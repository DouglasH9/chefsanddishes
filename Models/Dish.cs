using System;
using System.ComponentModel.DataAnnotations;

namespace chefsanddishes
{
    public class Dish
    {
        [Key]
        public int DishId {get; set;}
        [Required]
        [Display(Name ="Dish Name")]
        public string DishName {get; set;}
        [Required]
        [Display(Name ="Calories")]
        public int Calories {get; set;}
        [Required]
        [Display(Name ="Description")]
        public string Description {get;set;}
        [Required]
        [Display(Name ="Tastiness")]
        public int Tastiness {get; set;}
        public Chef Creator {get; set;}
        public int ChefId {get; set;}
    }
}