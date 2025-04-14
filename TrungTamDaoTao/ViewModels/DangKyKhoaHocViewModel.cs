using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrungTamDaoTao.ViewModels
{
    public class DangKyKhoaHocViewModel
    {
        [DisplayName("Học viên")]
        [Required(ErrorMessage = "Vui lòng chọn học viên")]
        public int MaHocVien { get; set; }

        [DisplayName("Khóa học")]
        [Required(ErrorMessage = "Vui lòng chọn khóa học")]
        public int MaKhoaHoc { get; set; }

        [DisplayName("Ngày đăng ký")]
        [DataType(DataType.Date)]
        public DateTime NgayDangKy { get; set; } = DateTime.Now;

        // Dữ liệu cho dropdown
        public IEnumerable<SelectListItem> HocViens { get; set; }
        public IEnumerable<SelectListItem> KhoaHocs { get; set; }
    }
}
