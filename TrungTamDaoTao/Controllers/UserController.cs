using Microsoft.AspNetCore.Mvc;

namespace TrungTamDaoTao.Controllers
{
    public class UserController : Controller
    {
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
    }
}
