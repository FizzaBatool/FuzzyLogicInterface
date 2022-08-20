using FuzzyLogicInterface.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FuzzyLogicInterface.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

//         else if (tr.CriticalityOfRequirement >= 0.67 && tr.CriticalityOfRequirement <= 1.0)
//                    { //CC low
//                        if (tr.CodeCoverage >= 0.0 && tr.CodeCoverage <= 0.33)
//                        {
//                            if (tr.FaultCoverage >= 0.0 && tr.CodeCoverage <= 0.33)
//                            {
//                                obj.Priority = "H";
//                                obj.PriorityValue = tr.CriticalityOfRequirement;

//                            }
//                            else if (tr.FaultCoverage >= 3.4 && tr.CodeCoverage <= 0.66)
//                            {
//                                obj.Priority = "H";
//                                obj.PriorityValue = tr.CriticalityOfRequirement;
//                            }
//                            else if (tr.FaultCoverage >= 6.7 && tr.CodeCoverage <= 1.0)
//{
//    obj.Priority = "H";
//    obj.PriorityValue = tr.CriticalityOfRequirement;
//}
//                        }
//                        //CC medium
//                        else if (tr.CodeCoverage >= 3.4 && tr.CodeCoverage <= 0.66)
//{
//    if (tr.FaultCoverage >= 0.0 && tr.CodeCoverage <= 0.33)
//    {
//        obj.Priority = "H";
//        obj.PriorityValue = tr.CriticalityOfRequirement;

//    }
//    else if (tr.FaultCoverage >= 3.4 && tr.CodeCoverage <= 0.66)
//    {
//        obj.Priority = "H";
//        obj.PriorityValue = tr.CriticalityOfRequirement;
//    }
//    else if (tr.FaultCoverage >= 6.7 && tr.CodeCoverage <= 1.0)
//    {
//        obj.Priority = "H";
//        obj.PriorityValue = tr.CriticalityOfRequirement;
//    }
//}
////CC High
//else if (tr.CodeCoverage >= 6.7 && tr.CodeCoverage <= 1.0)
//{
//    if (tr.FaultCoverage >= 0.0 && tr.CodeCoverage <= 0.33)
//    {
//        obj.Priority = "H";
//        obj.PriorityValue = tr.CriticalityOfRequirement;

//    }
//    else if (tr.FaultCoverage >= 3.4 && tr.CodeCoverage <= 0.66)
//    {
//        obj.Priority = "H";
//        obj.PriorityValue = tr.CriticalityOfRequirement;
//    }
//    else if (tr.FaultCoverage >= 6.7 && tr.CodeCoverage <= 1.0)
//    {
//        obj.Priority = "H";
//        obj.PriorityValue = tr.CriticalityOfRequirement;
//    }
//}
//                    }

    }
}