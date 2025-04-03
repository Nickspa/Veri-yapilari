using System;

namespace Proje1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Liste cydaListe = new Liste(); 
            int sayi, indis;
            int secim = menu(); 
            while (secim != 0) // Kullanıcı 0 girene kadar devam eder
            {
                switch (secim) // Kullanıcının seçimine göre işlem yapılır
                {
                    case 1:
                        // Kullanıcıdan sayı alınıyor ve başa ekleniyor
                        Console.Write("Sayı : "); 
                        sayi = int.Parse(Console.ReadLine());
                        cydaListe.basaEkle(sayi); 
                        cydaListe.yazdır(); // Liste yazdırılıyor
                        break;
                    case 2:
                        // Kullanıcıdan sayı alınıyor ve sona ekleniyor
                        Console.Write("Sayı : "); 
                        sayi = int.Parse(Console.ReadLine());
                        cydaListe.sonaEkle(sayi); 
                        cydaListe.yazdır(); // Liste yazdırılıyor
                        break;
                    case 3:
                        // Kullanıcıdan silinecek elemanın indeksi alınıyor
                        Console.Write("indis : "); 
                        indis = int.Parse(Console.ReadLine()); 
                        cydaListe.aradanSil(indis); // Belirtilen indeksten eleman siliniyor
                        cydaListe.yazdır(); // Liste yazdırılıyor
                        break;
                    case 0:
                        break; // Programı kapat
                    default:
                        // Geçersiz seçim durumunda hata mesajı
                        Console.WriteLine("Hatalı seçim yaptınız");
                        break;
                }
                // Kullanıcıdan tekrar seçim alınıyor
                secim = menu();
            }
            Console.WriteLine("Program kapatılıyor..."); // Program kapanma mesajı
        }

        // Menü fonksiyonu, kullanıcıdan seçim alır
        private static int menu()
        {
            int secim;
            Console.WriteLine("\n\n1-Başa ekle");
            Console.WriteLine("2-Sona ekle");
            Console.WriteLine("3-Aradan sil");
            Console.WriteLine("0-Programı kapat");
            Console.Write("seçiminiz : ");
            secim = int.Parse(Console.ReadLine()); // Kullanıcıdan seçim alınıyor
            return secim; // Seçim geri döndürülüyor
        }
    }
    
    // Bağlı liste düğümünü temsil eden sınıf
    class Node
    {
        public int data; // Düğümdeki veri
        public Node next; // Bir sonraki düğüme işaretçi
        public Node prev; // Önceki düğüme işaretçi

        // Düğümün yapıcı metodu
        public Node(int data)
        {
            this.data = data; // Düğüm verisi atanıyor
            this.next = null; // Başlangıçta bir sonraki düğüm yok
            this.prev = null; // Başlangıçta önceki düğüm yok
        }
    }
    
    // Çift yönlü bağlı liste sınıfı
    class Liste
    {
        Node head; // Listenin başını tutan işaretçi
        Node tail; // Listenin sonunu tutan işaretçi

        // Liste yapıcısı
        public Liste()
        {
            this.head = null; // Başlangıçta liste boş
            this.tail = null; // Başlangıçta liste boş
        }
        
        // Başa eleman ekleme metodu
        public void basaEkle(int data)
        {
            Node eleman = new Node(data); // Yeni düğüm oluşturuluyor
            if (head == null) // Eğer liste boşsa
            {
                head = tail = eleman; // Baş ve son aynı düğüm olur
                tail.next = head; 
                tail.prev = head; 
                head.next = tail; 
                head.prev = tail; 
                Console.WriteLine("Liste yapısı oluşturuldu, ilk eleman eklendi.");
            }
            else
            {
                // Yeni düğüm başa ekleniyor
                eleman.next = head; // Yeni düğümün next'i mevcut baş
                head.prev = eleman; // Mevcut başın prev'i yeni düğüm
                head = eleman; // Baş yeni düğüm oluyor
                head.prev = tail; // Yeni başın prev'i tail
                tail.next = head; // Tail'in next'i yeni baş
                Console.WriteLine("Başa eleman eklendi");
            }
        }
        
        // Sona eleman ekleme metodu
        public void sonaEkle(int data)
        {
            Node eleman = new Node(data); // Yeni düğüm oluşturuluyor
            if (head == null) // Eğer liste boşsa
            {
                head = tail = eleman; // Baş ve son aynı düğüm olur
                tail.next = head; // Düğüm kendi kendine işaret eder
                tail.prev = head; // Düğüm kendi kendine işaret eder
                head.next = tail; // Düğüm kendi kendine işaret eder
                head.prev = tail; // Düğüm kendi kendine işaret eder
                Console.WriteLine("Liste yapısı oluşturuldu, ilk eleman eklendi.");
            }
            else
            {
                // Yeni düğüm sona ekleniyor
                tail.next = eleman; // Tail'in next'i yeni düğüm
                eleman.prev = tail; // Yeni düğümün prev'i mevcut tail
                tail = eleman; // Tail yeni düğüm oluyor
                tail.next = head; // Tail'in next'i baş
                head.prev = tail; // Başın prev'i yeni tail
                Console.WriteLine("Sona eleman eklendi");
            }
        }
        
        // Listeyi yazdırma metodu
        public void yazdır()
        {
            if (head == null) // Eğer liste boşsa
                Console.WriteLine("Liste boş");
            else
            {
                Node temp = head; // Geçici düğüm baştan başlıyor
                Console.Write("Baş -> ");
                while (temp != tail) // Tail'e kadar döngü
                {
                    Console.Write(temp.data + " -> "); // Düğüm verisi yazdırılıyor
                    temp = temp.next; // Geçici düğüm bir sonraki düğüme geçiyor
                }
                Console.Write(temp.data + " son."); // Son düğüm yazdırılıyor
                Console.WriteLine(); // Satır sonu ekleniyor
            }
        }
        
        // Belirtilen indeksten eleman silme metodu
        public void aradanSil(int indis)
        {
            if (head == null) // Eğer liste boşsa
            {
                Console.WriteLine("Liste boş");
            }
            else
            {
                Node temp = head; // Geçici düğüm baştan başlıyor
                Node temp2 = null; // Önceki düğümü tutacak
                int i = 0;

                // Belirtilen indekse kadar düğümleri dolaş
                while (temp != null && i < indis) // tail yerine null kontrolü
                {
                    temp2 = temp; // Önceki düğümü güncelle
                    temp = temp.next; // Geçici düğümü bir sonraki düğüme geç
                    i++; // İndeksi artır
                }

                // Geçerli bir indis kontrolü
                if (temp != null && i == indis) 
                {
                    if (temp == head) // Eğer silinecek düğüm baş ise
                    {
                        head = head.next; // Baş bir sonraki düğüm oluyor
                        head.prev = tail; // Yeni başın prev'i tail
                        tail.next = head; // Tail'in next'i yeni baş
                    }
                    else if (temp == tail) // Eğer silinecek düğüm son ise
                    {
                        tail = tail.prev; // Tail bir önceki düğüm oluyor
                        tail.next = head; // Tail'in next'i baş
                        head.prev = tail; // Başın prev'i yeni tail
                    }
                    else // Orta bir düğüm ise
                    {
                        temp2.next = temp.next; // Önceki düğümün next'i silinecek düğümün next'i
                        if (temp.next != null) // null kontrolü
                        {
                            temp.next.prev = temp2; // Silinecek düğümün bir sonraki düğümünün prev'i önceki düğüm
                        }
                    }
                    Console.WriteLine("Aradan eleman silindi.");
                }
                else
                {
                    Console.WriteLine("Geçersiz indis"); // Geçersiz indis durumunda hata mesajı
                }
            }
        }
    }
}
