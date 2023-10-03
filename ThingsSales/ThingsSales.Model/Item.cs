using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsSales.Model.Identity;

namespace ThingsSales.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Time { get; set; }
        public DateTime Date { get; set; }
        public byte[] PhotoData { get; set; } 
        public string PhotoMimeType { get; set; } 
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
