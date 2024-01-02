using deque;
namespace TestDeque {
   [TestClass]
   public class UnitTest1 {

      [TestMethod]
      public void TestDequeueFront () {
         for (int i = 0; i < 5; i++) mQueue.EnqueueFront (i);
         mQueue.DequeueFront ();
         mQueue.DequeueFront ();
         Assert.AreEqual (3, mQueue.Count);
         Assert.AreEqual (2, mQueue.DequeueFront ());
         mQueue.DequeueFront ();
         mQueue.DequeueFront ();
         Assert.ThrowsException<InvalidOperationException> (() => mQueue.DequeueFront ());
      }

      [TestMethod]
      public void TestDequeueRear () {
         for (int i = 0; i < 5; i++) mQueue.EnqueueRear (i);
         mQueue.DequeueRear ();
         mQueue.DequeueRear ();
         Assert.AreEqual (3, mQueue.Count);
         Assert.AreEqual (2, mQueue.DequeueRear ());
         mQueue.DequeueRear ();
         mQueue.DequeueRear ();
         Assert.ThrowsException<InvalidOperationException> (() => mQueue.DequeueRear ());
      }

      [TestMethod]
      public void TestEnqueueFront () {
         for (int i = 0; i < 5; i++) mQueue.EnqueueFront (i);
         Assert.AreEqual (5, mQueue.Count);
         Assert.AreEqual (8, mQueue.Capacity);
      }

      [TestMethod]
      public void TestEnqueueRear () {
         for (int i = 0; i < 5; i++) mQueue.EnqueueRear (i);
         Assert.AreEqual (5, mQueue.Count);
         Assert.AreEqual (8, mQueue.Capacity);
      }

      [TestMethod]
      public void TestPeekFront () {
         for (int i = 0; i < 5; i++) mQueue.EnqueueFront (i);
         Assert.AreEqual (4, mQueue.PeekFront ());
         for (int i = 0; i < 5; i++) mQueue.DequeueFront ();
         Assert.ThrowsException<InvalidOperationException> (() => mQueue.PeekFront ());
      }

      [TestMethod]
      public void TestPeekRear () {
         for (int i = 0; i < 5; i++) mQueue.EnqueueRear (i);
         Assert.AreEqual (4, mQueue.PeekRear ());
         for (int i = 0; i < 5; i++) mQueue.DequeueRear ();
         Assert.ThrowsException<InvalidOperationException> (() => mQueue.PeekRear ());
      }

      TDeque<int> mQueue = new ();
   }
}