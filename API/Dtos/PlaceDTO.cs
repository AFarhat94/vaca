using Core.Entities;

namespace API.Dtos
{
    public class PlaceDTO
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CoordinationsId { get; set; }
        public CoordinationsDTO Coordinations { get; set; }
        public List<Image> Images{ get; set; }
    }
}