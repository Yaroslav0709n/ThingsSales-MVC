using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingsSales.Model
{
    public class Photo 
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public string Caption { get; set; }
        
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
