using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly DataContext _db;

        public SubscriptionController(DataContext db )
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubscriptionUser>>> Get()
        {

            return await _db.SubscriptionUsers.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionUser>> Get(int id)
        {
            var user = await _db.SubscriptionUsers.FindAsync(id);
            if(user == null)
            {
                return NotFound("Users Not Found");
            }
                
            return (user);
        }

        [HttpPost]
        public async Task<ActionResult<List<SubscriptionUser>>> AddSubsUser(SubscriptionUser user)
        {
            _db.SubscriptionUsers.Add(user);
            await _db.SaveChangesAsync();
            return await _db.SubscriptionUsers.ToListAsync();
        }
        [HttpPut]
        public async Task<ActionResult<List<SubscriptionUser>>> UpdateSubsUser(SubscriptionUser userRequest)
        {
            var dbUser = await _db.SubscriptionUsers.FindAsync(userRequest.Id);
            if (dbUser == null)
                return BadRequest("Users Not Found");

            dbUser.FirstName = userRequest.FirstName;
            dbUser.LastName = userRequest.LastName;
            dbUser.Email = userRequest.Email;
            dbUser.Company = userRequest.Company;

            await _db.SaveChangesAsync();
            
            return await _db.SubscriptionUsers.ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SubscriptionUser>>> Delete(int id)
        {
            var dbUser = await _db.SubscriptionUsers.FindAsync(id);
            if (dbUser == null)
            {
                return NotFound("Users Not Found");
            }


            _db.SubscriptionUsers.Remove(dbUser);
            await _db.SaveChangesAsync();
            return await _db.SubscriptionUsers.ToListAsync();
        }

    }
}
