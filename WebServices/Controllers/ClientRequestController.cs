using AutoMapper;
using Azure.Core;
using Core.Dots;
using Core.Entities;
using Core.Interfaces;
using Infarstuructre.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace WebServices.Controllers
{

    [Authorize]
    public class ClientRequestController : Controller
    {
        private readonly IUnitOfWork _uOW;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly EServiceDbContext _context;


        public ClientRequestController(EServiceDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IUnitOfWork UOW, IMapper mapper)
        {
            _context = context;
            _uOW = UOW;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index(string name)
        {

            var UserId = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;

            var clientrequest = await _uOW.clienRequestRepository.GetAllAsync(UserId, c => c.Client, sd => sd.ServiceDetails, s => s.Service);

            return View(clientrequest);

        }
        public async Task<IActionResult> Details(int id)
        {
            var clientrequest = await _uOW.clienRequestRepository.GetByIdAsync(id, c => c.Client, sd => sd.ServiceDetails, s => s.Service);

            return View(clientrequest);
        }
        [HttpGet]
        public async Task<ActionResult> Create(int id)
        {
            var serviceDetails = await _uOW.ServiceDetailsRepository.GetByIdAsync(id, x => x.Service);
            ViewBag.ServiceId = serviceDetails.ServiceId;
            ViewBag.ServicedetailsId = serviceDetails.Id;
            ViewBag.Servicedetails = serviceDetails.ServiceFeatures;
            ViewBag.Date = DateTime.Now;
            return View();


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClientRequestView model)
        {
            var UserId = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (ModelState.IsValid)
            {
                ClientRequest clientrequest = new()
                { 
                    RequestDate = DateTime.Now,
                    Description = model.Description,
                    ServiceId = model.ServiceId,
                    ServiceDetailsId = model.ServiceDetailsId,
                    ClientId = model.ClientId


                };
                await _uOW.clienRequestRepository.AddAsync(clientrequest);
                var exitinguser = await _userManager.FindByIdAsync(model.ClientId);
                if (exitinguser != null)
                {
                    exitinguser.FullName = model.FullName;
                    exitinguser.Gender = model.Gender;
                    var result = await _userManager.UpdateAsync(exitinguser);
                }
                return RedirectToAction("Index", "ClientRequest");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int id)

        {

            ViewBag.Servicedetails = await _uOW.ServiceDetailsRepository.GetAllAsync(x => x.Service);
            
          
            var clientrequest = await _uOW.clienRequestRepository.GetByIdAsync(id, x => x.Service, sd => sd.ServiceDetails, c => c.Client);
            ViewBag.Servicedetail = clientrequest.ServiceDetails.ServiceFeatures;
            if (clientrequest is null)
                return NotFound();
            ClientRequestView viewModel = new()
            {
                Id = id,

                RequestDate = DateTime.Now,
                Description = clientrequest.Description,
                ServiceId = clientrequest.ServiceId,
                ServiceDetailsId = clientrequest.ServiceDetailsId,
                ClientId = clientrequest.ClientId,
                FullName = clientrequest.Client.FullName,
                Gender = clientrequest.Client.Gender,

            };

            return View(viewModel);
        }

           
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Edit(int id, ClientRequestView model)
            {

                if (!ModelState.IsValid)
                {
                ViewBag.Servicedetails = await _uOW.ServiceDetailsRepository.GetAllAsync(x => x.Service);


                return View(model);
                }

                var clientrequest = await _uOW.clienRequestRepository.UpdateAsync(id, model);
                var exitinguser = await _userManager.FindByIdAsync(model.ClientId);
                if (exitinguser != null)
                {
                    exitinguser.FullName = model.FullName;
                    exitinguser.Gender = model.Gender;
                    var result = await _userManager.UpdateAsync(exitinguser);
                }
                return RedirectToAction(nameof(Index));
            }














            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var isDeleted = _uOW.clienRequestRepository.Delete(id);
                return Ok();

                // return isDeleted ? Ok() : BadRequest();
            }

        }
    } 
