using StackProgram;

namespace TestStack {
    [TestClass]
    public class UnitTest1 {

        /// <summary>To test the Push method's functionality</summary>
        [TestMethod]
        public void TestPush () {
            for (int i = 1; i <= 3; i++) {
                myStack.Push (i);
                mStack.Push (i);
            }
            myStack.Push (4);
            mStack.Push (4);
            Assert.AreEqual(mStack.Count, myStack.Count);
            Assert.AreEqual (4, myStack.Capacity);
            myStack.Push (5);
            Assert.AreEqual (8, myStack.Capacity);
        }

        /// <summary>To test the Pop method's functionality</summary>
        [TestMethod]
        public void TestPop () {
            for (int i = 1; i <= 3; i++) { 
                myStack.Push (i); 
                mStack.Push (i);
            }
            for(int i = 1; i < 3; i++) {
                myStack.Pop ();
                mStack.Pop ();
            }
            Assert.AreEqual (mStack.Count, myStack.Count);
            myStack.Pop ();
            Assert.ThrowsException<InvalidOperationException> (() => myStack.Pop ());
        }

        /// <summary>To test the Peek method's functionality</summary>
        [TestMethod]
        public void TestPeek () {
            for (int i = 1; i <= 3; i++) {
                myStack.Push (i);
                mStack.Push (i);
            }
            Assert.AreEqual (mStack.Peek(), myStack.Peek ());
            for (int i = 1; i <= 3; i++) 
                myStack.Pop ();
            Assert.ThrowsException<InvalidOperationException> (() => myStack.Peek ());
        }

        /// <summary>To test the Display method's functionality</summary>
        [TestMethod]
        public void TestDisplay () {
            for (int i = 1; i <= 3; i++)
                myStack.Push (i);
            myStack.Display ();
        }

        MyStack<int> myStack = new ();
        Stack<int> mStack= new ();
    }
}