using StackProgram;
namespace TestStack {
    [TestClass]
    public class UnitTest1 {
        MyStack<int> stack = new ();
        [TestMethod]
        public void TestPush () {
            stack.Push (1);
            stack.Push (2);
            stack.Push (3);
            Assert.AreEqual (3, stack.Count);
            stack.Push (4);
            Assert.AreEqual (4, stack.Capacity);
            stack.Push (5);
            Assert.AreEqual (8, stack.Capacity);
        }
        [TestMethod]
        public void TestPop () {
            stack.Push (1);
            stack.Push (2);
            stack.Push (3);
            stack.Pop ();
            stack.Pop ();
            Assert.AreEqual (1, stack.Count);
            stack.Pop ();
            Assert.ThrowsException<InvalidOperationException> (() => stack.Pop ());
        }
        [TestMethod]
        public void TestPeek () {
            stack.Push (1);
            stack.Push (2);
            stack.Push (3);
            Assert.AreEqual (3, stack.Peek ());
            stack.Pop ();
            stack.Pop ();
            stack.Pop ();
            Assert.ThrowsException<InvalidOperationException> (() => stack.Peek ());
        }
        [TestMethod]
        public void TestDisplay () {
            stack.Push (1);
            stack.Push (2);
            stack.Push (3);
            stack.Display ();
        }
    }
}