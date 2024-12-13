using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevXuongMoc.Models;

public partial class Order
{
    public int Id { get; set; }

    public string Idorders { get; set; } = null!;
    [Display(Name = "Ngày tạo")]
    public DateTime? OrdersDate { get; set; }

    public int Idcustomer { get; set; }

    public int? Idpayment { get; set; }

    public decimal TotalMoney { get; set; }
    [Display(Name = "Nội dung")]
    public string? Notes { get; set; }

    public string? NameReceiver { get; set; }
    [Display(Name = "Địa chỉ")]
    public string? Address { get; set; }

    public string? Email { get; set; }
    [Display(Name = "Số điện thoại")]
    public string? Phone { get; set; }

    public bool? Isdelete { get; set; }
    [Display(Name = "Trạng thái hoạt động")]
    public bool? Isactive { get; set; }

    public virtual Customer IdcustomerNavigation { get; set; } = null!;

    public virtual ICollection<OrdersDetail> OrdersDetails { get; set; } = new List<OrdersDetail>();
}
