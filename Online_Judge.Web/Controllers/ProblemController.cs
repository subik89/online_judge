using System.Net;
using System.Web.Mvc;
using Online_Judge.BLL;
using Online_Judge.BLL._Impl;
using Online_Judge.DAL.Entities;
using Online_Judge.DAL;

namespace Online_Judge.Web.Controllers
{
	public class ProblemController : Controller
	{
		#region Dependencies

		private readonly IProblemService _problemService;

		#endregion

		//TODO: add IProblemService parameter to controller and use Unity
		/// <summary>
		/// Initializes a new instance of the <see cref="ProblemController"/> class.
		/// </summary>
		public ProblemController()
		{
			_problemService = new ProblemService(new GenericRepository(new OnlineJudgeDBContext()));
		}

		public ActionResult Index()
		{
			var problems = _problemService.GetAll();

			return View(problems);
		}

		// GET: /Problem/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var problem = _problemService.GetProblem(id.Value);

			if (problem == null)
			{
				return HttpNotFound();
			}
			return View(problem);
		}

		// GET: /Problem/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: /Problem/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ProblemID,Name,Title,Content")] Problem problem)
		{
			if (ModelState.IsValid)
			{
				_problemService.AddProblem(problem);

				return RedirectToAction("Index");
			}

			return View(problem);
		}

		// GET: /Problem/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var problem = _problemService.GetProblem(id.Value);

			if (problem == null)
			{
				return HttpNotFound();
			}

			return View(problem);
		}

		// POST: /Problem/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ProblemID,Name,Title,Content")] Problem problem)
		{
			if (ModelState.IsValid)
			{
				_problemService.Update(problem);
				return RedirectToAction("Index");
			}

			return View(problem);
		}

		// GET: /Problem/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var problem = _problemService.GetProblem(id.Value);

			if (problem == null)
			{
				return HttpNotFound();
			}

			return View(problem);
		}

		// POST: /Problem/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			_problemService.Delete(id);

			return RedirectToAction("Index");
		}
	}
}
