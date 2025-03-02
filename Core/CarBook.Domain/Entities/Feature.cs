namespace CarBook.Domain.Entities
{
    public class Feature
    {
        public int FeatureID { get; set; }
        public string Name { get; set; }

        // Relationship
        public List<CarFeature> CarFeatures { get; set; }
    }
}
