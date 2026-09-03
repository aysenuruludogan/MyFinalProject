using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        internal static string MaintenanceTime="Sistem Bakımda";
        internal static string ProductsListed="Ürünler Listelendi";
        internal static string ProductCountOfCategoryError="Bir kategoride en fazla 10 ürün olabilir";
        internal static string ProductNameAlreadyExist="Bu isimde zaten başka bir ürün var";

        public static string CategoryLimitExceded = "Kategori limiti aşıldıgı için yeni ürün eklenemiyor";
        internal static string? AuthorizationDenied= "Yetkiniz Yok";
    }
}
