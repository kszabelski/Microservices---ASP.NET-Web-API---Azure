using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MarketFinder.MakretManagementService.Models;

namespace MarketFinder.MakretManagementService.Controllers
{
    public class RatingsController : ApiController
    {
        private MarketManagementServiceContext db = new MarketManagementServiceContext();

        // GET: Ratings
        public async Task<List<Rating>> GetRatings()
        {
            return await db.Ratings.ToListAsync();
        }

        // GET: Ratings/5
        [ResponseType(typeof(Rating))]
        public async Task<IHttpActionResult> GetRating(int id)
        {
            Rating rating = await db.Ratings.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            return Ok(rating);
        }

        // PUT: Ratings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRating(int id, Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rating.Id)
            {
                return BadRequest();
            }

            db.Entry(rating).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: Ratings
        [ResponseType(typeof(Rating))]
        public async Task<IHttpActionResult> PostRating(Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ratings.Add(rating);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rating.Id }, rating);
        }

        // DELETE: Ratings/5
        [ResponseType(typeof(Rating))]
        public async Task<IHttpActionResult> DeleteRating(int id)
        {
            Rating rating = await db.Ratings.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            db.Ratings.Remove(rating);
            await db.SaveChangesAsync();

            return Ok(rating);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RatingExists(int id)
        {
            return db.Ratings.Count(e => e.Id == id) > 0;
        }
    }
}