using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Entity;
using Services;
using Microsoft.AspNetCore.Identity;

namespace ReadLater5.Controllers
{
    public class BookmarksController : Controller
    {
        IBookmarkService _bookmarkService;
        ReadLaterDataContext _ReadLaterDataContext;
        UserManager<IdentityUser> _userManager;

        public BookmarksController(IBookmarkService bookmarkService, ReadLaterDataContext readLaterDataContext, UserManager<IdentityUser> userManager)
        {
            _bookmarkService = bookmarkService;
            _ReadLaterDataContext = readLaterDataContext;
            _userManager = userManager;
        }

        // GET: Bookmarks
        public IActionResult Index()
        {

            var userId = _userManager.GetUserId(User);
            var model = _bookmarkService.GetBookmarks().Where(q => q.UserId == userId).ToList();
         
            return View(model);
        }


        // GET: Bookmarks/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }
            Bookmark bookmark = _bookmarkService.GetBookmarkById((int)id);
            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            return View(bookmark);

        }

        // GET: Bookmarks/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_ReadLaterDataContext.Categories, "ID", "Name");
            return View();
        }

        // POST: Bookmarks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,URL,ShortDescription,CategoryId,CreateDate")] Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                bookmark.CreateDate = DateTime.Now;
                bookmark.UserId = userId;
                _bookmarkService.CreateBookmark(bookmark);
                return RedirectToAction("Index");
            }

            return View(bookmark);
        }

        // GET: Bookmarks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }

            ViewData["CategoryId"] = new SelectList(_ReadLaterDataContext.Categories, "ID", "Name");

            Bookmark bookmark = _bookmarkService.GetBookmarkById((int)id);
            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            return View(bookmark);
        }

        // POST: Bookmarks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,URL,ShortDescription,CategoryId,CreateDate")] Bookmark bookmark)
        {
            if (id != bookmark.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bookmarkService.UpdateBookmark(bookmark);
                return RedirectToAction("Index");
            }
            return View(bookmark);
        }

        // GET: Bookmarks/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }
            Bookmark bookmark = _bookmarkService.GetBookmarkById((int)id);
            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            return View(bookmark);
        }

        // POST: Bookmarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Bookmark bookmark = _bookmarkService.GetBookmarkById((int)id);
            _bookmarkService.DeleteBookmark(bookmark);
            return RedirectToAction("Index");
        }


        // GET: Bookmarks/Details/5
        public IActionResult Details_1(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }
            Bookmark bookmark = _bookmarkService.GetBookmarkById((int)id);
            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            return View(bookmark);

        }

        // GET: Bookmarks/Create
        public IActionResult Create_1()
        {
            ViewData["CategoryId"] = new SelectList(_ReadLaterDataContext.Categories, "ID", "Name");
            return View();
        }

        // POST: Bookmarks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create_1([Bind("ID,URL,ShortDescription,CategoryId,CreateDate")] Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                bookmark.CreateDate = DateTime.Now;
                _bookmarkService.CreateBookmark(bookmark);
                return RedirectToAction("Index", "Categories");
            }

            return View(bookmark);
        }

        // GET: Bookmarks/Edit/5
        public IActionResult Edit_1(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }

            ViewData["CategoryId"] = new SelectList(_ReadLaterDataContext.Categories, "ID", "Name");

            Bookmark bookmark = _bookmarkService.GetBookmarkById((int)id);
            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            return View(bookmark);
        }

        // POST: Bookmarks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit_1(int id, [Bind("ID,URL,ShortDescription,CategoryId,CreateDate")] Bookmark bookmark)
        {
            if (id != bookmark.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bookmarkService.UpdateBookmark(bookmark);
                return RedirectToAction("Index", "Categories");
            }
            return View(bookmark);
        }

        // GET: Bookmarks/Delete/5
        public IActionResult Delete_1(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }
            Bookmark bookmark = _bookmarkService.GetBookmarkById((int)id);
            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            return View(bookmark);
        }

        // POST: Bookmarks/Delete/5
        [HttpPost, ActionName("Delete_1")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed_1(int id)
        {
            Bookmark bookmark = _bookmarkService.GetBookmarkById((int)id);
            _bookmarkService.DeleteBookmark(bookmark);
            return RedirectToAction("Index", "Categories");
        }

    }
}
