
namespace Core.Entities
{
    public class ServiceDetails:BaseEntity<int>
    {
       // public int Id { get; set; }
        public string ServiceFeatures { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
