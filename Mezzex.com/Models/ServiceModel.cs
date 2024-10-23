using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mezzex.com.Models
{
    public class ServiceModel
    {
        public string Email { get; set; }
        public string SelectedService { get; set; }
        public string Subject { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }

        public List<SelectListItem> Services { get; set; }
    }

}
