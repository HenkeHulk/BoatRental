using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRental.DAL.Enum
{
    public enum BoatType
    {
        [Display(Name = "Jolle")]
        Dinghy,
        [Display(Name = "Segelbåt")]
        SailBoat,
        [Display(Name = "Yacht")]
        Yacht
    }
}
