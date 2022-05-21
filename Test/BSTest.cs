using NUnit.Framework;
using DataStructures;
namespace Test {
    public class Tests {
        private BSTree<int> tree;
        [SetUp]
        public void Setup() {
            tree = new BSTree<int>();
        }

        [Test]
        public void Test1() {
            Assert.AreEqual("", tree.PreOrder());
            Assert.AreEqual("", tree.InOrder());
            Assert.AreEqual("", tree.PostOrder());

            tree.Add(5);
            tree.Add(-2);
            tree.Add(10);
            tree.Add(9);
            tree.Add(12);

            Assert.AreEqual("5\t-2\t10\t9\t12", tree.PreOrder());
            Assert.AreEqual("-2\t9\t12\t10\t5", tree.PostOrder());
            Assert.AreEqual("-2\t5\t9\t10\t12", tree.InOrder());
        }
    }
}