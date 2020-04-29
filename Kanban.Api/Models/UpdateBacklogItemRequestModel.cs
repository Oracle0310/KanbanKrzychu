using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Api.Models
{
    public class UpdateBacklogItemRequestModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double EstimatedTime { get; set; }
    }
}
