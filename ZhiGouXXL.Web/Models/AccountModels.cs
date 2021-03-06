﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using ZhiGouXXL.Core;

namespace ZhiGouXXL.Web.Models {
	public class UsersContext : DbContext {
		public UsersContext()
			: base("DefaultConnection") {
		}

		public DbSet<UserProfile> UserProfiles { get; set; }
	}

	[Table("UserProfile")]
	public class UserProfile {
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int UserId { get; set; }
		public string UserName { get; set; }

		public string Address { get; set; }
		public string Mobile { get; set; }
	}

	public class RegisterExternalLoginModel {
		[Required]
		[Display(Name = GlobalConstants.UserName)]
		public string UserName { get; set; }

		public string ExternalLoginData { get; set; }
	}

	public class LocalPasswordModel {
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = GlobalConstants.CurrentPassword)]
		public string OldPassword { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = GlobalConstants.NewPassword)]
		public string NewPassword { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = GlobalConstants.ConfirmNewPassword)]
		[Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }
	}

	public class LoginModel {
		[Required]
		[Display(Name = GlobalConstants.UserName)]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = GlobalConstants.Password)]
		public string Password { get; set; }

		[Display(Name = GlobalConstants.RememberMe)]
		public bool RememberMe { get; set; }
	}

	public class RegisterModel {
		[Required]
		[Display(Name = GlobalConstants.UserName)]
		public string UserName { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "{0} 长度需要大于 {2}.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = GlobalConstants.Password)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = GlobalConstants.ConfirmPassword)]
		[Compare("Password", ErrorMessage = "确认密码和原密码不相同.")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "请填写您的收件地址.")]
		[Display(Name = GlobalConstants.Address)]
		public string Address { get; set; }

		[Required(ErrorMessage = "请填写您的收件电话.")]
		[Display(Name = GlobalConstants.Mobile)]
		public string Mobile { get; set; }
	}

	public class ExternalLogin {
		public string Provider { get; set; }
		public string ProviderDisplayName { get; set; }
		public string ProviderUserId { get; set; }
	}
}
