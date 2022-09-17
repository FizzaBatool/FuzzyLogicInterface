using FuzzyLogicInterface.Models;
using FuzzyLogicInterface.Data;
using Microsoft.AspNetCore.Mvc;

namespace FuzzyLogicInterface.Controllers
{
    public class InputController : Controller
    {
        private readonly FuzzyContext db;
        public float lowStart = 0.0f;
        public float lowEnd = 0.33f;
        public float midStart = 0.34f;
        public float midEnd = 0.66f;
        public float hiStart = 0.67f;
        public float hiEnd = 1.0f;
     
        public InputController(FuzzyContext db)
        {
            this.db = db;

        }

        [HttpGet]
        public IActionResult ModuleRecordInput()
        {
            return View();
        }

        [HttpPost]
       
        public IActionResult ModuleRecordInput(ModuleRecord mr)
        {
            if (ModelState.IsValid)
            {
             

                ModuleRecord obj = new ModuleRecord();
                obj.ModuleCodeLines = mr.ModuleCodeLines;
                obj.StartSession = DateTime.Now;
                obj.EndSession = DateTime.Now;
                TempData["ModuleCodeLines"] = mr.ModuleCodeLines;
       
                db.ModulesData.Add(obj);
                db.SaveChanges();

            }
            return RedirectToAction("TestRecordInput", "Input");
        }
        [HttpGet]
        public IActionResult TestRecordInput()
        {
            return View();
        }
        [HttpPost]
      
