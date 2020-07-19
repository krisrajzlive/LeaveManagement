using System;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Models
{
    public class DetailsLeaveTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class CreateLeaveTypeViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
