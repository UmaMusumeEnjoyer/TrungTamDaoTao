﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrungTamDaoTao.Data;
using TrungTamDaoTao.Models;

namespace TrungTamDaoTao.Controllers
{
    public class KhoaHocController : Controller
    {
        private readonly ApplicationDbContext _context;
        public KhoaHocController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            IEnumerable<KhoaHoc> khoaHocList = _context.KhoaHocs;
            return View(khoaHocList);
        }

        
        //GET: KhoaHoc/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        //POST: KhoaHoc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KhoaHoc obj)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }
            if (ModelState.IsValid)
            {
                var existingUser = _context.KhoaHocs.FirstOrDefault(u => u.TenKhoaHoc == obj.TenKhoaHoc);
                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "Khoá học đã tồn tại.");
                    return View(obj);
                }
                _context.KhoaHocs.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Thêm khóa học thành công";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        
        //GET: KhoaHoc/Edit
        public IActionResult Edit(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var khoaHocFromDb = _context.KhoaHocs.Find(id);
            if (khoaHocFromDb == null)
            {
                return NotFound();
            }
            return View(khoaHocFromDb);
        }
        //POST: KhoaHoc/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(KhoaHoc obj)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }
            if (ModelState.IsValid)
            {
                _context.KhoaHocs.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Cập nhật khóa học thành công";
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        //GET: KhoaHoc/Delete
        public IActionResult Delete(int? id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var khoaHocFromDb = _context.KhoaHocs.Find(id);
            if (khoaHocFromDb == null)
            {
                return NotFound();
            }
            return View(khoaHocFromDb);
        }
        //POST: KhoaHoc/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(KhoaHoc obj)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }
            if (obj == null)
            {
                return NotFound();
            }

            var khoaHocFromDb = _context.KhoaHocs.Find(obj.MaKhoaHoc);
            if (khoaHocFromDb == null)
            {
                return NotFound();
            }

            var khoaHocFromDb2 = _context.DangKyKhoaHocs.FirstOrDefault(u => u.MaKhoaHoc == obj.MaKhoaHoc);
            if (khoaHocFromDb2 != null)
            {
                ModelState.AddModelError(string.Empty, "Không thể xóa khóa học này vì có học viên đã đăng ký.");
                return View("Delete", khoaHocFromDb); 
            }

            _context.KhoaHocs.Remove(khoaHocFromDb);
            _context.SaveChanges();
            TempData["success"] = "Xóa khóa học thành công";
            return RedirectToAction("Index");
        }



    }
}
