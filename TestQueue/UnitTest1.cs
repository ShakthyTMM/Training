using QueueProgram;
namespace TestQueue {
   [TestClass]
   public class UnitTest1 {
      TQueue<int> queue = new ();
      [TestMethod]
      public void TestEnqueue () {
         queue.Enqueue (1);
         queue.Enqueue (2);
         queue.Enqueue (3);
         queue.Enqueue (4);
         Assert.AreEqual (4, queue.Capacity);
         queue.Enqueue (5);
         Assert.AreEqual (5, queue.Count);
         Assert.AreEqual (8, queue.Capacity);
      }

      [TestMethod]
      public void TestDequeue () {
         queue.Enqueue (1);
         queue.Enqueue (2);
         queue.Enqueue (3);
         queue.Enqueue (4);
         queue.Dequeue ();
         queue.Dequeue ();
         Assert.AreEqual (2, queue.Count);
         queue.Dequeue ();
         queue.Dequeue ();
         Assert.ThrowsException<InvalidOperationException> (() => queue.Dequeue ());
      }

      [TestMethod]
      public void TestPeek () {
         queue.Enqueue (1);
         queue.Enqueue (2);
         queue.Enqueue (3);
         Assert.AreEqual (1, queue.Peek ());
         queue.Dequeue ();
         queue.Dequeue ();
         queue.Dequeue ();
         Assert.ThrowsException<InvalidOperationException> (() => queue.Peek ());
      }
   }
}