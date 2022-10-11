using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInValid = "Ürün İsmi Geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductListed = "Ürünler Listelendi";
        public static string CategoryListed = "Categori Listelendi";
        public static string CategoryAdded = "Category Eklendi";
        public static string ProductCountOfCategoryError="Bir Categoride en fazla 10 ürün olabilir.";
        public static string ProductNameAlreadyExists = "Bu isme sahip bir ürün zaten var";
        public static string CategoryLimitExceded = "Categori Limiti Aşıldı";
    }
}
