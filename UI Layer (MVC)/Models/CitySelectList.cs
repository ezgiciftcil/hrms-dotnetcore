using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Layer__MVC_.Models
{
    public class CitySelectList
    {
        private readonly ICityService _cityService;
        public CitySelectList(ICityService cityService)
        {
            _cityService = cityService;
        }

        public SelectList GetCities()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var cities = _cityService.GetAllCities().Data;
            foreach (var city in cities)
            {
                items.Add(new SelectListItem { Value = city.CityId.ToString(), Text = city.CityName });
            }
            return new SelectList(items, "Value", "Text");
        }
        

    }
}
