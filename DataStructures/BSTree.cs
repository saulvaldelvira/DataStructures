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


    }

    internal class BSNode<T> {
        public T Value { get; private set; }
        public BSNode<T> Left { get; set; }
        public BSNode<T> Right { get; set; }
        public BSNode(T key) {
            Value = key;
        }
    }
}
