﻿using System.ComponentModel.DataAnnotations;

public class ResetPasswordViewModel
{
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string NewPassword { get; set; }

    [Required]
    [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp.")]
    public string ConfirmPassword { get; set; }
}
