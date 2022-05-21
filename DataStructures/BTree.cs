using System;

namespace DataStructures {
    public class BTree<T> where T : IComparable<T> {
        public int Grado { get; private set; }
        internal int NumKeys { get; private set; }
        internal int NumHijos { get; private set; }
        private BNode<T> _raiz;
        public BTree(int grado) {
            NumKeys = grado - 1;
            NumHijos = grado;
            _raiz = new BNode<T>(grado);
        }

        /*public bool Exists(T key) {
            
        }

        private bool ExistsR(BNode<T> node, T key) {
            for (int i = 0; i < NumKeys; i++) {
                int comp = key.CompareTo(node.Keys[i]);
                if (comp == 0)
                    return true;
                else if (comp > 0) {
                    if (i == NumKeys - 1 || key.CompareTo(node.Keys[i + 1]) < 0)
                        return ExistsR(node.Hijos[i + 1]);

                }
            }
        }*/
    }

    internal class BNode<T> {
        private T[] _keys;
        public T[] Keys {
            get { return _keys; }
        }
        
        private BNode<T>[] _hijos;
        public BNode<T>[] Hijos {
            get { return _hijos; }
        }
        public BNode(int grado) {
            _keys = new T[grado-1];
            _hijos = new BNode<T>[grado];
        }
        
    }
}
