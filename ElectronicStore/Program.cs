using ElectronicStore;
using Microsoft.EntityFrameworkCore;


using (var db = new ApplicationContext())
{
    var stores = db.Stores.Include(s=> s.Personnels).ToList();
    foreach(var store in stores)
    {
        Console.WriteLine($"{store.Name} - {store.Destination}");
        Console.WriteLine("Работники:");
        foreach(var p in store.Personnels)
        { Console.WriteLine(p.Name); }
        Console.WriteLine("Товары:");
        var products = db.Products.Include(p=>p.ItsProducer).Include(p=>p.ThisProductCategory).Include(p=>p.ItsProvider).ToList();
        foreach( var product in products)
        { 
            Console.WriteLine($"{product.ThisProductCategory.Name} { product.ItsProducer.Name} {product.Name}. Поставщик - {product.ItsProvider.Name}"); 
        }
    }

    //StoredProcedure
    Microsoft.Data.SqlClient.SqlParameter param = new Microsoft.Data.SqlClient.SqlParameter("@name", "CPU");
    var productsByCategory = db.Products.FromSqlRaw("GetProductsByCategory @name ", param).ToList();
    Console.WriteLine("CPU товары:");
    foreach(var product in productsByCategory)
    { Console.WriteLine(product.Name); }
}


