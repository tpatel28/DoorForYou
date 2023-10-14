using System;
using System.ComponentModel.DataAnnotations;

namespace Doorforyou.Models
{
    public class Door
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string Edition { get; set; }
        public string Make { get; set; }
        public decimal Price { get; set; }
        public string Rating { get; set; }
    }
}
