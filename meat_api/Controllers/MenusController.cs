﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using meat_api.Models;

namespace meat_api.Controllers
{
    [RoutePrefix("api/menus")]
    public class MenusController : ApiController
    {
        private AppDbContext db = new AppDbContext();
        

        [HttpGet]
        [Route("all")]
        public IQueryable<Menu> GetMenus()
        {
            return db.Menus;
        }

        [ResponseType(typeof(Menu))]
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetMenu(int id)
        {
            Menu menu = db.Menus.Find(id);
            
            if(menu == null) return NotFound();
            return Ok(menu);
        }

        [ResponseType(typeof(Menu))]
        [HttpPost]
        [Route("includ")]
        public IHttpActionResult PostMenu(Menu menu)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            db.Menus.Add(menu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = menu.Id }, menu);

        }
        
        [ResponseType(typeof(Menu))]
        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult DeleteMenu(int id)
        {
            Menu menu = db.Menus.Find(id);

            if (menu == null) return NotFound();

            db.Menus.Remove(menu);
            db.SaveChanges();

            return Ok(menu);
        }
        
        /*      
        // PUT: api/Menus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMenu(int id, Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menu.Id)
            {
                return BadRequest();
            }

            db.Entry(menu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(id))
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuExists(int id)
        {
            return db.Menus.Count(e => e.Id == id) > 0;
        }*/
    }
}