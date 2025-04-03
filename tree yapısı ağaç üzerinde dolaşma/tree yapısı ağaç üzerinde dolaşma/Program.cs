using System; 
using System.Runtime.CompilerServices; 

namespace Proje3 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("Ağaç veri yapısı."); 

            Tree bst = new Tree(); 

            bst.root = bst.insert(bst.root, 10);
            bst.root = bst.insert(bst.root, 5);
            bst.root = bst.insert(bst.root, 15);
            bst.root = bst.insert(bst.root, 20);
            bst.root = bst.insert(bst.root, 3);
            bst.root = bst.insert(bst.root, 12);
            bst.root = bst.insert(bst.root, 9);

         
            Console.Write("preOrder : ");  
            bst.preOrder(bst.root); 

            
            Console.Write("inOrder : "); 
            bst.inOrder(bst.root);

           
            Console.Write("postOrder : ");
            bst.postOrder(bst.root);
        }
    }

    class Node 
    {
        public int data; 
        public Node left; 
        public Node right;

        // Düğüm yapıcı metod
        public Node(int data)
        {
            this.data = data; // Düğüm verisini atama
            left = null; // Sol alt düğüm başlangıçta null
            right = null; // Sağ alt düğüm başlangıçta null
        }
    }

    class Tree // Ağaç sınıfı
    {
        public Node root; 

        // Ağaç yapıcı metod
        public Tree()
        {
            root = null; 
        }

        // Yeni düğüm oluşturma metodu
        public Node newNode(int data)
        {
            root = new Node(data); 
            return root;
        }

        //düğüm ekleme metodu
        public Node insert(Node root, int data)
        {
             Node eleman = new Node(data);
            if (root != null) 
            {
                if (data < root.data) 
                {
                    root.left = insert(root.left, data); 
                }
                else
                {
                    root.right = insert(root.right, data); 
                }
            }
            else
                root = newNode(data); 
            return root; 
        }

        
        public void preOrder(Node root) 
        {
            if (root != null) 
            {
                Console.Write(root.data + "  "); 
                preOrder(root.left); 
                preOrder(root.right); 
            }
        }

        
        public void inOrder(Node root) 
        {
            if (root != null) 
            {
                inOrder(root.left); 
                Console.Write(root.data + "  "); 
                inOrder(root.right); 
            }
        }

      
        public void postOrder(Node root) 
        {
            if (root != null) 
            {
                postOrder(root.left); 
                postOrder(root.right); 
                Console.Write(root.data + "  "); 
            }
        }
    }
}
