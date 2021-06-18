using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Veritabanına yansıyacak olan
//Başlıklar için oluşturduğum somut sınıfım
namespace EntityLayer.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingId { get; set; } //Id özelliği

        [StringLength(50)]
        public string HeadingName { get; set; } // Başlığın adı
        public DateTime HeadingDate { get; set; } //Başlığın yazılma tarihi
        public bool HeadingStatus { get; set; } //başlık durumu

        /*İLİŞKİ KISMI */
        //Category sınıfıyla ilişki
        public int CategoryId { get; set; } // Category sınıfıyla ilişkilendiriceğimiz için o sınıftaki Id'nin tutuldugu isimle aynı olmalı yoksa hata verir.
        public virtual Category Category { get; set; } //ilgili sınıftan değer alıp property oluşturduk

        //Content sınıfıyla ilişki
        public ICollection<Content> Contents { get; set; } // Heading sınıfımın Content sınıfıyla ilişkili olacagını belirttim

        //Writer sınıfıyla ilişki
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; } //ilgili sınıftan değer alıp property oluşturduk
    }
}
