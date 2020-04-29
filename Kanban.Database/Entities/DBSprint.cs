using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kanban.Database.Entities
{
    public class DBSprint
    {
        [Key]
        public int Id { get; set; }
        public string SprintGoal { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AdditionalInformation { get; set; }
        public IEnumerable<DBBacklogItem> BacklogItems { get; set; }
    }
}
