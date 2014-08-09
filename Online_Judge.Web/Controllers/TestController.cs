using System.Net;
using System.Web.Mvc;
using Online_Judge.BLL;
using Online_Judge.BLL.Impl;
using Online_Judge.DAL.Entities;
using Online_Judge.DAL;

namespace Online_Judge.Web.Controllers
{
    public class TestController : Controller
	{
		#region Dependencies

	    private readonly ITestService _testService;
	    private readonly IProblemService _problemService;

		#endregion

		public TestController()
		{
			var genericRepository = new GenericRepository(new OnlineJudgeDBContext());

			_testService = new TestService(genericRepository);
			_problemService = new ProblemService(genericRepository);
		}

	    //// GET: /Test/
		//public ActionResult Index()
		//{
		//	var tests = db.Tests.Include(t => t.Problem);
		//	return View(tests.ToList());
		//}

		//// GET: /Test/Details/5
		//public ActionResult Details(int? id)
		//{
		//	if (id == null)
		//	{
		//		return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		//	}
		//	Test test = db.Tests.Find(id);
		//	if (test == null)
		//	{
		//		return HttpNotFound();
		//	}
		//	return View(test);
		//}

        // GET: /Test/Create
        public ActionResult Create()
        {
            ViewBag.ProblemID = new SelectList(_problemService.GetAll(), "ProblemID", "Name");
            return View();
        }

        // POST: /Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TestID,ProblemID,Name,TimeLimit")] Test test)
        {
            if (ModelState.IsValid)
            {
                _testService.CreateTest(test);

                return RedirectToAction("Index");
            }

            ViewBag.ProblemID = new SelectList(_problemService.GetAll(), "ProblemID", "Name", test.ProblemID);
            return View(test);
        }

        // GET: /Test/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = _testService.GetTest(id.Value);

            if (test == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProblemID = new SelectList(_problemService.GetAll(), "ProblemID", "Name", test.ProblemID);
            return View(test);
        }

        // POST: /Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TestID,ProblemID,Name,TimeLimit")] Test test)
        {
            if (ModelState.IsValid)
            {
				_testService.UpdateTest(test);

                return RedirectToAction("Index");
            }

            ViewBag.ProblemID = new SelectList(_problemService.GetAll(), "ProblemID", "Name", test.ProblemID);

            return View(test);
        }

        // GET: /Test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

	        var test = _testService.GetTest(id.Value);

            if (test == null)
            {
                return HttpNotFound();
            }

            return View(test);
        }

        // POST: /Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _testService.DeleteTest(id);

            return RedirectToAction("Index");
        }
    }
}
