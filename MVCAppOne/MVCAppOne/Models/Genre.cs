using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAppOne.Models
{
    public class Genre
    {
        public int GenreID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string IconFileName { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}