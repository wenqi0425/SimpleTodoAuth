using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SimpleTodoAuth.Models
{
    public class TodoTaskModel
    {
        [Key]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "TaskName is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string TaskName { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string TaskDescription { get; set; }

        [Column(TypeName = "bit")]
        public bool TaskStatus { get; set; }
    }
}
