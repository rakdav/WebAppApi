using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppApi.Models;

namespace WebAppApi.Controllers
{
    [Route("api/[controller]")]
    public class AcqsController : ControllerBase
    {
        private readonly DataContext db;
        public AcqsController(DataContext context)
        {
            this.db = context;
        }
        [HttpGet]
        public IEnumerable<Acq> GetAsqs()
        {
            return db.Acqs.ToList();
        }
        [HttpPost]
        public void SaveAsq([FromBody] Acq acq)
        {
            db.Acqs.Add(acq);
            db.SaveChanges();
        }
        [HttpPut]
        public async Task<ActionResult<Acq>> Put(Acq user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.Acqs.Any(x => x.IdAcq == user.IdAcq))
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
            db.Acqs.Remove(db.Acqs.Where(p => p.IdAcq == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
