using FuzzyLogicInterface.Data;
using Microsoft.AspNetCore.Mvc;


namespace FuzzyLogicInterface.Controllers
{
    public class RemoteValidationsController : Controller
    {      
            private FuzzyContext _context;
            public RemoteValidationsController(FuzzyContext context)
            {
                _context = context;
            }
    
     
        public Boolean RangeValidation(int ModuleCodeLinesEntered, float CodeCoverage)
        {
            if (CodeCoverage >= (float)ModuleCodeLinesEntered)
            {
                return false;
            }
            return true;

        }
    }
    
}
