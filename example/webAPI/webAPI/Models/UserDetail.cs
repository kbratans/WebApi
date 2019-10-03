using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class UserDetail
    {
      
        public int ID { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public int MobilePhone { get; set; }
        public int Phone { get; set; }

        public string Address { get; set; }
        public DateTime InsertDate { get; set; }

        public bool IsDeleted { get; set; }

        public Users Users { get; set; }
    }


   


}
