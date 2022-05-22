using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures {
    public class BinaryHeapMin<T>: IPriorityQueue<T>  where T:IComparable<T>{
        public int NumElements { get; private set; }
        public bool IsEmpty {
            get {
                return NumElements == 0;
            }
        }
        private T[] heap;
        public BinaryHeapMin(int n) {
            NumElements = 0;
            heap = new T[n];
        }
        public int Add(T key) {
            if (key == null)
                return -2;
            if (NumElements == heap.Length)
                return -1;
            heap[NumElements++]=key;
            AscendentFilter(NumElements - 1);
            return 0;
        }

        private void AscendentFilter(int n) {
            while (n > 0) {
                T father = heap[(n - 1) / 2];
                if (father.CompareTo(heap[n]) > 0) {
                    heap[(n - 1) / 2] = heap[n];
                    heap[n] = father;
                }
                n--;
            }
        }
        private void DescendentFilter(int n) {
            while(n < NumElements) {
                T father = heap[n];
                T leftSon = heap[n * 2 + 1];
                T rightSon = heap[n * 2 + 2];
                if (rightSon == null) {
                    if (leftSon == null) {
                        n++;
                        continue;
                    }
                    if (leftSon.CompareTo(father) < 0) {
                        heap[n * 2 + 1] = father;
                        heap[n] = leftSon;
                    }
                }else if (leftSon == null) {
                    if (rightSon.CompareTo(father) < 0) {
                        heap[n*2 + 2] = father;
                        heap[n] = rightSon;
                    }
                } else {
                    int compareRight = father.CompareTo(rightSon),
                        compareLeft = father.CompareTo(leftSon);
                    if (compareLeft > 0) {
                        if(compareRight > 0) {
                            int compare = rightSon.CompareTo(leftSon);
                            if(compare < 0) {
                                heap[n * 2 + 2] = father;
                                heap[n] = rightSon;
                            } else {
                                heap[n * 2 + 1] = father;
                                heap[n] = leftSon;
                            }
                        }
                    }else if (compareRight > 0) {
                        heap[n * 2 + 2] = father;
                        heap[n] = rightSon;
                    }
                }
                n++;
            }
        }

        public int ChangePriority(int pos, T key) {
            if (pos < 0)
                throw new ArgumentOutOfRangeException("The position can not be negative");
            if(key == null)
                throw new ArgumentNullException("The key argument can not be null");
            int compare = heap[pos].CompareTo(key);
            heap[pos] = key;
            if (compare < 0)
                DescendentFilter(pos);
            else if (compare > 0)
                AscendentFilter(pos);
            else return -1;
            return 0;
        }

        public void Clear() {
            for (int i = 0; i < heap.Length; i++)
                heap[i] = default;
            NumElements = 0;
        }

        public T Pop() {
            if (IsEmpty)
                throw new IndexOutOfRangeException("The heap is empty");
            T result = heap[0];
            heap[0] = heap[NumElements - 1];
            heap[NumElements - 1] = default;
            DescendentFilter(0);
            return result;
        }

        public int Remove(T key) {
            if (key == null)
                throw new ArgumentNullException("The specied key to delete was null");
            if (IsEmpty)
                throw new IndexOutOfRangeException("The heap is empty");
            for(int i=0; i<NumElements; i++) {
                if (heap[i].CompareTo(key) == 0) {
                    heap[i] = heap[NumElements-1];
                    heap[--NumElements] = default;
                    DescendentFilter(i);
                    return 0;
                }
            }
            return -1;
        }

        private T GetElement(int pos) {
            return pos < 0 || pos >= NumElements ? null : heap[pos];
        }

        public override string ToString() {
            string result = "";
            for (int i = 0; i < NumElements; i++) {
                result += heap[i].ToString();
                result += i != NumElements - 1 ? "\t" : "";
            }
            return result;
        }
    }
}
