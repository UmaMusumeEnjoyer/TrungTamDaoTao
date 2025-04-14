using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrungTamDaoTao.Data;
using TrungTamDaoTao.Models;
using TrungTamDaoTao.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrungTamDaoTao.Controllers
{
    public class DangKyKhoaHocController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DangKyKhoaHocController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: DangKyKhoaHoc/Create
        public IActionResult Create()
        {
            // Lấy danh sách học viên và khóa học để đổ vào dropdown
            var hocVienList = _db.HocViens.Select(h => new SelectListItem
            {
                Value = h.MaHocVien.ToString(),
                Text = h.HoTen // Thay 'Name' bằng tên trường phù hợp trong bảng học viên
            }).ToList();

            var khoaHocList = _db.KhoaHocs.Select(k => new SelectListItem
            {
                Value = k.MaKhoaHoc.ToString(),
                Text = k.TenKhoaHoc// Thay 'Name' bằng tên trường phù hợp trong bảng khóa học
            }).ToList();

            var viewModel = new DangKyKhoaHocViewModel
            {
                HocViens = hocVienList,
                KhoaHocs = khoaHocList
            };

            return View(viewModel);
        }

        // POST: DangKyKhoaHoc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DangKyKhoaHocViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem học viên và khóa học đã có chưa
                var hocVien = _db.HocViens.FirstOrDefault(h => h.MaHocVien == viewModel.MaHocVien);
                var khoaHoc = _db.KhoaHocs.FirstOrDefault(k => k.MaKhoaHoc == viewModel.MaKhoaHoc);

                if (hocVien != null && khoaHoc != null)
                {
                    // Thêm đăng ký khóa học
                    var dangKyKhoaHoc = new DangKyKhoaHoc
                    {
                        MaHocVien = viewModel.MaHocVien,
                        MaKhoaHoc = viewModel.MaKhoaHoc,
                        NgayDangKy = viewModel.NgayDangKy
                    };

                    _db.DangKyKhoaHocs.Add(dangKyKhoaHoc);
                    _db.SaveChanges();

                    TempData["success"] = "Đăng ký khóa học thành công";
                    return RedirectToAction("Index"); // Chuyển hướng về danh sách hoặc trang chính
                }
                else
                {
                    TempData["error"] = "Học viên hoặc khóa học không hợp lệ!";
                }
            }

            // Nếu model không hợp lệ, trả lại view với các lựa chọn dropdown
            var hocVienList = _db.HocViens.Select(h => new SelectListItem
            {
                Value = h.MaHocVien.ToString(),
                Text = h.HoTen
            }).ToList();

            var khoaHocList = _db.KhoaHocs.Select(k => new SelectListItem
            {
                Value = k.MaKhoaHoc.ToString(),
                Text = k.TenKhoaHoc
            }).ToList();

            viewModel.HocViens = hocVienList;
            viewModel.KhoaHocs = khoaHocList;

            return View(viewModel);
        }

        // GET: DangKyKhoaHoc/Delete/{id}
        public IActionResult Delete(int id)
        {
            // Tìm đăng ký khóa học cần xóa
            var dangKyKhoaHoc = _db.DangKyKhoaHocs
                .Include(d => d.HocVien)
                .Include(d => d.KhoaHoc)
                .FirstOrDefault(d => d.MaHocVien == id);

            if (dangKyKhoaHoc != null)
            {
                // Trả về view để xác nhận xóa
                return View(dangKyKhoaHoc);
            }

            TempData["error"] = "Không tìm thấy đăng ký khóa học.";
            return RedirectToAction("Index");
        }

        // POST: DangKyKhoaHoc/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Tìm đăng ký khóa học
            var dangKyKhoaHoc = _db.DangKyKhoaHocs.FirstOrDefault(d => d.MaHocVien == id);

            if (dangKyKhoaHoc != null)
            {
                // Xóa đăng ký khóa học
                _db.DangKyKhoaHocs.Remove(dangKyKhoaHoc);
                _db.SaveChanges();

                TempData["success"] = "Đã hủy đăng ký khóa học thành công";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Không tìm thấy đăng ký để xóa.";
            return RedirectToAction("Index");
        }

        // GET: DangKyKhoaHoc/Index
        public IActionResult Index()
        {
            var danhSach = _db.DangKyKhoaHocs
                .Include(d => d.HocVien)
                .Include(d => d.KhoaHoc)
                .ToList();

            return View(danhSach);
        }
    }
}
