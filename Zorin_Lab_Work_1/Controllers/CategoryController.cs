using FoodStore.Data;
using Microsoft.AspNetCore.Mvc;
using Zorin_Lab_Work_1.Models;

namespace Zorin_Lab_Work_1.Controllers
{
    public class CategoryController : Controller
    {
        // Переменная контекста для доступа к базе данных
        private readonly ApplicationDbContext _db;

        // Внедряем зависимость ApplicationDbContext через конструктор
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // Создаем список записей категорий из базы данных
            IEnumerable<Category> categoryList = _db.Category;
            // Возвращаем загруженный список в представление
            return View(categoryList);
            //GET - CREATE
            public IActionResult Create()
            {
                return View();
            }


            //POST - CREATE
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Category cat)
            {

                _db.Category.Add(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }


            //GET - EDIT
            public IActionResult Edit(int? id)
            {
                return View();
            }


            //GET - DELETE
            public IActionResult Delete(int? id)
            {
                return View();
            }

            //POST - DELETE
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult DeletePost(int? id)
            {
                var cat = _db.Category.Find(id);
                if (cat == null)
                {
                    return NotFound();
                }
                _db.Category.Remove(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
        }
}