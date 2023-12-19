using Microsoft.AspNetCore.Mvc;
using WebAppApi.Models;

namespace WebAppApi.Controllers
{
    [Route("api/[controller]")]
    public class PairController:ControllerBase
    {
        private readonly DataContext db;
        public PairController(DataContext context)
        {
            this.db = context;
        }
        [HttpGet]
        public IEnumerable<Pair> GetPairs()
        {
            return db.Pairs.ToList();
        }
        [HttpPost]
        public void SavePair([FromBody] Pair pair)
        {
            db.Pairs.Add(pair);
            db.SaveChanges();
        }
        [HttpPut]
        public void UpdatePair([FromBody] Pair pair)
        {
            db.Pairs.Update(pair);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeletePair(long id)
        {
            db.Pairs.Remove(db.Pairs.Where(p => p.IdPair == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
