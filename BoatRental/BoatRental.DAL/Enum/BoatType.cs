using System.ComponentModel.DataAnnotations;

namespace BoatRental.DAL.Enum
{
    public enum BoatType
    {
        [Display(Name = "Jolle")]
        Dinghy,
        [Display(Name = "Båt < 40 fot")]
        Boat,
        [Display(Name = "Båt >= 40 fot")]
        Yahct
    }
}