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
    public class MarketsController : ApiController
    {
        private MarketManagementServiceContext db = new MarketManagementServiceContext();

        // GET: Markets
        public async Task<List<Market>> GetMarkets()
        {
            return await db.Markets.ToListAsync();
        }

        // GET: Markets/5
        [ResponseType(typeof(Market))]
        public async Task<IHttpActionResult> GetMarket(int id)
        {
            Market market = await db.Markets.FindAsync(id);
            if (market == null)
            {
                return NotFound();
            }

            return Ok(market);
        }

        // PUT: Markets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMarket(int id, [FromBody]Market market)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != market.Id)
            {
                return BadRequest();
            }

            db.Entry(market).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketExists(id))
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

        // POST: Markets
        [ResponseType(typeof(Market))]
        public async Task<IHttpActionResult> PostMarket(Market market)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Markets.Add(market);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = market.Id }, market);
        }

        // DELETE: Markets/5
        [ResponseType(typeof(Market))]
        public async Task<IHttpActionResult> DeleteMarket(int id)
        {
            Market market = await db.Markets.FindAsync(id);
            if (market == null)
            {
                return NotFound();
            }

            db.Markets.Remove(market);
            await db.SaveChangesAsync();

            return Ok(market);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MarketExists(int id)
        {
            return db.Markets.Count(e => e.Id == id) > 0;
        }
    }
}