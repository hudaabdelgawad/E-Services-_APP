using Core.Dots;
namespace Core.Entities
{
    public class ClientRequest:BaseEntity<int>
    {
     
        public DateTime  RequestDate { get; set; }
        public String Description { get; set; }
        public int ServiceId { get; set; }
        public string ClientId { get; set; }
        public int ServiceDetailsId { get; set; }
        public ApplicationUser Client { get; set; }
        public Service Service { get; set; }
      
        public ServiceDetails ServiceDetails { get; set; }
    }
}
