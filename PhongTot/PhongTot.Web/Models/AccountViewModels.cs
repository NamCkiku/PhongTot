using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhongTot.Web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Bạn vui lòng nhập tên email")]
        [Display(Name = "Email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Bạn phải nhập đúng định dạng email của bạn")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn vui lòng nhập tên email")]
        [Display(Name = "Email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Bạn phải nhập đúng định dạng email của bạn")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn vui lòng nhập mật khẩu")]
        [StringLength(100, ErrorMessage = "Mật khẩu {0} phải có ít nhất {2} kí tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bạn vui lòng nhập mật khẩu xác thực")]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Mật khẩu xác thực không phù hợp.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Bạn vui lòng nhập họ và tên đầy đủ")]
        [MaxLength(256, ErrorMessage = "Họ tên không được vượt quá 256 ký tự")]
        [Display(Name = "Họ tên")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Bạn vui lòng nhập địa chỉ của bạn")]
        [MaxLength(256, ErrorMessage = "Họ tên không được vượt quá 256 ký tự")]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        public string Avatar { get; set; }
        public DateTime? BirthDay { set; get; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
