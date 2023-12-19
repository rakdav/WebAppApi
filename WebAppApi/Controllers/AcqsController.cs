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
        public void UpdateClient([FromBody] Acq acq)
        {
            db.Acqs.Update(acq);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteProduct(long id)
        {
            db.Acqs.Remove(db.Acqs.Where(p => p.IdAcq == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
