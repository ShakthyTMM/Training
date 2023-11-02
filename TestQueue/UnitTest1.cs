using QueueProgram;

namespace TestQueue
{
   [TestClass]
   public class UnitTest1
   {

      TQueue<int> queue2 = new();

      [TestMethod]
      public void TestEnqueue()
      {
         queue2.Enqueue(1);
         queue2.Enqueue(2);
         queue2.Enqueue(3);
         queue2.Enqueue(4);
         Assert.AreEqual(4, queue2.Capacity);
         queue2.Enqueue(5);
         Assert.AreEqual(5, queue2.Count);
         Assert.AreEqual(8, queue2.Capacity);
      }
      [TestMethod]
      public void TestDequeue()
      {
         queue2.Enqueue(1);
         queue2.Enqueue(2);
         queue2.Enqueue(3);
         queue2.Enqueue(4);
         queue2.Dequeue();
         queue2.Dequeue();
         Assert.AreEqual(2, queue2.Count);
         queue2.Dequeue();
         queue2.Dequeue();
         Assert.ThrowsException<InvalidOperationException>(() => queue2.Dequeue());
      }
      [TestMethod]
      public void TestPeek()
      {
         queue2.Enqueue(1);
         queue2.Enqueue(2);
         queue2.Enqueue(3);
         Assert.AreEqual(1, queue2.Peek());
         queue2.Dequeue();
         queue2.Dequeue();
         queue2.Dequeue();
         Assert.ThrowsException<InvalidOperationException>(() => queue2.Peek());
      }
   }
}