using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.Sign_in;

namespace TravellingCore.ModelsServiceRepository.SigninRepository
{
    public interface ISigninuserRepository
    {
        public Task<IActionResult> Create(SigninInputDTO signin);
    }
}
