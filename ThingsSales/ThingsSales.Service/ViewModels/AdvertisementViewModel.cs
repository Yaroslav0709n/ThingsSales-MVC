using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using ThingsSales.Model;

namespace ThingsSales.Service.ViewModels
{
    public class AdvertisementViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string City { get; set; }
        public DateTime Time { get; set; }

        [Required(ErrorMessage = "Please select at least one photo.")]
        public ICollection<Photo> Photos { get; set; }
    }
}
