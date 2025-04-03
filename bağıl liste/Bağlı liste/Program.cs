using System; // System kütüphanesini kullanarak temel sınıfları ve işlevleri erişilebilir hale getirir.
using System.ComponentModel.Design; // Tasarım bileşenleri için gerekli sınıfları içerir.
using System.Security.Cryptography; // Kriptografi ile ilgili sınıfları içerir.
using System.Security.Principal; // Güvenlik ile ilgili kimlik bilgilerini içerir.

namespace Proje4 // Proje4 adında bir isim alanı oluşturur.
{
    class Program // Program sınıfı, uygulamanın başlangıç noktasıdır.
    {
        static void Main(string[] args) // Uygulamanın ana giriş noktası.
        {
            Liste ogrenciler = new Liste(); // Öğrenci listesini tutan bir Liste nesnesi oluşturur.
            int numara; // Öğrenci numarasını tutmak için değişken.
            string ad, soyad, dersAdi; // Öğrenci bilgilerini tutmak için değişkenler.
            float vize, final, ortalama; // Not bilgilerini tutmak için değişkenler.
            int secim = menu(); // Kullanıcının menüden seçim yapmasını sağlar.
            while (secim != 0) // Kullanıcı 0 seçeneğini seçene kadar döngü devam eder.
            {
                switch (secim) // Seçime göre işlemleri belirler.
                {
                    case 1: // Öğrenci ekleme işlemi.
                        Console.Write("numara : "); numara = int.Parse(Console.ReadLine()); // Kullanıcıdan numara alır.
                        Console.Write("İsim : "); ad = Console.ReadLine(); // Kullanıcıdan isim alır.
                        Console.Write("Soyisim : "); soyad = Console.ReadLine(); // Kullanıcıdan soyisim alır.
                        Console.Write("Ders Adı : "); dersAdi = Console.ReadLine(); // Kullanıcıdan ders adı alır.
                        Console.Write("Vize : "); vize = int.Parse(Console.ReadLine()); // Kullanıcıdan vize notu alır.
                        Console.Write("Final : "); final = int.Parse(Console.ReadLine()); // Kullanıcıdan final notu alır.
                        ogrenciler.ekle(numara, ad, soyad, dersAdi, vize, final); // Öğrenciyi listeye ekler.
                        break;

                    case 2: // Öğrenci silme işlemi.
                        Console.Write("numara : "); numara = int.Parse(Console.ReadLine()); // Kullanıcıdan silinecek öğrenci numarasını alır.
                        ogrenciler.sil(numara); // Belirtilen numaraya sahip öğrenciyi siler.
                        break;

                    case 3: // Öğrencileri yazdırma işlemi.
                        ogrenciler.yazdır(); // Tüm öğrencileri listeler.
                        break;

                    case 4: // En başarılı öğrenciyi gösterme işlemi.
                        ogrenciler.enBaşarılıÖğrenci(); // En yüksek not ortalamasına sahip öğrenciyi gösterir.
                        break;

                    case 0: // Programı kapatma işlemi.
                        break;

                    default: // Hatalı seçim durumunda.
                        Console.WriteLine("Hatalı seçim yaptınız !"); // Hata mesajı gösterir.
                        break;
                }
                secim = menu(); // Kullanıcıdan tekrar seçim alır.
            }
            Console.WriteLine("Program kapatılıyor..."); // Program kapatıldığında mesaj gösterir.
        }

        private static int menu() // Menü fonksiyonu.
        {
            int secim; // Kullanıcının seçimini tutan değişken.
            Console.WriteLine("\n1-Öğrenci ekle"); // Menü seçenekleri.
            Console.WriteLine("2-Öğrenci sil");
            Console.WriteLine("3-Öğrencileri yazdır");
            Console.WriteLine("4-En başarılı öğrenciyi göster");
            Console.WriteLine("0-Programı kapat");
            Console.WriteLine("Seçiminiz : ");
            secim = int.Parse(Console.ReadLine()); // Kullanıcıdan seçim alır.
            return secim; // Seçimi döndürür.
        }
    }

