using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevXuongMoc.Models;

public partial class OrdersDetail
{
    public int Id { get; set; }

    public int Idord { get; set; }

    public int Idproduct { get; set; }
    [Display(Name = "Giá")]
    public decimal Price { get; set; }
    [Display(Name = "Số lượng")]
    public int Qty { get; set; }

    public decimal? Total { get; set; }

    public int? ReturnQty { get; set; }

    public virtual Order IdordNavigation { get; set; } = null!;

    public virtual Product IdproductNavigation { get; set; } = null!;
}
