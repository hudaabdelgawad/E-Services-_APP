using Core.Entities;
namespace Core.Dots
{
    public class ServiceDetailsDto
    {
        public int Id { get; set; }
        public string ServiceFeatures { get; set; }
        public string ServiceName { get; set; }
       

    }
    public class ServiceItemDto
    {
        public List<Service> Services { get; set; }
        public List<ServiceDetails> ServiceDetails { get; set; }
    }

}
