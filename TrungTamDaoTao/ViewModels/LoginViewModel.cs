using System.ComponentModel.DataAnnotations;

namespace TrungTamDaoTao.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Tên tài khoản là bắt buộc.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
