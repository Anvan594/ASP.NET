using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevXuongMoc.Models;

public partial class Contact
{
    public int Id { get; set; }
    [Display(Name ="Tiêu đề")]
    public string? Title { get; set; }
    [Display(Name = "Gmail")]
    public string? Email { get; set; }
    [Display(Name = "Số điện thoại")]
    public string? Phone { get; set; }
    [Display(Name = "Địa chỉ")]
    public string? Address { get; set; }
    [Display(Name = "Nội dung")]
    public string? Content { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? AdminCreated { get; set; }

    public string? AdminUpdated { get; set; }
    [Display(Name = "Trạng thái")]
    public byte? Status { get; set; }

    public bool? Isdelete { get; set; }
}
