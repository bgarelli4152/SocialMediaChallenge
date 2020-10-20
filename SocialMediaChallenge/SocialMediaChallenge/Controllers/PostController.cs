using SocialMediaChallenge.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace SocialMediaChallenge.Controllers
{
    public class PostController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> Post(Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Post> listOfPosts = await _context.Posts.ToListAsync();
            return Ok(listOfPosts);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetByID([FromUri] int id)
        {
            Post foundPost = await _context.Posts.FindAsync(id);
            if (foundPost == null)
            {
                return NotFound();
            }
            return Ok(foundPost);
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromUri] Guid id, [FromBody] Post model)
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
            var foundPost = await _context.Posts.FindAsync(id);
            if (foundPost == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(foundPost);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}