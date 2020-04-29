using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kanban.Database.Entities
{
    public class DBBacklogItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double EstimatedTime { get; set; }
        public DBSprint Sprint { get; set; }
        public IEnumerable<DBItemTask> Tasks { get; set; }
        public DateTime? Created { get; set; }
    }
}
