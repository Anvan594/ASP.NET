using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevXuongMoc.Models;

public partial class Banner
{
    public int Id { get; set; }
    [Display(Name = "Ảnh")]
    public string? Image { get; set; }
    [Display(Name = "Tiêu đề")]
    public string? Title { get; set; }

    public string? SubTitle { get; set; }

    public string? Urls { get; set; }

    public int Orders { get; set; }

    public string? Type { get; set; }
    [Display(Name = "Ngày Tạo")]
    public DateTime? CreatedDate { get; set; }
    [Display(Name = "Ngày update")]
    public DateTime? UpdatedDate { get; set; }
    [Display(Name = "Người tạo")]
    public string? AdminCreated { get; set; }
    [Display(Name = "Người sửa")]
    public string? AdminUpdated { get; set; }
    [Display(Name = "Ghi chú")]
    public string? Notes { get; set; }
    [Display(Name = "Trạng thái")]
    public byte Status { get; set; }

    public bool Isdelete { get; set; }
}
