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

            var user = _context.Users.FirstOrDefault(u => u.MaHocVien == Convert.ToInt32(HttpContext.Session.GetString("MaHocVien")));

            // Kiểm tra nếu người dùng tồn tại
            if (user != null)
            {
                ViewBag.Message = "Chào mừng " + user.HoTen;
            }
            else
            {
                ViewBag.Message = "Người dùng không tồn tại!";
            }

            return View();
        }



        [HttpGet]
        // GET: User/Edit
        public IActionResult UserEdit()
        {
            // Kiểm tra xem session có tồn tại và có giá trị không
            var username = HttpContext.Session.GetString("MaHocVien");
            if (string.IsNullOrEmpty(username))
            {
                // Nếu session không tồn tại, trả về lỗi hoặc yêu cầu người dùng đăng nhập lại
                return RedirectToAction("Login", "Account");
            }

            var user = _context.Users.FirstOrDefault(u => u.MaHocVien == Convert.ToInt32(username));

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        // POST: User/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserEdit(User model)
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
