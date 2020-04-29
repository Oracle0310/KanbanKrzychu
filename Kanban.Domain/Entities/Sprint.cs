using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Domain.Entities
{
    public class Sprint
    {
        public int Id { get; set; }
        public string SprintGoal { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AdditionalInformation { get; set; }
        public IEnumerable<BacklogItem> BacklogItems { get; set; }
    }
}
