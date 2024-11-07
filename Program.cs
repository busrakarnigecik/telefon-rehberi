using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

public class Kisi
{
    public string? Isim { get; set; }
    public string? Soyisim { get; set; }
    public string? TelefonNumarasi { get; set; }
}
class Program
{
    static List<Kisi> rehber = new List<Kisi>();
    static void Main()
    {
        VarsayilanKisilerEkle();
        bool calisiyor = true;
        while (calisiyor)
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:");
            Console.WriteLine("1. Yeni Numara Kaydet");
            Console.WriteLine("2. Var olan numarayı Sil");
            Console.WriteLine("3.Var olan numarayı Güncelle");
            Console.WriteLine("4. Rehberi Listele (AZ,ZA Seçimli)");
            Console.WriteLine("5. Rehberde Arama Yap");
            Console.WriteLine("6. Çıkış");
            Console.WriteLine("Seçiminz: ");

            string? secim = Console.ReadLine();
            switch (secim)
            {
                case "1":
                    KisiEkle();
                    break;
                case "2":
                    KisiSil();
                    break;
                case "3":
                    KisiGuncelle();
                    break;
                case "4":
                    RehberiListele();
                    break;
                case "5":
                    KisiAra();
                    break;
                case "6":
                    calisiyor = false;
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyiniz.");
                    break;
            }
            Console.WriteLine();
        }
    }
    static void VarsayilanKisilerEkle()
    {
        rehber.Add(new Kisi { Isim = "Murat", Soyisim = "Kararslan", TelefonNumarasi = "0501-123-11-11" });
        rehber.Add(new Kisi { Isim = "Hilal", Soyisim = "Yüksel", TelefonNumarasi = "0501-222-22-11" });
        rehber.Add(new Kisi { Isim = "Yiğit", Soyisim = "Kayra", TelefonNumarasi = "0505-450-02-00" });
        rehber.Add(new Kisi { Isim = "Ümit", Soyisim = "Alp", TelefonNumarasi = "0530-523-89-95" });
        rehber.Add(new Kisi { Isim = "Duru", Soyisim = "Bahar", TelefonNumarasi = "0501-208-36-62" });
    }
    static void KisiEkle()
    {
       Console.WriteLine("Yeni Numara Kaydetmek");
    
    // Nullable tür kullanmak için string? kullanıyoruz.
    Console.Write("Lütfen isim giriniz: ");
    string? isim = Console.ReadLine();  // string? olarak değiştirildi
    Console.Write("Lütfen soyisim giriniz: ");
    string? soyisim = Console.ReadLine();  // string? olarak değiştirildi
    Console.Write("Lütfen telefon numarasını giriniz: ");
    string? telefonNumarasi = Console.ReadLine();  // string? olarak değiştirildi

    // Eğer herhangi bir değer null değilse, kişi eklenir
    if (!string.IsNullOrEmpty(isim) && !string.IsNullOrEmpty(soyisim) && !string.IsNullOrEmpty(telefonNumarasi))
    {
        rehber.Add(new Kisi { Isim = isim, Soyisim = soyisim, TelefonNumarasi = telefonNumarasi });
        Console.WriteLine("Kişi başarıyla eklendi!");
    }
    else
    {
        Console.WriteLine("Geçersiz veri girildi.");
    }
    }
    static void KisiSil()
    {
        Console.Write("Silmek istediğiniz kişinin ismini girin:       ");
        string? isim = Console.ReadLine();
        Kisi? kisi = rehber.Find(k => k.Isim.Equals(isim, StringComparison.OrdinalIgnoreCase));
        if (kisi != null)
        {
            rehber.Remove(kisi);
            Console.WriteLine("Kişi başarıyla silindi!");
        }
        else
            Console.WriteLine("Kişi bulunamadı!");
    }
    static void KisiGuncelle()
    {
        Console.Write("Güncellemek istediğiniz kişininin ismini girin:       ");
        string? isim = Console.ReadLine();
        Kisi kisi = rehber.Find(k => k.Isim.Equals(isim, StringComparison.OrdinalIgnoreCase));
        if (kisi != null)
        {
            Console.Write("Yeni telefon numarası:      ");
            kisi.TelefonNumarasi = Console.ReadLine();
            Console.WriteLine("Kişi başarıyla güncellendi!");
        }
        else
            Console.WriteLine("Kişi bulunamadı!");
    }
    static void RehberiListele()
    {
        Console.WriteLine("Rehberi nasıl listelemek istersiniz?");
        Console.Write("1. A'dan Z'ye");
        Console.Write("2. Z'den A'ya");
        string? secim = Console.ReadLine();
        IEnumerable<Kisi> siraliRehber = rehber;
        if (secim == "1")
        {
            siraliRehber = rehber.OrderBy(k => k.Isim);
        }
        else if (secim == "2")
            siraliRehber = rehber.OrderByDescending(k => k.Isim);
        else
        {
            Console.WriteLine("Geçersiz seçim, varsayılan sırada listelenecek.");
        }
        Console.WriteLine("Rehber: ");
        foreach (var kisi in siraliRehber)
        {
            Console.WriteLine($"İsim:  {kisi.Isim}, Telefon Numarası:  {kisi.TelefonNumarasi}");
        }
    }
    static void KisiAra()
    {
        Console.Write("Aramak istediğiniz ismi veya numarayı girin: ");
        string? arama = Console.ReadLine();
        var bununanKisiler = rehber.FindAll(k => k.Isim.Contains(arama, StringComparison.OrdinalIgnoreCase) || k.TelefonNumarasi.Contains(arama));
        if (bununanKisiler.Count > 0)
        {
            Console.WriteLine("Arama Sonuçları: ");
            foreach (var kisi in bununanKisiler)
            {
                Console.WriteLine($"İsim: {kisi.Isim}, Soyisim: {kisi.Soyisim}, Telefon Numarası: {kisi.TelefonNumarasi}");
            }
        }
        else
            Console.WriteLine("Hiçbir sonuç bulunamadı.");
    }
}
