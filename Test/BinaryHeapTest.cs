using NUnit.Framework;
using DataStructures;
namespace Test {
    public class BinaryHeapTest {
        BinaryHeapMin<int> heap;
        [SetUp]
        public void SetUp() {
            heap = new BinaryHeapMin<int>(10);
		}

		[Test]
        public void AddTest() {
			Assert.AreEqual(0, heap.Add(12));
			Assert.AreEqual(0, heap.Add(14));
			Assert.AreEqual(0, heap.Add(15));
			Assert.AreEqual(0, heap.Add(20));
			Assert.AreEqual(0, heap.Add(16));
			Assert.AreEqual(0, heap.Add(17));
			Assert.AreEqual(0, heap.Add(19));
			Assert.AreEqual(0, heap.Add(24));
			Assert.AreEqual(0, heap.Add(18));
			Assert.AreEqual(0, heap.Add(10));
			Assert.AreEqual("10\t12\t15\t18\t14\t17\t19\t24\t20\t16", heap.ToString());
		}

		[Test]
		public void RemoveTest() {
			//Assert.AreEqual(-2, heap.Remove(4));
			heap.Add(12);
			heap.Add(14);
			heap.Add(15);
			heap.Add(20);
			heap.Add(16);
			heap.Add(17);
			heap.Add(19);
			heap.Add(24);
			heap.Add(18);
			heap.Add(10);
			Assert.AreEqual(-1, heap.Remove(13));
			Assert.AreEqual(0, heap.Remove(18));
			Assert.AreEqual("10\t12\t15\t16\t14\t17\t19\t24\t20", heap.ToString());
			Assert.AreEqual(0, heap.Remove(10));
			Assert.AreEqual("12\t14\t15\t16\t20\t17\t19\t24", heap.ToString());
			Assert.AreEqual(0, heap.Remove(12));
			Assert.AreEqual("14\t16\t15\t24\t20\t17\t19", heap.ToString());
			Assert.AreEqual(0, heap.Remove(16));
			Assert.AreEqual("14\t19\t15\t24\t20\t17", heap.ToString());
			Assert.AreEqual(0, heap.Remove(15));
			Assert.AreEqual("14\t19\t17\t24\t20", heap.ToString());
			Assert.AreEqual(0, heap.Remove(20));
			Assert.AreEqual("14\t19\t17\t24", heap.ToString());
			Assert.AreEqual(0, heap.Remove(14));
			Assert.AreEqual("17\t19\t24", heap.ToString());
			Assert.AreEqual(0, heap.Remove(17));
			Assert.AreEqual("19\t24", heap.ToString());
			Assert.AreEqual(0, heap.Remove(19));
			Assert.AreEqual("24", heap.ToString());
			Assert.AreEqual(0, heap.Remove(24));
			Assert.AreEqual("", heap.ToString());
		}
    }
}
