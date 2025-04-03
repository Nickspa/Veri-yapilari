using System; 
using System.ComponentModel.Design; 
using System.Data.SqlTypes; 

namespace Proje2
{
    class Program 
    {
        static void Main(string[] args) 
        {
            StackYapısı stc = new StackYapısı(); 
            int sayi; 
            int secim = menu(); 

            while (secim != 0) 
            {
                switch (secim) 
                {  
                    case 1: 
                        Console.WriteLine("Sayı : ");
                        sayi = int.Parse(Console.ReadLine()); 
                        stc.push(sayi); 
                        break;
                    case 2: // Pop işlemi
                        sayi = stc.pop(); 
                        if (sayi != -1) // Eğer sayı -1 değilse
                        {
                            Console.WriteLine("Çıkan sayı : " + sayi);
                        }
                        else
                        {
                            Console.WriteLine("Stack boştur");
                        }
                        break;
                    case 3: // Yığını yazdırma
                        stc.print(); // Yığındaki elemanları yazdır
                        break;
                    case 4: // Yığının tepe elemanını yazdırma
                        stc.topPrint(); // Yığının tepe elemanını yazdır
                        break;
                    case 0: // Çıkış
                        break; // Döngüyü kır
                    default: // Geçersiz seçim
                        Console.WriteLine("Hatalı seçim."); // Hata mesajı
                        break;
                }
                secim = menu(); // Yeni seçim al
            }
            Console.WriteLine("Program kapatılıyor..."); // Program kapanıyor mesajı
        }

        // Menü gösterme metodu
        private static int menu()
        {
            int secim; 
            Console.WriteLine("1-Push"); 
            Console.WriteLine("2-Pop"); 
            Console.WriteLine("3-Print"); 
            Console.WriteLine("4-Top"); 
            Console.WriteLine("0-Exit"); 
            secim = int.Parse(Console.ReadLine()); 
            return secim; 
        }
    }

    class Node 
    {
        public int data; // Düğüm verisi
        public Node next; // Bir sonraki düğümü gösterecek referans

        // Düğüm yapıcı metod
        public Node(int data)
        {
            this.data = data; 
            next = null;
        }
    }

    class StackYapısı 
    {
        Node top; 

        // Yığın yapıcı metod
        public StackYapısı()
        {
            top = null; 
        }

       
        public void push(int data)
        {
            Node eleman = new Node(data); 
            if (top == null) 
            {
                top = eleman; 
                Console.WriteLine("Stack yapısı oluşturuldu, ilk eleman stack'e yerleştirildi.");
            }
            else
            {
                eleman.next = top; 
                top = eleman; 
                Console.WriteLine("Eleman eklendi.");
            }
        }

    }
}
