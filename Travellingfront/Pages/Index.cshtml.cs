using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Dto.NewPlace;
using TravellingCore.Dto.Popular;
using TravellingCore.Dto.View;
using TravellingCore.Services.Models.Services.TuristPlaceService;

namespace Travellingfront.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITuristPlaceService turistPlaceService;

        [BindProperty]
        public List<ViewOutputDto> VisitedList { get; set; }
        [BindProperty]
        public List<PopularOutputDto> PopularList { get; set; }
        [BindProperty]
        public NewListInputDTO Newplaces { get; set; }

        public IndexModel(ILogger<IndexModel> logger ,
                         ITuristPlaceService turistPlaceService )
        {
            _logger = logger;
            this.turistPlaceService = turistPlaceService;
        }

        public async Task OnGet()
        {
            VisitedList = await turistPlaceService.ShowVisit();
            PopularList = await turistPlaceService.ShowPopular();
            Newplaces = await turistPlaceService.NewPlaces(); 
        }
    }
}
