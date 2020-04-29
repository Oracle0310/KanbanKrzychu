using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kanban.Database.Entities
{
    public class DBItemTask
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DBUser User { get; set; }
        public DBBacklogItem BacklogItem { get; set; }
        public DateTime? Created { get; set; }
    }
}
