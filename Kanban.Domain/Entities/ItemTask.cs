using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Domain.Entities
{
    public class ItemTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public DateTime? Created { get; set; }
    }
}
