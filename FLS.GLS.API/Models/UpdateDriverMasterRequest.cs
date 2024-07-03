namespace FLS.GLS.API.Models
{
    public class UpdateDriverMasterRequest
    {
        public int Id { get; set; }
        public string DriverCode { get; set; } = null!;

        public string DriverName { get; set; } = null!;

        public string Company { get; set; } = null!;

        public string DrivingLiscencNo { get; set; } = null!;

        public DateTime ExpiryDate { get; set; }

        public string IdCopy { get; set; } = null!;

        public string MobileNo { get; set; } = null!;

        public string? TelNo { get; set; }

        public int EntryBy { get; set; }

        public DateTime EntryDate { get; set; }

        public string DriverNo { get; set; } = null!;

        public int TransporterMasterId { get; set; }

        public IFormFile? ImageBase64 { get; set; }
    }
}
