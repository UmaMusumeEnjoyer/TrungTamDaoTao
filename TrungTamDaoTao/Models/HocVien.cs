using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrungTamDaoTao.Models
{
    public class HocVien
    {
        [Key]
        [DisplayName("Mã học viên")]
        public int MaHocVien { get; set; }    

        [DisplayName("Họ tên")]
        public string HoTen { get; set; }    

        [DisplayName("Ngày sinh")]
        public DateTime? NgaySinh { get; set; } 

        [DisplayName("Số điện thoại")]
        //[Required(ErrorMessage = "Số điện thoại không được để trống")]
        [RegularExpression(@"^0[0-9]{9,10}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string SoDienThoai { get; set; } 


        [DisplayName("Email")]
        //[Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }  

        [DisplayName("Username")]
        public string TaiKhoan { get; set; }  

        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }   


        // Điều hướng đến bảng DangKyKhoaHoc (mỗi học viên có thể đăng ký nhiều khóa học)
        public ICollection<DangKyKhoaHoc> DangKyKhoaHocs { get; set; }

        public HocVien()
        {
            DangKyKhoaHocs = new List<DangKyKhoaHoc>();
        }
    }
}
