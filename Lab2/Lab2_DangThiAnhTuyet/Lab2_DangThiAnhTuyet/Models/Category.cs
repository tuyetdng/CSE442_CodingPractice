﻿namespace Lab2_DangThiAnhTuyet.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string CategoryImage { get; set; }
        public List<Device> Devices { get; set; }

    }
}