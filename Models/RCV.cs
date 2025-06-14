namespace MrBin.Models
{
    public class RCV
    {
        public string? vehicleType { get; set; }
        public string? vehicleModelNumber { get; set; }
        public string? vehicleChassisNumber { get; set; }
        public string? vehicleEngineNumber { get; set; }
        public string? vehcleRegistrationNumber { get; set; }
        public string? vehicleFuelType { get; set; }
        public string? vehicleCapacity { get; set; }
        public DateOnly? vehicleYearOfManufacture { get; set; }
        public byte[]? vehicleRCV { get; set; }
        public byte[]? vehicleInsurance { get; set; }
        public byte[]? vehicleFitnessCertificate { get; set; }
    }
}