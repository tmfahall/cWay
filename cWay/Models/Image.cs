using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cWay.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        [StringLength(255)]
        public string ImageFileName { get; set; }
        public int TruckID { get; set; }
        public virtual Truck Truck { get; set; }
    }
}