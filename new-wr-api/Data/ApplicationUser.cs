﻿using Microsoft.AspNetCore.Identity;

namespace new_wr_api.Data
{
    public partial class ApplicationUser : IdentityUser
    {
        public string? PasswordSalt { get; set; }
        public string? FullName { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public string? CreatedUser { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public string? ModifiedUser { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}