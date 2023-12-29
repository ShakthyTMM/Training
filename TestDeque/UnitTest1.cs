using deque;
namespace TestDeque {
   [TestClass]
   public class UnitTest1 {

      [TestMethod]
      public void TestDequeue_front () {
         for (int i = 0; i < 5; i++) mQueue.Enqueue_front (i);
         mQueue.Dequeue_front ();
         mQueue.Dequeue_front ();
         Assert.AreEqual (3, mQueue.Count);
         Assert.AreEqual (2, mQueue.Dequeue_front ());
         mQueue.Dequeue_front ();
         mQueue.Dequeue_front ();
         Assert.ThrowsException<InvalidOperationException> (() => mQueue.Dequeue_front ());
      }

      [TestMethod]
      public void TestDequeue_rear () {
         for (int i = 0; i < 5; i++) mQueue.Enqueue_rear (i);
         mQueue.Dequeue_rear ();
         mQueue.Dequeue_rear ();
         Assert.AreEqual (3, mQueue.Count);
         Assert.AreEqual (2, mQueue.Dequeue_rear ());
         mQueue.Dequeue_rear ();
         mQueue.Dequeue_rear ();
         Assert.ThrowsException<InvalidOperationException> (() => mQueue.Dequeue_rear ());
      }

      [TestMethod]
      public void TestEnqueue_front () {
         for (int i = 0; i < 5; i++) mQueue.Enqueue_front (i);
         Assert.AreEqual (5, mQueue.Count);
         Assert.AreEqual (8, mQueue.Capacity);
      }

      [TestMethod]
      public void TestEnqueue_rear () {
         for (int i = 0; i < 5; i++) mQueue.Enqueue_rear (i);
         Assert.AreEqual (5, mQueue.Count);
         Assert.AreEqual (8, mQueue.Capacity);
      }

      [TestMethod]
      public void TestPeek_front () {
         for (int i = 0; i < 5; i++) mQueue.Enqueue_front (i);
         Assert.AreEqual (4, mQueue.Peek_front ());
         for (int i = 0; i < 5; i++) mQueue.Dequeue_front ();
         Assert.ThrowsException<InvalidOperationException> (() => mQueue.Peek_front ());
      }

      [TestMethod]
      public void TestPeek_rear () {
         for (int i = 0; i < 5; i++) mQueue.Enqueue_rear (i);
         Assert.AreEqual (4, mQueue.Peek_rear ());
         for (int i = 0; i < 5; i++) mQueue.Dequeue_rear ();
         Assert.ThrowsException<InvalidOperationException> (() => mQueue.Peek_rear ());
      }

      TQueue<int> mQueue = new ();
   }
}