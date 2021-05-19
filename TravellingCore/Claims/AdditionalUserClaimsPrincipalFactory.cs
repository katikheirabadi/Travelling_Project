//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Model;

namespace TravellingCore.Claims
{
	public class AdditionalUserClaimsPrincipalFactory
		 : UserClaimsPrincipalFactory<User, IdentityRole>
	{
		public AdditionalUserClaimsPrincipalFactory(
			UserManager<User> userManager,
			RoleManager<IdentityRole> roleManager,
			IOptions<IdentityOptions> optionsAccessor)
			: base(userManager, roleManager, optionsAccessor)
		{ }

		public async override Task<ClaimsPrincipal> CreateAsync(User user)
		{
			var principal = await base.CreateAsync(user);
			var identity = (ClaimsIdentity)principal.Identity;
			var roles = await UserManager.GetRolesAsync(user);
			var claims = new List<Claim>();
			if (roles.Contains(AppRole.Admin.ToString()))
			{
				claims.Add(new Claim(ClaimTypes.Role, "admin"));
			}
			else
			{
				claims.Add(new Claim(ClaimTypes.Role, "user"));
			}

			identity.AddClaims(claims);
			return principal;
		}
	}
}
