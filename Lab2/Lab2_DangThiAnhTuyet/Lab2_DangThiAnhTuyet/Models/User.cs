﻿using Lab2_DangThiAnhTuyet.Enums;

namespace Lab2_DangThiAnhTuyet.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public Gender Gender { get; set; }

    }
}
