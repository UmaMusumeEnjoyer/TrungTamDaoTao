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
    }
}
