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
    public class ReplyController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> Post(Reply reply)
        {
            if (ModelState.IsValid)
            {
                _context.Replies.Add(reply);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Reply> listOfReplies= await _context.Replies.ToListAsync();
            return Ok(listOfReplies);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetByID([FromUri] int id)
        {
            Reply foundReply = await _context.Replies.FindAsync(id);
            if (foundReply == null)
            {
                return NotFound();
            }
            return Ok(foundReply);
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromUri] Guid id, [FromBody] Reply model)
        {
            if (ModelState.IsValid)
            {
                if (id != model.ID)
                {
                    return BadRequest("Poster/Reply mismatch");
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
            var foundReply = await _context.Replies.FindAsync(id);
            if (foundReply == null)
            {
                return NotFound();
            }
            _context.Replies.Remove(foundReply);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
