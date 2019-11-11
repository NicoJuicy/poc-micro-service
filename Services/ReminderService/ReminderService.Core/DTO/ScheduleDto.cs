using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerService.Core.DTO
{
    public abstract class ScheduleDto
    {
        public Guid ScheduleId { get; set; }
    }

    public class ScheduleOnceDTO : ScheduleDto
    {
        public DateTime On { get; set; }
    }

    public class ScheduleOccuringDTO : ScheduleDto
    {
        public DateTime NextOccurrenceOn { get; set; }

        public List<DateTime> Exclusions { get; set; } = new List<DateTime>();


        
    }

}
