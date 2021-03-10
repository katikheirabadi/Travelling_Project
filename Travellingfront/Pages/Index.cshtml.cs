using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Dto.NewPlace;
using TravellingCore.Dto.Popular;
using TravellingCore.Dto.SearchByTuristPlaceName;
using TravellingCore.Dto.View;
using TravellingCore.Services.Models.Services.SearchServise;
using TravellingCore.Services.Models.Services.TuristPlaceService;

namespace Travellingfront.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITuristPlaceService turistPlaceService;
        public readonly ISearchservise searchservise;

        [BindProperty]
        public List<ViewOutputDto> VisitedList { get; set; }
        [BindProperty]
        public List<PopularOutputDto> PopularList { get; set; }
        [BindProperty]
        public NewListInputDTO Newplaces { get; set; }

        [BindProperty]
        public TuristPlaceInputDto PlaceSearch { get; set; }

        [BindProperty]
        public TuristPlaceOutputDto ResultPlaceSearch { get; set; }
        
        public bool State { get; set; }

        public IndexModel(ILogger<IndexModel> logger ,
                         ITuristPlaceService turistPlaceService,
                         ISearchservise searchservise)
        {
            _logger = logger;
            this.turistPlaceService = turistPlaceService;
            this.searchservise = searchservise;

        }

        public async Task OnGet()
        {
            VisitedList = await turistPlaceService.ShowVisit();
            PopularList = await turistPlaceService.ShowPopular();
            Newplaces = await turistPlaceService.NewPlaces();
           
        }
        public async Task<IActionResult> OnPost()
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                else
                {
                    ResultPlaceSearch = await searchservise.SearchByName(PlaceSearch);
                    State = true;
                    return Page();
                }
                
            }
            catch (Exception e)
            {

                State = false;
                ViewData["Error"] = e.Message;
                return Page();
            }
            
        }
    }
}
