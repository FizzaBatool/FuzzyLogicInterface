using System.ComponentModel.DataAnnotations;

namespace FuzzyLogicInterface.Models
{
    public class TestRecordForm
    {
 
        [Required(ErrorMessage = "Enter criticality of requirement")]
        [Range(typeof(float), "0.0", "1.0", ErrorMessage = "The field value must be between 0.0 and 1.0 ")]
        public float CriticalityOfRequirement { get; set; } // criticality of requirement

        [Required(ErrorMessage = "Enter lines of code your test case have")]
        //[Range(typeof(float), "0.0", "1.0", ErrorMessage = "The field value must be between 0.0 and 1.0 ")]
        public int CodeCoverage { get; set; } // code coverage

        [Required(ErrorMessage = "Enter fault coverage")]
        [Range(typeof(float), "0.0", "1.0", ErrorMessage = "The field value must be between 0.0 and 1.0 ")]
        public float FaultCoverage { get; set; }  //fault coverage
      
    }
}
