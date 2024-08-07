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
ETicaretContext context = new();

#endregion

// DbContext
public class ETicaretContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }
    public DbSet<Parca> Parcalar { get; set; }

    // İleride değinilecek
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=ETicaret;Trusted_Connection=True;TrustServerCertificate=True;");
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