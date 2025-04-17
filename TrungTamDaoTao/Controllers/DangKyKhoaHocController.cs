using Microsoft.AspNetCore.Mvc;
using TrungTamDaoTao.Data;
using TrungTamDaoTao.Models;
using Microsoft.EntityFrameworkCore;

namespace TrungTamDaoTao.Controllers
{
    public class DangKyKhoaHocController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DangKyKhoaHocController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách tất cả các khóa học và thông tin đăng ký
        public async Task<IActionResult> Index()
        {
            var khoaHocs = await _context.KhoaHocs
                .Include(k => k.DangKyKhoaHocs)
                .ThenInclude(d => d.User) // Đưa thông tin học viên
                .ToListAsync();
            return View(khoaHocs);
        }

        // Đăng ký khóa học cho học viên
        [HttpPost]
        public async Task<IActionResult> Register(string maKhoaHoc, string maHocVien)
        {
            // Tìm khóa học với maKhoaHoc
            
            var khoaHoc = await _context.KhoaHocs
                .FirstOrDefaultAsync(k => k.MaKhoaHoc == maKhoaHoc);

            if (khoaHoc == null)
            {
                TempData["ErrorMessage"] = "Khóa học không tồn tại!";
                return RedirectToAction(nameof(Index));
            }

            // Kiểm tra xem số lượng học viên hiện tại có vượt quá giới hạn không
            if (khoaHoc.SoLuongHocVienHienTai >= khoaHoc.SoLuongHocVien)
            {
                TempData["ErrorMessage"] = "Khóa học đã đầy, không thể đăng ký thêm!";
                return RedirectToAction(nameof(Index));
            }

            // Kiểm tra xem học viên đã đăng ký khóa học này chưa
            var existingRegistration = await _context.DangKyKhoaHocs
                .FirstOrDefaultAsync(d => d.MaKhoaHoc == maKhoaHoc && d.MaHocVien == maHocVien);

            if (existingRegistration != null)
            {
                TempData["ErrorMessage"] = "Bạn đã đăng ký khóa học này rồi!";
                return RedirectToAction(nameof(Index));
            }

            // Thực hiện đăng ký mới
            var dangKy = new DangKyKhoaHoc
            {
                MaKhoaHoc = maKhoaHoc,
                MaHocVien = maHocVien,
                NgayDangKy = DateTime.Now
            };

            // Thêm đăng ký vào cơ sở dữ liệu
            _context.DangKyKhoaHocs.Add(dangKy);

            // Cập nhật số lượng học viên hiện tại của khóa học
            khoaHoc.SoLuongHocVienHienTai += 1;
            _context.Update(khoaHoc); // Cập nhật khóa học

            await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu

            TempData["SuccessMessage"] = "Đăng ký khóa học thành công!";
            return RedirectToAction(nameof(Index));
        }

        // Huỷ đăng ký khóa học
        [HttpPost]
        public async Task<IActionResult> Unregister(int maKhoaHoc, int maHocVien)
        {
            // Tìm khóa học với maKhoaHoc
            var khoaHoc = await _context.KhoaHocs
                .FirstOrDefaultAsync(k => k.MaKhoaHoc == maKhoaHoc);

            if (khoaHoc == null)
            {
                TempData["ErrorMessage"] = "Khóa học không tồn tại!";
                return RedirectToAction(nameof(Index));
            }

            // Tìm đăng ký của học viên
            var registration = await _context.DangKyKhoaHocs
                .FirstOrDefaultAsync(d => d.MaKhoaHoc == maKhoaHoc && d.MaHocVien == maHocVien);

            if (registration == null)
            {
                TempData["ErrorMessage"] = "Bạn chưa đăng ký khóa học này!";
                return RedirectToAction(nameof(Index));
            }

            // Huỷ đăng ký
            _context.DangKyKhoaHocs.Remove(registration);

            // Cập nhật số lượng học viên hiện tại của khóa học
            khoaHoc.SoLuongHocVienHienTai -= 1;
            _context.Update(khoaHoc); // Cập nhật khóa học

            await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu

            TempData["SuccessMessage"] = "Huỷ đăng ký thành công!";
            return RedirectToAction(nameof(Index));
        }

    }
}
