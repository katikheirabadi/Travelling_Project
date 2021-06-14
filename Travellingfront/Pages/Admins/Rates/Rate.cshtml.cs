using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.Rate.GetAll;
using TravellingCore.Services.Models.Services.RateService;

namespace Travellingfront.Pages.Admins.Rates
{
    public class RateModel : PageModel
    {
        private readonly IRateService rateService;
        [BindProperty]
        public List<GetAllOutPutDto> Rates { get; set; }

        public RateModel(IRateService rateService)
        {
            this.rateService = rateService;
        }
        public async Task OnGet()
        {
            Rates = await rateService.GetAll();
        }
    }
}
