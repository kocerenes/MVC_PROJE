using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Yazar için oluşturduğum somut sınıfım
namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; } //yazar Id

        [StringLength(50)]
        public string WriterName { get; set; } //yazar ad

        [StringLength(50)]
        public string WriterSurname { get; set; } //yazar soyad

        [StringLength(250)]
        public string WriterImage { get; set; } //yazar fotoğraf

        [StringLength(100)]
        public string WriterAbout { get; set; } //yazar hakkında

        [StringLength(200)]
        public string WriterMail { get; set; } //yazar mail adres

        [StringLength(200)]
        public string WriterPassword { get; set; } //yazar şifre

        [StringLength(50)]
        public string WriterTitle{ get; set; } //yazar şifre

        public bool WriterStatus { get; set; } // yazarın durumu

        [StringLength(1)]
        public string WriterRole { get; set; }


        /*İLİŞKİ KISMI */
        //Heading sınıfıyla ilişki
        public ICollection<Heading> Headings { get; set; } // Writer sınıfımın Heading sınıfıyla ilişkili olacagını belirttim

        //Content sınıfıyla ilişki
        public ICollection<Content> Contents { get; set; }

    }
}
