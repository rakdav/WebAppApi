using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppApi.Models;

namespace WebAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private DataContext db;
        public ClientController(DataContext ctx)
        {
            db = ctx;
        }
        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            return db.Clients.Where(p=>p.HasPair==false).ToList();
        }
        [HttpGet("{id}")]
        public Client GetClient (int id)
        {
            return db.Clients.Where(p => p.IdClient == id).FirstOrDefault()!;
        }
        [HttpPost]
        public void SaveClient([FromBody] Client client)
        {
            if (client != null)
            {
                db.Clients.Add(client);
                db.SaveChanges();
            }
        }
        [HttpPut]
        public async Task<ActionResult<Client>> Put(Client user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.Clients.Any(x => x.IdClient == user.IdClient))
            {
                return NotFound();
            }
            db.Update(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public void DeleteProduct(long id)
        {
            db.Clients.Remove(db.Clients.Where(p => p.IdClient == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
