using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prjMvcCoreDemo.Models;

public partial class TProduct
{
    public int FId { get; set; }

    [Display(Name = "商品名稱")]
    public string? FName { get; set; }

    [Display(Name = "數量")]
    public int? FQty { get; set; }

    [Display(Name = "成本")]
    public decimal? FCost { get; set; }

    [Display(Name = "價格")]
    public decimal? FPrice { get; set; }

    public string? FImagePath { get; set; }
    
}
