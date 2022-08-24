using System.ComponentModel.DataAnnotations;

namespace FuzzyLogicInterface.Models
{
    public class ModuleRecord : SharedModel
    {
      

        [Required(ErrorMessage="Enter lines of code your module have")]
        public int ModuleCodeLines { get; set; }

        [ScaffoldColumn(false)]
        public DateTime StartSession { get; set; }

        //[ScaffoldColumn(false)]
        //public DateTime EndSession { get; set; }
    }
}
