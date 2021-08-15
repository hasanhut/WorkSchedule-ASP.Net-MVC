using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSchedule.Models
{
    public class ViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Schedule> Schedules { get; set; }
    }
}
