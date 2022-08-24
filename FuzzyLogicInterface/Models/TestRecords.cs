//using ExpressiveAnnotations.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FuzzyLogicInterface.Models
{
    public class TestRecord : SharedModel
    {

        [ScaffoldColumn(false)]
        public int ModuleCodeLinesEntered { get; set; }

        [Required(ErrorMessage = "Enter lines of code your test case have")]
        public float TestCodeLines { get; set; }


        //[Remote("RangeValidation", "RemoteValidations",AdditionalFields = "ModuleCodeLinesEntered", ErrorMessage = "Test Case Code lines should be less than module code lines.")]
        //[Editable(true)]
        [ScaffoldColumn(false)]
        public float CodeCoverage { get; set; }

        [Required(ErrorMessage = "Enter criticality of requirement")]
       [Range(typeof(float), "1", "10", ErrorMessage = "The field value must be between 1 and 10 ")]
        public float CriticalityOfRequirement { get; set; }

    

        [Required(ErrorMessage = "Enter fault coverage")]
        [Range(typeof(float), "1", "10", ErrorMessage = "The field value must be between 1 and 10 ")]
        public float FaultCoverage { get; set; }

        [ScaffoldColumn(false)]
        public float PriorityValue { get; set; }

        [ScaffoldColumn(false)]
        public string Priority { get; set; }

        [ScaffoldColumn(false)]
        public DateTime dbEntry { get; set; }
    }
}
