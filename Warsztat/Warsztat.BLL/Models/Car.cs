using System.ComponentModel.DataAnnotations;

namespace Warsztat.BLL.Models
{
    public class Car

    {
        public int Id { get; set; }

        [Display(Name = "Car Model")]
        public string CarModel { get; set; }

        [Display(Name = "Car Mark")]
        public string CarMark { get; set; }

        [Display(Name = "Production Year")]
        public int YearProduction1 { get; set; }
    }
}