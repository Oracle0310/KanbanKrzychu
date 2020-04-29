using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Domain.Entities
{
    public class BacklogItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double EstimatedTime { get; set; }
        public IEnumerable<ItemTask> Tasks { get; set; }
        public DateTime? Created { get; set; }
    }
}
