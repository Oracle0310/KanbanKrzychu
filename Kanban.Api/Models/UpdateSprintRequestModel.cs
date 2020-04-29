using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Api.Models
{
    public class UpdateSprintRequestModel
    {
        public string SprintGoal { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AdditionalInformation { get; set; }
    }
}
