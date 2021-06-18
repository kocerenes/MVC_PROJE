using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// content category'leri için oluşturduğum somut sınıfım
namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } // kategori ıd

        [StringLength(50)]
        public string CategoryName { get; set; } // kategori ismi

        [StringLength(200)]
        public string CategoryDescription { get; set; } // kategori açıklaması
        public bool CategoryStatus { get; set; } // kategorinin durumu (eğer false ise altındaki başlıklar ve içerikler sayfada görünmez)

                                        /*İLİŞKİ KISMI */
        //Heading sınıfıyla ilişki
        public ICollection<Heading> Headings { get; set; } // Category sınıfımın Heading sınıfıyla ilişkili olacagını belirttim
    }
}
