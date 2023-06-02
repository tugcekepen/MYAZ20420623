using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.Trees.BinaryTree.BinarySearchTree
{
    public class BST<T> where T : IComparable
    {
        public Node<T> Root { get; set; }

        public BST()
        {
            Root = null;
        }

        public BST(Node<T> node)
        {
            Root = node;
        }

        public BST(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void Add(T value)
        {
            var newNode = new Node<T>(value); //eklenecek değeri node'a dönüştür

            // Önce Root'u kontrol ediyoruz
            if (Root == null)
            {
                Root = newNode;
                return;
            }

            var current = Root; //current gezinme aracımız
            Node<T> parent;
            while (true)
            {
                parent = current;
                // Sol-taraf
                if (value.CompareTo(current.Value) < 0) //üstünde durduğumuz node'un değerinden küçük ise sol tarafa alacağız
                {
                    current = current.Left; //current'ı sola yönlendireceğimize karar verdiğimiz için sola taşıyoruz ve oradaki node'a bakıyoruz
                    if (current == null) //oradaki node yani yeni üzerinde durduğumuz node boşsa o zaman eklenecek node'u buraya bağlayabiliriz
                    {
                        parent.Left = newNode;
                        return;
                    }
                }
                // Sağ-taraf
                else
                {
                    current = current.Right; //current'ı sağa yönlendireceğimize karar verdiğimiz için sola taşıyoruz ve oradaki node'a bakıyoruz
                    if (current == null) //oradaki node yani yeni üzerinde durduğumuz node boşsa o zaman eklenecek node'u buraya bağlayabiliriz
                    {
                        parent.Right = newNode;
                        return;
                    }
                }
            }
        }

        public T FindMin(Node<T> root)
        {
            T minValue = root.Value;
            while (root.Left != null)
            {
                minValue = root.Left.Value;
                root = root.Left;
            }
            return minValue;
        }

        public T FindMin()
        {
            Node<T> current = Root;
            T minValue = current.Value;
            while (current.Left != null)
            {
                minValue = current.Left.Value;
                current = current.Left;
            }
            return minValue;
        }

        public T FindMax()
        {
            if (Root == null)
                throw new Exception("Empty tree!");

            var current = Root;
            while (!(current.Right == null))
                current = current.Right;
            return current.Value;
        }

        public Node<T> Find(T key)
        {
            if (Root == null)
                throw new Exception("Empty tree!");

            var current = Root;

            while (current.Value.CompareTo(key) != 0)
            {
                if (key.CompareTo(current.Value) < 0)
                    current = current.Left;
                else
                    current = current.Right;
                if (current == null)
                    throw new Exception("Could not found!");
            }
            return current;
        }

        public Node<T> Remove(Node<T> root, T key)
        {
            if (root == null)
                throw new Exception("Empty tree!");
            if (key.CompareTo(root.Value) < 0)
            {
                root.Left = Remove(root.Left, key);
            }
            else if (key.CompareTo(root.Value) > 0)
            {
                root.Right = Remove(root.Right, key);
            }
            else
            {
                // silme prosedürü
                // tek cocuklu ya da cocuksuz
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                // iki cocuk var ise
                root.Value = FindMin(root.Right);
                root.Right = Remove(root.Right, root.Value);
            }
            return root;
        }

        public static void InOrder(Node<T> root)
        {
            if (!(root == null))
            {
                InOrder(root.Left);
                root.ToString();
                InOrder(root.Right);
            }
        }
    }
}
