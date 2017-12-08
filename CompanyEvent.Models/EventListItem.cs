using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEvent.Models
{
    public class EventListItem
    {
        [Display(Name = "Event ID")]
        public int EventId { get; set; }
        public string Title { get; set; }

        [Display(Name = "Date & Time")]
        public DateTime DateTime { get; set; }

        public override string ToString() => Title;
    }
}
