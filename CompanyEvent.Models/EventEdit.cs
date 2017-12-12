using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEvent.Models
{
    public class EventEdit
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
    }
}
