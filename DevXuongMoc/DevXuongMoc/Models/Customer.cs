using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevXuongMoc.Models;

public partial class Customer
{
    public int Id { get; set; }
    [Display(Name = "Tên")]
    public string Name { get; set; } = null!;
    [Display(Name = "Tài khoản")]
    public string Username { get; set; } = null!;
    [Display(Name = "Mật khẩu")]
    public string Password { get; set; } = null!;
    [Display(Name = "Địa chỉ")]
    public string? Address { get; set; }
    [Display(Name = "Gmail")]
    public string? Email { get; set; }
    [Display(Name = "Số điện thoại")]
    public string? Phone { get; set; }
    [Display(Name = "Ảnh đại diện")]
    public string? Avatar { get; set; }
    [Display(Name = "Ngày tạo")]
    public DateTime? CreatedDate { get; set; }
    [Display(Name = "Ngày chỉnh sửa")]
    public DateTime? UpdatedDate { get; set; }
    [Display(Name = "Người tạo")]
    public string? CreatedBy { get; set; }
    [Display(Name = "Người chỉnh sửa")]
    public string? UpdatedBy { get; set; }

    public bool? Isdelete { get; set; }
    [Display(Name = "Trạng thái hoạt động")]
    public bool? Isactive { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
