using System.ComponentModel.DataAnnotations;

namespace FuzzyLogicInterface.Models
{
    public class TestRecord : SharedModel
    {

        [ScaffoldColumn(false)]
        public int ModuleCodeLinesEntered { get; set; }

        //[ScaffoldColumn(false)]
        //public int ModuleRecordId { get; set; }
        //public ModuleRecord ModuleRecord { get; set; }

        [Required(ErrorMessage = "Enter criticality of requirement")]
       [Range(typeof(float), "0.0", "1.0", ErrorMessage = "The field value must be between 0.0 and 1.0 ")]
        public float CriticalityOfRequirement { get; set; }

      [Required(ErrorMessage = "Enter lines of code your test case have")]
     // [Range(typeof(float), "0.0", "1.0", ErrorMessage = "The field value must be between 0.0 and 1.0 ")]
        public float CodeCoverage { get; set; } 

        [Required(ErrorMessage = "Enter fault coverage")]
        [Range(typeof(float), "0.0", "1.0", ErrorMessage = "The field value must be between 0.0 and 1.0 ")]
        public float FaultCoverage { get; set; }

        [ScaffoldColumn(false)]
        public float PriorityValue { get; set; }

        [ScaffoldColumn(false)]
        public string Priority { get; set; }

        [ScaffoldColumn(false)]
        public DateTime dbEntry { get; set; }
    }
}
