namespace CarBook.Dto.CarPricingDTOs
{
    public class ResultCarPricingWithCarsDTO
    {
        public int CarPricingID { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public decimal Amount { get; set; }
        public string CoverImageURL { get; set; }
        public string PricingName { get; set; }
    }
}
