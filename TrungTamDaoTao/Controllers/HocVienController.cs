using Microsoft.AspNetCore.Mvc;
using TrungTamDaoTao.Data;
using TrungTamDaoTao.Models;

public class HocVienController : Controller
{
    private readonly ApplicationDbContext _db;

    public HocVienController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<User> hocVienList = _db.Users;
        return View(hocVienList);
    }




    // Phân quyền cho hành động Create, Edit, Delete
    [HttpGet]
    public IActionResult Create()
    {
        if (!UserIsAdmin())
        {
            return Forbid(); // Nếu không phải Admin, trả về lỗi 403
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(User obj)
    {
        if (!UserIsAdmin())
        {
            return Forbid(); // Nếu không phải Admin, trả về lỗi 403
        }

        if (ModelState.IsValid)
        {
            _db.Users.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Thêm học viên thành công";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (!UserIsAdmin())
        {
            return Forbid(); // Nếu không phải Admin, trả về lỗi 403
        }
        var hocVienFromDb = _db.Users.Find(id);
        if (hocVienFromDb == null)
        {
            return NotFound();
        }
        return View(hocVienFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(User obj)
    {
        if (!UserIsAdmin())
        {
            return Forbid(); // Nếu không phải Admin, trả về lỗi 403
        }

        if (ModelState.IsValid)
        {
            _db.Users.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Cập nhật học viên thành công";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (!UserIsAdmin())
        {
            return Forbid(); // Nếu không phải Admin, trả về lỗi 403
        }

        var hocVienFromDb = _db.Users.Find(id);
        if (hocVienFromDb == null)
        {
            return NotFound();
        }
        return View(hocVienFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(User obj)
    {
        if (!UserIsAdmin())
        {
            return Forbid(); // Nếu không phải Admin, trả về lỗi 403
        }

        if (obj == null)
        {
            return NotFound();
        }
        _db.Users.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Xóa học viên thành công";
        return RedirectToAction("Index");
    }

    // Kiểm tra nếu người dùng có vai trò Admin
    private bool UserIsAdmin()
    {
        // Lấy thông tin người dùng hiện tại
        var userid = Convert.ToInt32(HttpContext.Session.GetString("MaHocVien"));

        // Tìm người dùng trong cơ sở dữ liệu
        var user = _db.Users.FirstOrDefault(u => u.MaHocVien == userid);

        // Kiểm tra nếu người dùng có vai trò Admin
        return user != null && user.Role == "Admin";
    }
}
