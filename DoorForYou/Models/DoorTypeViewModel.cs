using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Doorforyou.Models
{
    public class DoorTypeViewModel
    {
        public List<Door> Doors { get; set; }
        public SelectList Type { get; set; }
        public string DoorsTypes { get; set; }
        public string SearchString { get; set; }
    }
}
