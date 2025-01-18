using Lab2_DangThiAnhTuyet.Enums;

namespace Lab2_DangThiAnhTuyet.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string DeviceCode { get; set; }
        public Status EquipmentStatus { get; set; }
        public string DeviceImage { get; set; }
        public DateTime DateOfEntry { get; set; }
        public int CategoryId { get; set; }
        public int EmployeeId { get; set; }
        public Category Category { get; set; }
        public User Employee { get; set; }
    }
}
