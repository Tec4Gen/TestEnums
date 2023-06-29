using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Takara.Infra.EF;

namespace PgMapEnumsTestApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EnumsTestController : ControllerBase
	{
		private readonly MyDbContext _myDbContext;
		public EnumsTestController(MyDbContext myDbContext)
		{
			_myDbContext = myDbContext;
		}

		[HttpGet(Name = "GetUser")]
		public async Task<IActionResult> Get()
		{
			var user = await _myDbContext.Users.FirstOrDefaultAsync(user => user.Id == 1);

			return Ok(user);
		}
	}
}