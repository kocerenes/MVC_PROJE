using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// İletişim bilgileri için class
namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; } // iletişim ıd

        [StringLength(50)]
        public string UserName { get; set; } // kullanıcı ad

        [StringLength(50)]
        public string UserMail { get; set; } // kullanıcı mail

        [StringLength(50)]
        public string Subject { get; set; } // konu

        public DateTime ContactDate { get; set; } //Tarih
        public string Message { get; set; } // mesaj
    }
}
