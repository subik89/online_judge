using System.Net;
using System.Web.Mvc;
using Online_Judge.BLL;
using Online_Judge.BLL._Impl;
using Online_Judge.DAL;
using Online_Judge.DAL.Entities;

namespace Online_Judge.Web.Controllers
{
	public class SubmissionController : Controller
	{
		#region Dependencies

		private readonly ISubmissionService _submissionService;
		private readonly IProblemService _problemService;

		public SubmissionController()
		{
			var genericRepository = new GenericRepository(new OnlineJudgeDBContext());

			_submissionService = new SubmissionService(genericRepository);
			_problemService = new ProblemService(genericRepository);
		}

		#endregion

		// GET: /Submission/
		public ActionResult Index()
		{
			var submissions = _submissionService.GetSubmissions(2);

			return View(submissions);
		}

		// GET: /Submission/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var submission = _submissionService.GetSubmission(id.Value);

			if (submission == null)
			{
				return HttpNotFound();
			}

			return View(submission);
		}

		// GET: /Submission/Create
		public ActionResult Create()
		{
			ViewBag.ProblemID = new SelectList(_problemService.GetAll(), "ProblemID", "Name");

			return View();
		}

		// POST: /Submission/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "SubmissionID,ProblemID,Language,Code")] Submission submission)
		{
			if (ModelState.IsValid)
			{
				submission.UserID = 2;
				_submissionService.AddSubmission(submission);

				return RedirectToAction("Index");
			}

			ViewBag.ProblemID = new SelectList(_problemService.GetAll(), "ProblemID", "Name", submission.ProblemID);

			return View(submission);
		}

		// GET: /Submission/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var submission = _submissionService.GetSubmission(id.Value);

			if (submission == null)
			{
				return HttpNotFound();
			}

			ViewBag.ProblemID = new SelectList(_problemService.GetAll(), "ProblemID", "Name", submission.ProblemID);

			return View(submission);
		}

		// POST: /Submission/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "SubmissionID,ProblemID,Language,Code")] Submission submission)
		{
			if (ModelState.IsValid)
			{
				_submissionService.UpdateSubmission(submission);
				return RedirectToAction("Index");
			}

			ViewBag.ProblemID = new SelectList(_problemService.GetAll(), "ProblemID", "Name", submission.ProblemID);

			return View(submission);
		}

		// GET: /Submission/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			Submission submission = _submissionService.GetSubmission(id.Value);

			if (submission == null)
			{
				return HttpNotFound();
			}

			return View(submission);
		}

		// POST: /Submission/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			_submissionService.DeleteSubmission(id);

			return RedirectToAction("Index");
		}
	}
}
