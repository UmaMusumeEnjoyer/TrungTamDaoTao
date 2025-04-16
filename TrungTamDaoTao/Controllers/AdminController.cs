using Microsoft.AspNetCore.Mvc;

namespace TrungTamDaoTao.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            // Kiểm tra xem người dùng có phải là Admin không
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            // Nội dung cho Admin
            ViewBag.Message = "Chào mừng Admin!";
            return View();
        }
    }
}
