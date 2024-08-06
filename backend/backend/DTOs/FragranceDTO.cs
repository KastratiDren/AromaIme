namespace backend.Models
{
    public class FragranceDto
    {
        public string Name { get; set; } 
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Notes { get; set; } 
        public int Size { get; set; }
        public DateOnly LaunchDate { get; set; }
        public string Ingredients { get; set; }

        // Foreign Keys
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int GenderId { get; set; }
        public int LongevityId { get; set; }
        public int ScentId { get; set; }
        public int SeasonId { get; set; }
        public int SillageId { get; set; }
    }
}

