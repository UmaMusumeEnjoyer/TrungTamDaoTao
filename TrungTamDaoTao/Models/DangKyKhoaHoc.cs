using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using TrungTamDaoTao.Models;
using TrungTamDaoTao.Controllers;

public class DangKyKhoaHoc
{
    [Key]
    [DisplayName("Mã đăng ký")]
    public int MaDangKy { get; set; } // Khóa chính (ID đăng ký)

    [ForeignKey("User")]
    [Required(ErrorMessage = "Vui lòng chọn học viên")]
    public int MaHocVien { get; set; }


    [ForeignKey("KhoaHoc")]
    [Required(ErrorMessage = "Vui lòng chọn khóa học")]
    public int MaKhoaHoc { get; set; }

    [DisplayName("Ngày đăng ký")]
    [DataType(DataType.Date)]
    public DateTime NgayDangKy { get; set; } = DateTime.Now;

    public KhoaHoc KhoaHoc { get; set; } // Điều hướng đến bảng KhoaHoc
    public User User { get; set; } // Điều hướng đến bảng User

}
