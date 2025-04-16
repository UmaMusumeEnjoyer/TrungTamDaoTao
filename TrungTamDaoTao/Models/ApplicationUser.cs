using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrungTamDaoTao.Models
{
    public class User
    {
        [Key]
        [DisplayName("Mã học viên")]
        public int MaHocVien { get; set; }    

        [DisplayName("Họ tên")]
        public string? HoTen { get; set; }    

        [DisplayName("Ngày sinh")]
        public DateTime? NgaySinh { get; set; } 

        [DisplayName("Số điện thoại")]

        [RegularExpression(@"^0[0-9]{9,10}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string SoDienThoai { get; set; } 


        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }  

        [DisplayName("Username")]
        public string TaiKhoan { get; set; }  

        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }

        public string Role { get; set; } = "User"; // Giá trị mặc định là "User"

        

        public ICollection<DangKyKhoaHoc>? DangKyKhoaHocs { get; set; }
    }
}
