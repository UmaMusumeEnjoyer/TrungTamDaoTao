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
            IEnumerable<HocVien> hocVienList = _db.HocViens;
            return View(hocVienList);
        }
    }
}