    class Ögrenci // Öğrenci sınıfı, her bir öğrencinin bilgilerini tutar.
    {
        public int numara; // Öğrenci numarası.
        public string ad, soyad, dersAdi; // Öğrenci adı, soyadı ve ders adı.
        public float vize, final, ortalama; // Vize, final notları ve ortalama.
        public string durum; // Öğrencinin durumu (geçti/kaldı).

        public Ögrenci next; // Listeleme için sonraki öğeyi tutar.

        public Ögrenci(int n, string a, string s, string d, float v, float f) // Yapıcı metot.
        {
            this.numara = n; // Numarayı atar.
            this.ad = a; // Adı atar.
            this.soyad = s; // Soyadı atar.
            this.dersAdi = d; // Ders adını atar.
            this.vize = v; // Vize notunu atar.
            this.final = f; // Final notunu atar.

            this.ortalama = this.vize * 40 / 100 + this.final * 60 / 100; // Ortalama hesaplar.
            this.durum = this.ortalama < 50 ? "Kaldı" : "Geçti"; // Durumu belirler.
            this.next = null; // Başlangıçta sonraki elemanı null olarak ayarlar.
        }
    }

    class Liste // Öğrenci listesini tutan sınıf.
    {
        Ögrenci head; // Listenin başını tutan değişken.

        public Liste() // Yapıcı metot.
        {
            head = null; // Liste başlangıçta boştur.
        }

        public void ekle(int n, string a, string s, string d, float v, float f) // Öğrenci ekleme metodu.
        {
            Ögrenci ogr = new Ögrenci(n, a, s, d, v, f); // Yeni öğrenci nesnesi oluşturur.
            if (head == null) // Eğer liste boşsa.
            {
                head = ogr; // Yeni öğrenciyi başa ekler.
                Console.WriteLine(n + " numaralı öğrenci listeye eklendi.");
            }
            else // Eğer liste boş değilse.
            {
                ogr.next = head; // Yeni öğrencinin sonraki bağlantısını başa ayarlar.
                head = ogr; // Yeni öğrenciyi başa ekler.
                Console.WriteLine(n + " numaralı öğrenci eklendi.");
            }
        }

        public void sil(int numara) // Öğrenci silme metodu.
        {
            bool sonuc = false; // Silme işleminin sonucunu tutan değişken.
            if (head == null) // Eğer liste boşsa.
            {
                sonuc = true; // Sonucu true yapar.
                Console.WriteLine("Listede kayıtlı öğrenci yok !");
            }
            else if (head.next == null && head.numara == numara) // Eğer tek bir öğrenci varsa ve o silinmek isteniyorsa.
            {
                sonuc = true; // Sonucu true yapar.
                head = head.next; // Listeyi boş yapar.
                Console.WriteLine(numara + " numaralı öğrenci silindi, listede hiç öğrenci kalmadı.");
            }
            else if (head.next != null && head.numara == numara) // Eğer baştaki öğrenci silinmek isteniyorsa.
            {
                sonuc = true; // Sonucu true yapar.
                head = null; // Listeyi boş yapar.
                Console.WriteLine(numara + " numaralı öğrenci silindi, listede hiç öğrenci kalmadı.");
            }
            else // Eğer silinmek istenen öğrenci listede yoksa.
            {
                Ögrenci temp = head; // Geçici değişken.
                Ögrenci temp2 = temp; // Önceki değişken.

                while (temp.next != null) // Liste sonuna kadar gider.
                {
                    if (numara == temp.numara) // Eğer numara eşleşirse.
                    {
                        sonuc = true; // Sonucu true yapar.
                        temp2.next = temp.next; // Öğrenciyi listeden çıkarır.
                        Console.WriteLine(numara + " numaralı öğrenci silindi.");
                    }
                    temp2 = temp; // Önceki değişkeni günceller.
                    temp = temp.next; // Geçici değişkeni bir sonraki elemana geçirir.
                }
                if (numara == temp.numara) // Eğer son eleman silinmek isteniyorsa.
                {
                    sonuc = true; // Sonucu true yapar.
                    temp2.next = null; // Son elemanı listeden çıkarır.
                    Console.WriteLine(numara + " numaralı öğrenci silindi.");
                }
            }
            if (sonuc == false) // Eğer öğrenci silinmediyse.
            {
                Console.WriteLine(numara + " numaralı öğrenciye ait kayıt bulunamadı."); // Hata mesajı gösterir.
            }
        }

