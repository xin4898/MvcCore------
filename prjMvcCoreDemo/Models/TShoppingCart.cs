using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prjMvcCoreDemo.Models;

public partial class TShoppingCart
{
    public int FId { get; set; }

    public string? FDate { get; set; }

    public int? FCustomerId { get; set; }

    public int? FProductId { get; set; }

    [Display(Name = "數量")]
    public int? FCount { get; set; }

    [Display(Name = "金額")]
    public decimal? FPrice { get; set; }
}
