using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using NuGet.Protocol.Plugins;
using TrungTamDaoTao.Data;
using TrungTamDaoTao.Models;
using TrungTamDaoTao.ViewModels;

namespace TrungTamDaoTao.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Trang đăng nhập (GET)
        public IActionResult Login()
        {
            return View();
        }

        // Xử lý đăng nhập (POST)
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Tìm người dùng trong cơ sở dữ liệu giả lập
                var user = _context.Users.FirstOrDefault(a => a.TaiKhoan == model.Username && a.MatKhau == model.Password);

                if (user != null)
                {
                    // Lưu thông tin người dùng vào session
                    HttpContext.Session.SetString("Username", user.TaiKhoan);
                    HttpContext.Session.SetString("Role", user.Role);

                    // Điều hướng đến trang phù hợp với vai trò người dùng
                    if (user.Role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
                else
                {
                    return View(model);
                }
            }

            return View(model);
        }

        // Trang đăng xuất (GET)
        public IActionResult Logout()
        {
            // Xóa session khi đăng xuất
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem tên tài khoản đã tồn tại chưa
                var existingUser = _context.Users.FirstOrDefault(u => u.TaiKhoan == model.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "Tên tài khoản đã tồn tại.");
                    return View(model);
                }

                // Tạo người dùng mới
                var user = new User
                {
                    TaiKhoan = model.Username,
                    MatKhau = model.Password, // Lưu mật khẩu theo dạng plain text, nên dùng mã hóa (hashing) mật khẩu trước khi lưu
                    Email = model.Email,
                    SoDienThoai = model.Phone,
                    Role = "User" // Mặc định là User, có thể tùy chỉnh nếu cần
                };

                // Thêm người dùng vào cơ sở dữ liệu
                _context.Users.Add(user);
                _context.SaveChanges();

                // Chuyển hướng người dùng đến trang đăng nhập hoặc trang chính
                return RedirectToAction("Login", "Account");
            }

            // Nếu có lỗi, trả về view đăng ký với các lỗi
            return View(model);
        }

    }
}

