using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Api.Models
{
    public class AddBacklogItemRequestModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double EstimatedTime { get; set; }
        public DateTime? Created { get; set; }
    }
}
