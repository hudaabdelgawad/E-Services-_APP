using Core.Interfaces;
using Core.Dots;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
namespace WebServices.Controllers
{
 
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _uOW;
       
        public HomeController(IUnitOfWork UOW )
        {
            _uOW = UOW;
           
        }

        public async Task<ActionResult> Index()
        {
           

            return View(new ServiceItemDto
            {
                Services = (List<Service>)await _uOW.ServiceRepository.GetAllAsync(),
                ServiceDetails = (List<ServiceDetails>)await _uOW.ServiceDetailsRepository.GetAllAsync(x=>x.Service)
            });

           

           



        }
       
    }
}

