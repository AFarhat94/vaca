namespace Core.Entities
{
    public class Location : EntityBase
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int PlaceId { get; set; }
    }
}