        public async Task<ActionResult> TestRecordInput(TestRecord tr)
            {
            if (ModelState.IsValid)
            {
                TestRecord obj = new TestRecord();

                tr.ModuleCodeLinesEntered = db.ModulesData.OrderByDescending(p => p.Id).FirstOrDefault().ModuleCodeLines;
                TempData["ModuleCodeLInes"] = tr.ModuleCodeLinesEntered;
                obj.ModuleCodeLinesEntered = tr.ModuleCodeLinesEntered;

                obj.TestCodeLines =  tr.TestCodeLines;

                tr.CriticalityOfRequirement = (tr.CriticalityOfRequirement)/10;
                obj.CriticalityOfRequirement = tr.CriticalityOfRequirement;

                
                tr.CodeCoverage = (tr.TestCodeLines / tr.ModuleCodeLinesEntered);
                tr.CodeCoverage = (float)Math.Round(tr.CodeCoverage, 2);
                obj.CodeCoverage = tr.CodeCoverage;

                tr.FaultCoverage = (tr.FaultCoverage)/10;
                obj.FaultCoverage = tr.FaultCoverage;

                if (tr.CodeCoverage >= 1)
                {
                    ViewData["Warning"] = "Test Case Code lines should be less than module code lines.";
                    //ModelState.Clear();
                    return View();
                }
                else
                {

                    //CR Low
                    if (tr.CriticalityOfRequirement >= lowStart && tr.CriticalityOfRequirement <= lowEnd)
                    {
                        //CC Low
                        if (tr.CodeCoverage >= lowStart && tr.CodeCoverage <= lowEnd)
                        {
                            //fc low
                            if (tr.FaultCoverage >= lowStart && tr.FaultCoverage <= lowEnd)
                            {
                                obj.Priority = "Low";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            //fc medium
                            else if (tr.FaultCoverage >= midStart && tr.FaultCoverage <= midEnd)
                            {
                                obj.Priority = "Medium";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            //fc high
                            else if (tr.FaultCoverage >= hiStart && tr.FaultCoverage <= hiEnd)
                            {
                                obj.Priority = "High";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                        }
                        //CC Medium
                        else if (tr.CodeCoverage >= midStart && tr.CodeCoverage <= midEnd)
                        {
                            //fc low
                            if (tr.FaultCoverage >= lowStart && tr.FaultCoverage <= lowEnd)
                            {
                                obj.Priority = "Low";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            //fc medium
                            else if (tr.FaultCoverage >= midStart && tr.FaultCoverage <= midEnd)
                            {
                                obj.Priority = "Medium";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            //fc high
                            else if (tr.FaultCoverage >= hiStart && tr.FaultCoverage <= hiEnd)
                            {
                                obj.Priority = "High";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                        }
                        //CC high
                        else if (tr.CodeCoverage >= hiStart && tr.CodeCoverage <= hiEnd)
                        {
                            //fc low

                            if (tr.FaultCoverage >= lowStart && tr.CodeCoverage <= lowEnd)
                            {
                                obj.Priority = "Medium";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            //fc medium
                            else if (tr.FaultCoverage >= midStart && tr.FaultCoverage <= midEnd)
                            {
                                obj.Priority = "Medium";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            //fc high
                            else if (tr.FaultCoverage >= hiStart && tr.FaultCoverage <= hiEnd)
                            {
                                obj.Priority = "High";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                        }
                    }
                    //CR medium
                    else if (tr.CriticalityOfRequirement >= midStart && tr.CriticalityOfRequirement <= midEnd)
                    {
                        //CC low
                        if (tr.CodeCoverage >= lowStart && tr.CodeCoverage <= lowEnd)
                        {
                            //fc low
                            if (tr.FaultCoverage >= lowStart && tr.FaultCoverage <= lowEnd)
                            {
                                obj.Priority = "Low";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            //fc medium
                            else if (tr.FaultCoverage >= midStart && tr.FaultCoverage <= midEnd)
                            {
                                obj.Priority = "Low";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            //fc high
                            else if (tr.FaultCoverage >= hiStart && tr.FaultCoverage <= hiEnd)
                            {
                                obj.Priority = "Low";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                        }
                        //CC medium
                        else if (tr.CodeCoverage >= midStart && tr.CodeCoverage <= midEnd)
                        {
                            //fc low
                            if (tr.FaultCoverage >= lowStart && tr.FaultCoverage <= lowEnd)
                            {
                                obj.Priority = "Medium";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            //fc medium
                            else if (tr.FaultCoverage >= midStart && tr.FaultCoverage <= midEnd)
                            {
                                obj.Priority = "Medium";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            //fc low
                            else if (tr.FaultCoverage >= hiStart && tr.FaultCoverage <= hiEnd)
                            {
                                obj.Priority = "High";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                        }
                        //CC High
                        else if (tr.CodeCoverage >= hiStart && tr.CodeCoverage <= hiEnd)
                        {
                            //fc low
                            if (tr.FaultCoverage >= lowStart && tr.FaultCoverage <= lowEnd)
                            {
                                obj.Priority = "High";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            //fc medium
                            else if (tr.FaultCoverage >= midStart && tr.FaultCoverage <= midEnd)
                            {
                                obj.Priority = "High";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            //fc high
                            else if (tr.FaultCoverage >= hiStart && tr.FaultCoverage <= hiEnd)
                            {
                                obj.Priority = "High";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                        }
                    }
                    //CR High
                    else if (tr.CriticalityOfRequirement >= hiStart && tr.CriticalityOfRequirement <= hiEnd)
                    { //CC low
                        if (tr.CodeCoverage >= lowStart && tr.CodeCoverage <= lowEnd)
                        {
                            if (tr.FaultCoverage >= lowStart && tr.FaultCoverage <= lowEnd)
                            {
                                obj.Priority = "High";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            else if (tr.FaultCoverage >= midStart && tr.FaultCoverage <= midEnd)
                            {
                                obj.Priority = "High";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            else if (tr.FaultCoverage >= hiStart && tr.FaultCoverage <= hiEnd)
                            {
                                obj.Priority = "High";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                        }
                        //CC medium
                        else if (tr.CodeCoverage >= midStart && tr.CodeCoverage <= midEnd)
                        {
                            // fc low
                            if (tr.FaultCoverage >= lowStart && tr.FaultCoverage <= lowEnd)
                            {
                                obj.Priority = "High";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            //fc medium
                            else if (tr.FaultCoverage >= midStart && tr.FaultCoverage <= midEnd)
                            {
                                obj.Priority = "High";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            //fc high
                            else if (tr.FaultCoverage >= hiStart && tr.FaultCoverage <= hiEnd)
                            {
                                obj.Priority = "High";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                        }
                        //CC High
                        else if (tr.CodeCoverage >= hiStart && tr.CodeCoverage <= hiEnd)
                        {
                            //fc low
                            if (tr.FaultCoverage >= lowStart && tr.FaultCoverage <= lowEnd)
                            {
                                obj.Priority = "High";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            // fc medium
                            else if (tr.FaultCoverage >= midStart && tr.FaultCoverage <= midEnd)
                            {
                                obj.Priority = "High";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            //fc high
                            else if (tr.FaultCoverage >= hiStart && tr.FaultCoverage <= hiEnd)
                            {
                                obj.Priority = "High";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                        }
                    }


                    db.TestsData.Add(obj);
                    db.SaveChanges();
                
                    ViewData["Message"] = "Test Record Entered Successfully";
                }

            }
            else
            {
                ModelState.Clear();
                return View();
            }
           
        }
        

        [HttpGet]
        public IActionResult SortOutput()
        {
           // ModuleRecord mr = new ModuleRecord();
           // mr.EndSession= db.ModulesData.OrderByDescending(p => p.Id).FirstOrDefault().EndSession;

            //var query = from m in db.TestsData
            //            where m.ModuleCodeLinesEntered == db.TestsData.OrderByDescending(p => p.Id).FirstOrDefault().ModuleCodeLinesEntered
            //            select m;
            //foreach (var a in query)
            //{
            //    System.Console.WriteLine(a.Name + " " + a.Address1_City);
            //}
            // Or this for typed model
            // select new MyModel { Column1 = m.Column1, etc }\

            var listdata = db.TestsData.ToList();

            //var model = query.First();
            return View(listdata.ToList());
        }
    }
}
