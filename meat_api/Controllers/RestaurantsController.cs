using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using meat_api.DAO;
using meat_api.Models;

namespace meat_api.Controllers
{
    public class RestaurantsController : ApiController
    {
        private AppDbContext db = new AppDbContext();
        private MenuDAO menuDAO = new MenuDAO();
        private RestaurantDAO restaurantDAO = new RestaurantDAO();
        private ReviewDAO reviewsDAO = new ReviewDAO();

        public IQueryable<Restaurant> GetRestaurants()
        {
            return db.Restaurants;
        }

        // GET: api/Restaurants/5
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult GetRestaurant(string id)
        {
            //Restaurant restaurant = db.Restaurants.Find(id);
            Restaurant restaurant = restaurantDAO.GetRestaurantByNameId(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        // PUT: api/Restaurants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestaurant(int id, Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            db.Entry(restaurant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
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

        // POST: api/Restaurants
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult PostRestaurant(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Restaurants.Add(restaurant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = restaurant.Id }, restaurant);
        }

        // DELETE: api/Restaurants/5
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult DeleteRestaurant(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            db.Restaurants.Remove(restaurant);
            db.SaveChanges();

            return Ok(restaurant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantExists(int id)
        {
            return db.Restaurants.Count(e => e.Id == id) > 0;
        }

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("api/restaurants/{id}/menu")]
        public IHttpActionResult MenuOfRestaurant(string id)
        {

            List<Menu> menu = menuDAO.GetMenuByRestaurantId(id);

            if (menu == null) return NotFound();

            return Ok(menu);
        }

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        [Route("api/restaurants/{id}/reviews")]
        public IHttpActionResult ReviewsOfRestaurant(string id)
        {
            List<Reviews> reviews = reviewsDAO.GetReviewsByRestaurantId(id);

            if (reviews == null) return NotFound();

            return Ok(reviews);
        }
    }
}