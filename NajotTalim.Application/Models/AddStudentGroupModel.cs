using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NajotTalim.Application.Models
{
    public class AddStudentGroupModel
    {
        public int StudentId { get; set; }
        public bool IsPaid { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}
