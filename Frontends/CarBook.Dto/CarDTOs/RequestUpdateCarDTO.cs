﻿namespace CarBook.Dto.CarDTOs
{
    public class RequestUpdateCarDTO
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmisson { get; set; }
        public byte Seat { get; set; }
        public string Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
    }
}
