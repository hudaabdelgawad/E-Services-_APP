using Core.Entities;
namespace Core.Dots
{
    public class ClientRequestView:BaseEntity<int>
    {
        public DateTime RequestDate { get; set; }
        public String Description { get; set; }
        public String FullName { get; set; }
        public string Gender { get; set; }
        public int ServiceId { get; set; }
        public string ClientId { get; set; }

        public int ServiceDetailsId { get; set; }
        public ServiceDetails ServiceDetails { get; set; }
        public ApplicationUser Client { get; set; }
      
    }
   
    
   
}
