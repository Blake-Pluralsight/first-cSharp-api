using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using city.API.Models;


namespace city.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities.OrderBy(o => o.Name));

        }
        [HttpGet("{id}", Name = "GetCity")]
        public IActionResult GetCity(int id)
        {
            dynamic cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if (cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);

        }
        [HttpPost]
        public IActionResult CreateCity([FromBody] CityForCreationDto newCity)
        {
            if (newCity.Name == newCity.Description)
            {
                ModelState.AddModelError(
                    "Description",
                    "The provided description should be different than the name"
                    );
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var maxCityId = CitiesDataStore.Current.Cities.Max(c => c.Id);

            var finalCity = new CityDto()
            {
                Id = ++maxCityId,
                Name = newCity.Name,
                Description = newCity.Description
            };

            CitiesDataStore.Current.Cities.Add(finalCity);

            return CreatedAtRoute("GetCity", new { id = finalCity.Id }, finalCity);

        }

    }

}