        public void yazdır() // Öğrencileri yazdırma metodu.
        {
            if (head == null) // Eğer liste boşsa.
            {
                Console.WriteLine("Listede kayıtlı öğrenci yok."); // Mesaj gösterir.
            }
            else // Eğer liste doluysa.
            {
                Ögrenci temp = head; // Geçici değişken.
                Console.WriteLine("Numara\tAd\tSoyad\tDersAdı\tOrtalama\tDurum "); // Başlıkları yazdırır.

                while (temp.next != null) // Liste sonuna kadar gider.
                {
                    Console.WriteLine(temp.numara + "\t" + temp.ad + "\t" + temp.soyad + "\t" + temp.dersAdi + "\t" + temp.ortalama + "\t" + temp.durum + "\t"); // Öğrenci bilgilerini yazdırır.
                    temp = temp.next; // Geçici değişkeni bir sonraki elemana geçirir.
                }
                Console.WriteLine(temp.numara + "\t" + temp.ad + "\t" + temp.soyad + "\t" + temp.dersAdi + "\t" + temp.ortalama + "\t" + temp.durum + "\t"); // Son öğrenciyi yazdırır.
            }
        }

        public void enBaşarılıÖğrenci() // En başarılı öğrenciyi bulma metodu.
        {
            if (head == null) // Eğer liste boşsa.
            {
                Console.WriteLine("Listede kayıtlı öğrenci yok."); // Mesaj gösterir.
            }
            else // Eğer liste doluysa.
            {
                Ögrenci temp = head; // Geçici değişken.
                Ögrenci yuksekOgr = head; // En yüksek not ortalamasına sahip öğrenciyi tutacak değişken.
                float enYuksekOrtalama = head.ortalama; // En yüksek ortalamayı tutan değişken.

                while (temp.next != null) // Liste sonuna kadar gider.
                {
                    if (enYuksekOrtalama < temp.ortalama) // Eğer geçerli ortalama daha yüksekse.
                    {
                        enYuksekOrtalama = temp.ortalama; // En yüksek ortalamayı günceller.
                        yuksekOgr = temp; // En yüksek ortalamalı öğrenciyi günceller.
                    }
                    temp = temp.next; // Geçici değişkeni bir sonraki elemana geçirir.
                }
                if (enYuksekOrtalama < temp.ortalama) // Son elemanı kontrol eder.
                {
                    enYuksekOrtalama = temp.ortalama; // En yüksek ortalamayı günceller.
                    yuksekOgr = temp; // En yüksek ortalamalı öğrenciyi günceller.
                }
                Console.WriteLine("En yüksek ortalamalı öğrenci bilgileri : "); // Mesaj gösterir.
                Console.WriteLine("Numara\tAd\tSoyad\tDersAdı\tOrtalama\tDurum "); // Başlıkları yazdırır.
                Console.WriteLine(yuksekOgr.numara + "\t" + yuksekOgr.ad + "\t" + yuksekOgr.soyad + "\t" + yuksekOgr.dersAdi + "\t" + yuksekOgr.ortalama + "\t" + yuksekOgr.durum + "\t"); // En başarılı öğrenciyi yazdırır.
            }
        }
    }
}
