using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrungTamDaoTao.Data;
namespace TrungTamDaoTao.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // Kiểm tra xem người dùng có phải là Admin không
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            var user = _db.Users.FirstOrDefault(u => u.MaHocVien == Convert.ToInt32(HttpContext.Session.GetString("MaHocVien")));
            // Nội dung cho Admin
            ViewBag.Message = "Chào mừng " + user.HoTen;
            return View();
        }

        public IActionResult Revenue()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }
            var khoaHocs = _db.KhoaHocs
                .Select(k => new
                {
                    k.MaKhoaHoc,
                    k.TenKhoaHoc,
                    k.GiangVien,
                    k.HocPhi,
                    k.SoLuongHocVienHienTai,
                    DoanhThu = k.HocPhi * k.SoLuongHocVienHienTai
                })
                .ToList();

            // Trả về kết quả dưới dạng View
            return View(khoaHocs);
        }
    }
}
