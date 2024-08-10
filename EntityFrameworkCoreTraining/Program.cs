using Microsoft.EntityFrameworkCore;

// YouTube Video Listesi --> https://www.youtube.com/playlist?list=PLQVXoXFVVtp1o3nq3-IXv42bPaFlzroBE
#region Ders 1 - 9
// Bu kısım hep teorikti.
#endregion
#region Ders 10
/*
ETicaretContext context = new();
Urun urun = new() 
{ 
    Isim = "A",
    Ucret = 1000
};
await context.AddAsync(urun);           // --> Tür güvensiz
//await context.Urunler.AddAsync(urun); // --> Tür güvenli 
await context.SaveChangesAsync();
*/

/*
ETicaretContext context = new();
Urun urun = new()
{
    Isim = "B",
    Ucret = 500
};
await context.AddAsync(urun);
await context.SaveChangesAsync();
*/

/*
ETicaretContext context = new();
Urun urun1 = new()
{
    Isim = "A",
    Ucret = 2000
};
Urun urun2 = new()
{
    Isim = "B",
    Ucret = 2001
};
Urun urun3 = new()
{
    Isim = "C",
    Ucret = 2002
};
await context.AddRangeAsync(urun1, urun2, urun3);
await context.SaveChangesAsync();
*/

/*
ETicaretContext context = new();
Urun urun1 = new()
{
    Isim = "Z",
    Ucret = 2000
};
await context.AddAsync(urun1);
await context.SaveChangesAsync();
Console.WriteLine(urun1.Id);
*/
#endregion
#region Ders 11
/*
ETicaretContext context = new();
Urun urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 3);
urun.Isim = "Lahmacun";          // ChangeTracker update'i anlıyor.
urun.Ucret = 44;
await context.SaveChangesAsync();
*/

/*
ETicaretContext context = new();
Urun urun = new()
{
    Id = 2,
    Isim = "Döner",
    Ucret = 32
};
context.Update(urun);
await context.SaveChangesAsync();
*/
#endregion
#region Ders 12
/*
ETicaretContext context = new();
Urun urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 1);
context.Urunler.Remove(urun);
await context.SaveChangesAsync();
*/

/*
ETicaretContext context = new();
List<Urun> urunler = await context.Urunler.Where(u => u.Id > 1 && u.Id < 4).ToListAsync();
context.Urunler.RemoveRange(urunler);
await context.SaveChangesAsync();
*/
#endregion
#region Ders 13
/*
ETicaretContext context = new();
// Method Syntax
var urunler = await context.Urunler.ToListAsync();
// Query Syntax
var urunler2 = await (from urun in context.Urunler
                      select urun).ToListAsync();

*/

/*
ETicaretContext context = new();
int urunId = 5;
string urunAdi = "Masa";
var urunler = from urun in context.Urunler
              where urun.Id > urunId && urun.UrunAdi.Contains(urunAdi)
              select urun;
foreach (Urun urun in urunler)
{
    Console.WriteLine(urun.UrunAdi);
}
*/
#endregion
#region Ders 14
/*
ETicaretContext context = new();
//var urunler = await context.Urunler.Where(u => u.Id > 500).ToListAsync();
var urunler = from urun in context.Urunler
              where urun.Id > 500
              select urun;
var data = await urunler.ToListAsync();
*/

/*
ETicaretContext context = new();
var urunler = context.Urunler.Where(u => u.Id < 5).OrderBy(u => u.UrunAdi);
var urunler2 = from urun in context.Urunler
               where urun.Id < 5
               orderby urun.UrunAdi
               select urun;
await urunler.ToListAsync();
await urunler2.ToListAsync();
*/

/*
ETicaretContext context = new();
var urunler = context.Urunler.Where(u => u.Id < 5).OrderBy(u => u.UrunAdi).ThenBy(u => u.Id); 
// Urunler ilk olarak UrunAdi'ne göre sıralanır eğer aynı özellikte urunler varsa Id'e göre sıralar. ThenBy birden fazla gelebilir.
*/

