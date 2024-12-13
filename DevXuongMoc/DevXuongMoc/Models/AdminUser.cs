using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace DevXuongMoc.Models;

public partial class AdminUser
{
    public int Id { get; set; }
    [Display(Name ="Tài khoản")]
    public string? Account { get; set; }
    [Display(Name = "Mật khẩu")]
    public string? Password { get; set; }

    public int? MaNhanSu { get; set; }
    [Display(Name = "Tên")]
    public string? Name { get; set; }
    [Display(Name = "Số điện thoại")]
    public string? Phone { get; set; }

    public string? Email { get; set; }
    [Display(Name = "Ảnh đại diện")]
    public string? Avatar { get; set; }

    public int? IdPhongBan { get; set; }
    [Display(Name = "Ngày Tạo")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? NgayTao { get; set; }

    public string? NguoiTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public string? NguoiCapNhat { get; set; }

    public string? SessionToken { get; set; }

    public string? Salt { get; set; }

    public bool? IsAdmin { get; set; }
    [Display(Name = "Trạng thái")]
    public int? TrangThai { get; set; }

    public bool? IsDelete { get; set; }
}
