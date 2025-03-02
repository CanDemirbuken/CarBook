namespace CarBook.Domain.Entities
{
    public class Pricing
    {
        public int PricingID { get; set; }
        public string Name { get; set; }

        // Relationship
        public List<CarPricing> CarPricings { get; set; }
    }
}
