using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures {
    public interface IPriorityQueue<T> {
		public bool IsEmpty { get; }
		public int Add(T key);
		public T Pop();
		public int Remove(T key);
		public void Clear();
		public int ChangePriority(int pos, T key);
		public string ToString();
	}
}
