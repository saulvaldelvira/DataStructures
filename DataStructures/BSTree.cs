using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures {
    public class BSTree<T> where T : IComparable<T> {
        private BSNode<T> root;
        public int NumElements { get; private set; }
        public bool Empty {
            get {
                return NumElements == 0;
            }
        }
        public BSTree() {
            NumElements = 0;
            root = null;
        }

        public bool Add(T key) {
            if(key == null)
                return false;
            if (root == null) {
                root = new BSNode<T>(key);
                NumElements++;
                return true;
            } else {
                return AddR(root, key);
            }
        }

        private bool AddR(BSNode<T> node, T key) {
            int c = node.Value.CompareTo(key);
            if(c==0)
                return false;
            else if (c < 0) {
                if(node.Right == null) {
                    node.Right = new BSNode<T>(key);
                    NumElements++;
                    return true;
                } else
                    AddR(node.Right, key);

            } else {
                if(node.Left == null) {
                    node.Left = new BSNode<T>(key);
                    NumElements++;
                    return true;
                } else
                    AddR(node.Left, key);
            }
            return false;
        }

        public bool Exists(T key) {
            return ExistsR(root, key);
        }

        private bool ExistsR(BSNode<T> node, T key) {
            if(node == null)
                return false;
            int c = node.Value.CompareTo(key);
            if (c == 0)
                return true;
            else if (c < 0)
                return ExistsR(node.Right, key);
            else
                return ExistsR(node.Left, key);
        }

        private int RemoveNode(T key) {
            if (key == null || root == null)
                return -2;
            else if (!Exists(key))
                return -1;
            root = RemoveNodeR(root, key);
            NumElements--;
            return 0;
        }
        private BSNode<T> RemoveNodeR(BSNode<T> node, T key) {
            int c = node.Value.CompareTo(key);
            if (c == 0) {
                if (node.Right == null && node.Left == null)
                    return null;
                else if (node.Left == null)
                    return node.Right;
                else if (node.Right == null)
                    return node.Left;
                else {
                    T highest = Highest(node.Left);
                    RemoveNode(highest);
                    node.Value = highest;
                    return node;
                }
            }
            else if(c < 0) {
                node.Right = RemoveNodeR(node.Right, key);
                return node;
            } else {
                node.Left = RemoveNodeR(node.Left, key);
                return node;
            }
        }

        private T Highest(BSNode<T> node) {
            if (node.Right == null)
                return node.Value;
            else
                return Highest(node.Right);
        }

        public IEnumerable<T> AllKeys() {
            IList<T> result = new List<T>();
            AllKeysR(result, root);
            return result.ToArray();
        }

        private void AllKeysR(IList<T> l, BSNode<T> node) {
            l.Add(node.Value);
            if(node.Right != null)
                AllKeysR(l, node.Right);
            if(node.Left != null)
                AllKeysR(l, node.Left);

        }

        public string PreOrder() {
            return PreOrderR(root);
        }

        private string PreOrderR(BSNode<T> node) {
            if (node == null) return "";
            if (node.Left == null && node.Right == null)
                return node.Value.ToString();
            else if (node.Left == null)
                return node.Value + "\t" + PreOrderR(node.Right);
            else if (node.Right == null)
                return node.Value + "\t" + PreOrderR(node.Left);
            else
                return node.Value + "\t" + PreOrderR(node.Left) + "\t" + PreOrderR(node.Right);
        }

        public string PostOrder() {
            return PostOrderR(root);
        }

        private string PostOrderR(BSNode<T> node) {
            if (node == null) return "";
            if (node.Left == null && node.Right == null)
                return node.Value.ToString();
            else if (node.Left == null)
                return PostOrderR(node.Right)  + "\t" + node.Value;
            else if (node.Right == null)
                return PostOrderR(node.Left) + "\t" + node.Value;
            else
                return PostOrderR(node.Left) + "\t" + PostOrderR(node.Right)+ "\t" + node.Value;
        }

        public string InOrder() {
            return InOrderR(root);
        }

        private string InOrderR(BSNode<T> node) {
            if (node == null) return "";
            if (node.Left == null && node.Right == null)
                return node.Value.ToString();
            else if (node.Left == null)
                return node.Value + "\t" + InOrderR(node.Right);
            else if (node.Right == null)
                return InOrderR(node.Left) + "\t" + node.Value;
            else
                return InOrderR(node.Left) + "\t" + node.Value + "\t" + InOrderR(node.Right);
        }

        ///OPERADORES

        public static BSTree<T> operator +(BSTree<T> t, T key) {
            t.Add(key);
            return t;
        }

        public static BSTree<T> operator +(BSTree<T> t1, BSTree<T> t2) {
            BSTree<T> result = new BSTree<T>();
            IEnumerable<T> k1 = t1.AllKeys();
            IEnumerable<T> k2 = t2.AllKeys();
            foreach(T k in k1)
                result.Add(k);
            foreach (T k in k2)
                result.Add(k);
            return result;
        }

        public bool this[T key] {
            get {
                return Exists(key);
            }
        }
    }

    internal class BSNode<T> {
        public T Value { get; set; }
        public BSNode<T> Left { get; set; }
        public BSNode<T> Right { get; set; }
        public BSNode(T key) {
            Value = key;
        }
    }
}
