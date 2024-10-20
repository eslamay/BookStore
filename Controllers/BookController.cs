using BookStore.Models.Domain;
using BookStore.Repositories.Absract;
using BookStore.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
	public class BookController : Controller
	{
		private readonly IBookService bookService;
		private readonly IAutherService authorService;
		private readonly IGenreService genreService;
		private readonly IPublisherService publisherService;
		public BookController(IBookService bookService, IGenreService genreService, IPublisherService publisherService, IAutherService authorService)
		{
			this.bookService = bookService;
			this.genreService = genreService;
			this.publisherService = publisherService;
			this.authorService = authorService;
		}
		public IActionResult Add()
		{
			var model = new Book();
			model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AutherName, Value = a.Id.ToString() }).ToList();
			model.PublisherList = publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString() }).ToList();
			model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() }).ToList();
			return View(model);
		}

		[HttpPost]
		public IActionResult Add(Book model)
		{
			model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AutherName, Value = a.Id.ToString(), Selected = a.Id == model.AutherId }).ToList();
			model.PublisherList = publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
			model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var result = bookService.Add(model);
			if (result)
			{
				TempData["msg"] = "Add Successfully";
				return RedirectToAction(nameof(Add));
			}
			TempData["msg"] = "Error has Occured on server side";
			return View(model);
		}

		public IActionResult Update(int id)
		{
			var model = bookService.FindById(id);
			model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AutherName, Value = a.Id.ToString(), Selected = a.Id == model.AutherId }).ToList();
			model.PublisherList = publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
			model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
			return View(model);
		}

		[HttpPost]
		public IActionResult Update(Book model)
		{
			model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AutherName, Value = a.Id.ToString(), Selected = a.Id == model.AutherId }).ToList();
			model.PublisherList = publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
			model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var result = bookService.Update(model);
			if (result)
			{
				TempData["msg"] = "Updated Successfully";
				return RedirectToAction(nameof(Add));
			}
			TempData["msg"] = "Error has Occured on server side";
			return View(model);
		}


		public IActionResult Delete(int id)
		{
			var result = bookService.Delete(id);
			return RedirectToAction("GetAll");
		}

		public IActionResult GetAll()
		{
			var data = bookService.GetAll();
			return View(data);
		}

	}
}
