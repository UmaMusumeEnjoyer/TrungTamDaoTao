using Microsoft.AspNetCore.Mvc;
using TrungTamDaoTao.Data;
using TrungTamDaoTao.Models;

namespace TrungTamDaoTao.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // Kiểm tra xem người dùng có phải là User không
            if (HttpContext.Session.GetString("Role") != "User")
            {
                return RedirectToAction("Login", "Account");
            }

            // Nội dung cho User
            ViewBag.Message = "Chào mừng User!";
            return View();
        }

        // GET: User/Edit
        public IActionResult Edit()
        {
            // Lấy thông tin người dùng từ session (hoặc từ User.Identity.Name nếu đã đăng nhập)
            var username = HttpContext.Session.GetString("TaiKhoan");  // Lấy tên tài khoản người dùng hiện tại
            var user = _context.Users.FirstOrDefault(u => u.TaiKhoan == username);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);  // Trả về view với dữ liệu người dùng
        }

        // POST: User/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User model)
        {
            if (ModelState.IsValid)
            {
                // Tìm người dùng trong cơ sở dữ liệu dựa trên tên tài khoản
                var user = _context.Users.FirstOrDefault(u => u.TaiKhoan == model.TaiKhoan);

                if (user != null)
                {
                    // Cập nhật thông tin người dùng
                    user.HoTen = model.HoTen;
                    user.NgaySinh = model.NgaySinh;
                    user.SoDienThoai = model.SoDienThoai;
                    user.Email = model.Email;
                    user.MatKhau = model.MatKhau;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    _context.SaveChanges();
                    return RedirectToAction("Index", "User"); // Quay lại trang người dùng sau khi cập nhật
                }

                return NotFound();
            }

            // Nếu có lỗi trong quá trình xác thực model
            return View(model);
        }
    }
}
