using System.ComponentModel.DataAnnotations;

namespace Warsztat.BLL.Models
{
    public class Car

    {
        //Car CAR = new Car();

        [Key]
        public int Id { get; set; }

        [Display(Name = "Car Model")]
        public string Model_Name { get; set; }

        [Display(Name = "Car Mark")]
        public string MakeName { get; set; }
        public string VehicleTypeName { get; set; }

        [Display(Name = "Production Year")]
        public int YearProduction { get; set; }
        //public  string CarFullName
        //{
        //    get { return CAR.CarMark + " " + CAR.CarModel; }
        //}
        public string FullName => MakeName + " " + Model_Name;
    }
   
}   
    