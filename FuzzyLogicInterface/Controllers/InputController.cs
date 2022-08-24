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
                //obj.EndSession = DateTime.Now;
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
       public IActionResult TestRecordInput(TestRecord tr)
            {
                if (ModelState.IsValid)
                {
                    TestRecord obj = new TestRecord();

                    tr.ModuleCodeLinesEntered = db.ModulesData.OrderByDescending(p => p.Id).FirstOrDefault().ModuleCodeLines;
                    TempData["ModuleCodeLInes"] = tr.ModuleCodeLinesEntered;
                    obj.ModuleCodeLinesEntered = tr.ModuleCodeLinesEntered;

                    obj.CriticalityOfRequirement = tr.CriticalityOfRequirement;

                    tr.CodeCoverage = (tr.CodeCoverage / tr.ModuleCodeLinesEntered);
                    tr.CodeCoverage = (float)Math.Round(tr.CodeCoverage, 2);
                    obj.CodeCoverage = tr.CodeCoverage;

                    obj.FaultCoverage = tr.FaultCoverage;




                    //CR Low
                    if (tr.CriticalityOfRequirement >= lowStart && tr.CriticalityOfRequirement <= lowEnd)
                    {
                        //CC Low
                        if (tr.CodeCoverage >= lowStart && tr.CodeCoverage <= lowEnd)
                        {
                        //fc low
                            if (tr.FaultCoverage >= lowStart && tr.CodeCoverage <= lowEnd)
                            {
                                obj.Priority = "L";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            //fc medium
                            else if (tr.FaultCoverage >= midStart && tr.CodeCoverage <= midEnd)
                            {
                                obj.Priority = "M";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            //fc high
                            else if (tr.FaultCoverage >= hiStart && tr.CodeCoverage <= hiEnd)
                            {
                                obj.Priority = "H";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                        }
                        //CC Medium
                        else if (tr.CodeCoverage >= midStart && tr.CodeCoverage <= midEnd)
                        {
                        //fc low
                            if (tr.FaultCoverage >= lowStart && tr.CodeCoverage <= lowEnd)
                            {
                                obj.Priority = "L";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            //fc medium
                            else if (tr.FaultCoverage >= midStart && tr.CodeCoverage <= midEnd)
                            {
                                obj.Priority = "M";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            //fc high
                            else if (tr.FaultCoverage >= hiStart && tr.CodeCoverage <= hiEnd)
                            {
                                obj.Priority = "H";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                        }
                        //CC high
                        else if (tr.CodeCoverage >= hiStart && tr.CodeCoverage <= hiEnd)
                        {
                        //fc low

                            if (tr.FaultCoverage >= lowStart && tr.CodeCoverage <= lowEnd)
                            {
                                obj.Priority = "M";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            //fc medium
                            else if (tr.FaultCoverage >= midStart && tr.CodeCoverage <= midEnd)
                            {
                                obj.Priority = "M";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            //fc high
                            else if (tr.FaultCoverage >= hiStart && tr.CodeCoverage <= hiEnd)
                            {
                                obj.Priority = "H";
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
                            if (tr.FaultCoverage >= lowStart && tr.CodeCoverage <= lowEnd)
                            {
                                obj.Priority = "L";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            //fc medium
                            else if (tr.FaultCoverage >= midStart && tr.CodeCoverage <= midEnd)
                            {
                                obj.Priority = "L";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            //fc high
                            else if (tr.FaultCoverage >= hiStart && tr.CodeCoverage <= hiEnd)
                            {
                                obj.Priority = "L";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                        }
                    //CC medium
                    else if (tr.CodeCoverage >= midStart && tr.CodeCoverage <= midEnd)
                        {
                        //fc low
                            if (tr.FaultCoverage >= lowStart && tr.CodeCoverage <= lowEnd)
                            {
                                obj.Priority = "M";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            //fc medium
                            else if (tr.FaultCoverage >= midStart && tr.CodeCoverage <= midEnd)
                            {
                                obj.Priority = "M";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            //fc low
                            else if (tr.FaultCoverage >= hiStart && tr.CodeCoverage <= hiEnd)
                            {
                                obj.Priority = "H";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                        }
                        //CC High
                        else if (tr.CodeCoverage >= hiStart && tr.CodeCoverage <= hiEnd)
                        {
                        //fc low
                            if (tr.FaultCoverage >= lowStart && tr.CodeCoverage <= lowEnd)
                            {
                                obj.Priority = "H";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            //fc medium
                            else if (tr.FaultCoverage >= midStart && tr.CodeCoverage <= midEnd)
                            {
                                obj.Priority = "H";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            //fc high
                            else if (tr.FaultCoverage >= hiStart && tr.CodeCoverage <= hiEnd)
                            {
                                obj.Priority = "H";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                        }
                    }
                //CR High
                else if (tr.CriticalityOfRequirement >= hiStart && tr.CriticalityOfRequirement <= hiEnd)
                    { //CC low
                        if (tr.CodeCoverage >= lowStart && tr.CodeCoverage <= lowEnd)
                        {
                            if (tr.FaultCoverage >= lowStart && tr.CodeCoverage <= lowEnd)
                            {
                                obj.Priority = "H";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            else if (tr.FaultCoverage >= midStart && tr.CodeCoverage <= midEnd)
                            {
                                obj.Priority = "H";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            else if (tr.FaultCoverage >= hiStart && tr.CodeCoverage <= hiEnd)
                            {
                                obj.Priority = "H";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                        }
                        //CC medium
                        else if (tr.CodeCoverage >= midStart && tr.CodeCoverage <= midEnd)
                        {
                            if (tr.FaultCoverage >= lowStart && tr.CodeCoverage <= lowEnd)
                            {
                                obj.Priority = "H";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            else if (tr.FaultCoverage >= midStart && tr.CodeCoverage <= midEnd)
                            {
                                obj.Priority = "H";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            else if (tr.FaultCoverage >= hiStart && tr.CodeCoverage <= hiEnd)
                            {
                                obj.Priority = "H";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                        }
                        //CC High
                        else if (tr.CodeCoverage >= hiStart && tr.CodeCoverage <= hiEnd)
                        {
                            if (tr.FaultCoverage >= lowStart && tr.CodeCoverage <= lowEnd)
                            {
                                obj.Priority = "H";
                                obj.PriorityValue = tr.CriticalityOfRequirement;

                            }
                            else if (tr.FaultCoverage >= midStart && tr.CodeCoverage <= midEnd)
                            {
                                obj.Priority = "H";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                            else if (tr.FaultCoverage >= hiStart && tr.CodeCoverage <= hiEnd)
                            {
                                obj.Priority = "H";
                                obj.PriorityValue = tr.CriticalityOfRequirement;
                            }
                        }
                    }

                tr.dbEntry = obj.dbEntry = DateTime.Now;
                    db.TestsData.Add(obj);
                    db.SaveChanges();
                
                    ViewData["Message"] = "Test Record Entered Successfully";
                 }


                return View();
            }
        //[HttpGet]
        //public IActionResult indexee()
        //{
        //    return View();
        //}
        //public async Task<ActionResult> SortOutput()
        //{
        //    IQueryable<TestRecord> items = from i in db.TestsData orderby i.ModuleCodeLinesEntered select i;
        //    List<TestRecord> TestRecordSorted = await items.ToListAsync();
        //    return View(todolist);
        //}


        //var SortedRecords = from sr in db.TestsData
        //             where sr.ModuleCodeLinesEntered==db.ModulesData.OrderByDescending(p => p.Id).FirstOrDefault().ModuleCodeLines
        //             select sr;

        //return View(SortedRecords.ToList());

        //     var model =
        //(
        //    from p in this.List()
        //    where (p.column1 == column1) && (p.column2 == column2)
        //    select p
        //).FirstOrDefault();
        //     return View(model);

        [HttpGet]
        public IActionResult SortOutput()
        {
            //ModuleRecord mr = new ModuleRecord();
            //mr.EndSession  = DateTime.Now;


            // var modelTime=db.ModulesData.OrderByDescending(y => y.EndSession).FirstOrDefault();   

            //var listdata = db.TestsData.TakeWhile(m => m.ModuleCodeLinesEntered ==model).ToList();
            //var listdata = db.TestsData.Where(m => m.ModuleCodeLinesEntered ==model).TakeWhile(m => m.ModuleCodeLinesEntered ==model).ToList();

            //var model = db.ModulesData.OrderByDescending(x => x.StartSession).Select(x => x.StartSession).ToList();

            var modelLines = db.ModulesData.OrderByDescending(x => x.Id).FirstOrDefault().ModuleCodeLines;
            var modelDate = db.ModulesData.OrderByDescending(x => x.StartSession).FirstOrDefault().StartSession;
            var listdata = from sr in db.TestsData
                           where sr.ModuleCodeLinesEntered ==modelLines where sr.dbEntry >= modelDate
                           select sr;

            //var model = query.First();
            return View(listdata.ToList());
        }
    }
}
