using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTodoAuth.Models
{
    public class ToDoTaskModel
    {
        [Key]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "TaskName is required")]
        public string TaskName { get; set; }

        public string TaskDescription { get; set; }
        public bool TaskStatus { get; set; }
    }
}
