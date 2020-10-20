using SocialMediaChallenge.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SocialMediaChallenge.Controllers
{
    public class UserController : ApiController
    {
            private readonly ApplicationDbContext _context = new ApplicationDbContext();

            [HttpPost]
            public async Task<IHttpActionResult> Post(User user)
            {
                if (ModelState.IsValid)
                {
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            [HttpGet]
            public async Task<IHttpActionResult> GetAll()
            {
                List<User> listOfUsers = await _context.Users.ToListAsync();
                return Ok(listOfUsers);
            }
            [HttpGet]
            public async Task<IHttpActionResult> GetByID([FromUri] int id)
            {
                User foundCustomer = await _context.Users.FindAsync(id);
                if (foundCustomer == null)
                {
                    return NotFound();
                }
                return Ok(foundCustomer);
            }
            [HttpPut]
            public async Task<IHttpActionResult> Put([FromUri] int id, [FromBody] User model)
            {
                if (ModelState.IsValid)
                {
                    if (id != model.ID)
                    {
                        return BadRequest("Customer ID mismatch");
                    }
                    _context.Entry(model).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            [HttpDelete]
            public async Task<IHttpActionResult> Delete([FromUri] int id)
            {
                var foundUser = await _context.Users.FindAsync(id);
                if (foundUser == null)
                {
                    return NotFound();
                }
                _context.Users.Remove(foundUser);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
    }