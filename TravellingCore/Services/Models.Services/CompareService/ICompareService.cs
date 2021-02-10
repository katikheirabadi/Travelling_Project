using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TravellingCore.Services.Models.Services.CompareService
{
    public interface ICompareService
    {
        public Task<string> CompareAttraction(string firstAttraction, string secondAttraction);
    }
}
