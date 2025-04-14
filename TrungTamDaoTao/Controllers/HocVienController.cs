using Microsoft.AspNetCore.Mvc;
using TrungTamDaoTao.Data;
using TrungTamDaoTao.Models;

namespace TrungTamDaoTao.Controllers
{
    public class HocVienController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HocVienController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<User> hocVienList = _db.HocViens;
            return View(hocVienList);
        }

        //GET: HocVien/Create
        public IActionResult Create()
        {
            return View();
        }
        //POST: HocVien/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.HocViens.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Thêm học viên thành công";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET: HocVien/Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var hocVienFromDb = _db.HocViens.Find(id);
            if (hocVienFromDb == null)
            {
                return NotFound();
            }
            return View(hocVienFromDb);
        }
        //POST: HocVien/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.HocViens.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Cập nhật học viên thành công";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET: HocVien/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var hocVienFromDb = _db.HocViens.Find(id);
            if (hocVienFromDb == null)
            {
                return NotFound();
            }
            return View(hocVienFromDb);
        }
        //POST: HocVien/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(User obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            _db.HocViens.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Xóa học viên thành công";
            return RedirectToAction("Index");
        }


    }
}
