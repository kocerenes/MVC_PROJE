using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//İçerik için oluşturduğum somut sınıf
namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; } // içerik Id'si

        [StringLength(1000)]
        public string ContentText { get; set; } // İçerikte yazılan kısım
        public DateTime ContentDate { get; set; } //İçeriğin yazılma tarihi
        public bool ContentStatus { get; set; } // içerik durumu


        /*İLİŞKİ KISMI */
        //Heading sınıfıyla ilişki
        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; } //ilgili sınıftan değer alıp property oluşturduk

        //Writer sınıfıyla ilişki
        public int? WriterId { get; set; }
        public virtual Writer Writer { get; set; } //ilgili sınıftan değer alıp property oluşturduk

    }
}
