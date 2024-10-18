using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mezzex.com.Models
{
    public class ServiceModel
    {
        // This will hold the selected value
        public string SelectedService { get; set; }

        // This will populate the dropdown list items
        public List<SelectListItem> Services { get; set; }
    }
}
