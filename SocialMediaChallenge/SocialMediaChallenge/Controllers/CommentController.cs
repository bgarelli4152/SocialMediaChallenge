using SocialMediaChallenge.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SocialMediaChallenge.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> Post(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Comment> listOfComments = await _context.Comments.ToListAsync();
            return Ok(listOfComments);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetByID([FromUri] int id)
        {
            Comment foundComment = await _context.Comments.FindAsync(id);
            if (foundComment == null)
            {
                return NotFound();
            }
            return Ok(foundComment);
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromUri] Guid id, [FromBody] Comment model)
        {
            if (ModelState.IsValid)
            {
                if (id != model.ID)
                {
                    return BadRequest("Poster/Comment mismatch");
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
            var foundComment = await _context.Comments.FindAsync(id);
            if (foundComment == null)
            {
                return NotFound();
            }
            _context.Comments.Remove(foundComment);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
