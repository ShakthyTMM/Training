using StackProgram;

namespace TestStack {
    [TestClass]
    public class UnitTest1 {

        /// <summary>To test the Push method's functionality</summary>
        [TestMethod]
        public void TestPush () {
            mStack.Push (1);
            mStack.Push (2);
            mStack.Push (3);
            Assert.AreEqual (3, mStack.Count);
            mStack.Push (4);
            Assert.AreEqual (4, mStack.Capacity);
            mStack.Push (5);
            Assert.AreEqual (8, mStack.Capacity);
        }

        /// <summary>To test the Pop method's functionality</summary>
        [TestMethod]
        public void TestPop () {
            mStack.Push (1);
            mStack.Push (2);
            mStack.Push (3);
            mStack.Pop ();
            mStack.Pop ();
            Assert.AreEqual (1, mStack.Count);
            mStack.Pop ();
            Assert.ThrowsException<InvalidOperationException> (() => mStack.Pop ());
        }

        /// <summary>To test the Peek method's functionality</summary>
        [TestMethod]
        public void TestPeek () {
            mStack.Push (1);
            mStack.Push (2);
            mStack.Push (3);
            Assert.AreEqual (3, mStack.Peek ());
            mStack.Pop ();
            mStack.Pop ();
            mStack.Pop ();
            Assert.ThrowsException<InvalidOperationException> (() => mStack.Peek ());
        }

        /// <summary>To test the Display method's functionality</summary>
        [TestMethod]
        public void TestDisplay () {
            mStack.Push (1);
            mStack.Push (2);
            mStack.Push (3);
            mStack.Display ();
        }

        MyStack<int> mStack = new ();
    }
}