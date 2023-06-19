using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prjMvcCoreDemo.Models;

public partial class TCustomer
{
    public int FId { get; set; }

    [Display(Name = "客戶姓名")]
    public string? FName { get; set; }

    [Display(Name = "手機號碼")]
    public string? FPhone { get; set; }

    [Display(Name = "Email")]
    public string? FEmail { get; set; }

    [Display(Name = "地址")]
    public string? FAddress { get; set; }

    [Display(Name = "密碼")]
    public string? FPassword { get; set; }
}