/*
ETicaretContext context = new();
// Ters sıralama
var urunler = context.Urunler.Where(u => u.Id < 5).OrderByDescending(u => u.UrunAdi); 
var urunler2 = context.Urunler.Where(u => u.Id < 5).OrderByDescending(u => u.UrunAdi).ThenByDescending(u => u.Id);
var urunler3 = from urun in context.Urunler
               orderby urun.Id descending
               select urun;
*/
#endregion
#region Ders 15
/*
ETicaretContext context = new();
// Eğer hiç kayıt gelmezse yada birden fazla kayıt gelirse hata verir.
//var urun = await context.Urunler.SingleAsync(u => u.Id == 5);
// Eğer birden fazla kayıt gelirse hata verir. Hiç kayıt gelmezse null döner yani hata vermez.
//var urun = await context.Urunler.SingleOrDefaultAsync(u => u.Id == 5);
// Hiç kayıt gelmezse hata verir. Birden fazla kayıt gelirse sadece ilkini alır.
//var urun = await context.Urunler.FirstAsync(u => u.Id > 5);
// Hiç kayıt gelmezse hata vermez. Birden fazla kayıt gelirse sadece ilkini alır.
//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id > 5);
// Last fonksiyonları için OrderBy gerekir.
// Hiç kayıt gelmezse hata verir. Birden fazla kayıt gelirse sadece sonuncusunu alır.
//var urun = await context.Urunler.OrderBy(u => u.UrunAdi).LastAsync(u => u.Id > 5);
// Hiç kayıt gelmezse hata vermez. Birden fazla kayıt gelirse sadece sonuncusunu alır.
//var urun = await context.Urunler.OrderBy(u => u.UrunAdi).LastOrDefaultAsync(u => u.Id > 5);
// Primary key kolonuna özel hızlı sorgulama.
//Urun urun = await context.Urunler.FindAsync(5);
// 2 tane primary keyi olduğu için iki parametre aldı.
//UrunParca urunParca = await context.UrunParca.FindAsync(2, 5);
*/
#endregion
#region Ders 16
/*
ETicaretContext context = new();
Console.WriteLine(await context.Urunler.CountAsync(u => u.Id > 40));
Console.WriteLine(await context.Urunler.LongCountAsync());
Console.WriteLine(await context.Urunler.AnyAsync(u => u.Id == 5));
Console.WriteLine(await context.Urunler.MaxAsync(u => u.Fiyat));
Console.WriteLine(await context.Urunler.MinAsync(u => u.Fiyat));
// Sorguda tekrar eden kayıtları birleştiren fonksiyon
var urunler = await context.Urunler.Distinct().ToListAsync();
// Bir sorgu neticesinde gelen verilerin tamamının gelen şarta uyup uymadığını bool değerle gösterir.
Console.WriteLine(await context.Urunler.AllAsync(u => u.Fiyat > 500));
Console.WriteLine(await context.Urunler.SumAsync(u => u.Fiyat));
Console.WriteLine(await context.Urunler.AverageAsync(u => u.Fiyat));
var urunler2 = await context.Urunler.Where(u => u.UrunAdi.Contains("7")).ToListAsync();
var urunler3 = await context.Urunler.Where(u => u.UrunAdi.StartsWith("U")).ToListAsync();
var urunler4 = await context.Urunler.Where(u => u.UrunAdi.EndsWith("7")).ToListAsync();
*/
#endregion
#region Ders 17



#endregion

// DbContext
public class ETicaretContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }
    public DbSet<Parca> Parcalar { get; set; }
    public DbSet<UrunParca> UrunParca { get; set; }

    // İleride değinilecek
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=ETicaret;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UrunParca>().HasKey(up => new { up.UrunId, up.ParcaId });
    }
}

// Entity
public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public float Fiyat { get; set; }

    public ICollection<Parca> Parcalar { get; set; }
}

// Entity
public class Parca
{
    public int Id { get; set; }
    public string ParcaAdi { get; set; }
}

// Entity
public class UrunParca
{
    public int UrunId { get; set; }
    public int ParcaId { get; set; }
    public Urun Urun { get; set; }
    public Parca Parca { get; set; }
}

/*
// Entity
public class Urun
{
    public int Id { get; set; }
    public string Isim { get; set; }
    public int Kalite { get; set; }
    public float Ucret { get; set; }
}
*/