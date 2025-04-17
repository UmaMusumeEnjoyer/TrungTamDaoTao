﻿using Microsoft.AspNetCore.Authorization;
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
            IEnumerable<User> hocVienList = _db.Users;
            return View(hocVienList);
        }

        [Authorize(Roles = "Admin")]
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
                _db.Users.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Thêm học viên thành công";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [Authorize(Roles = "Admin")]
        //GET: HocVien/Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var hocVienFromDb = _db.Users.Find(id);
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
                _db.Users.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Cập nhật học viên thành công";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [Authorize(Roles = "Admin")]
        //GET: HocVien/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var hocVienFromDb = _db.Users.Find(id);
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
            _db.Users.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Xóa học viên thành công";
            return RedirectToAction("Index");
        }


    }
}
