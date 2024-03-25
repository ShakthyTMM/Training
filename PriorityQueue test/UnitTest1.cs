using PriorityQueue;

namespace PriorityQueue_Test;
[TestClass]
public class UnitTest1 {
   /// <summary>Tests the dequeue operation of the priority queue</summary>
   [TestMethod]
   public void TestDequeue () {
      Random random = new ();
      for (int i = 0; i < 10; i++) {
         int r = random.Next (1, 100);
         mPQ.Enqueue (r);
         mQueue.Enqueue (r);
      }
      for (int i = 0; i < 10; i++) Assert.AreEqual (mPQ.Dequeue (), mQueue.Dequeue ());
      Assert.ThrowsException<InvalidOperationException> (() => mPQ.Dequeue ());
      // Checking for repeated input
      var data = new List<int> { 10, 9, 8, 7, 3, 6, 5, 4, 3, 4, 2 };
      for (int i = 0; i < data.Count; i++) {
         var r = data[i];
         mPQ.Enqueue (r);
         mQueue.Enqueue (r);
      }
      for (int i = 0; i < data.Count; i++) Assert.AreEqual (mPQ.Dequeue (), mQueue.Dequeue ());
   }

   /// <summary>Tests the enqueue operation of the priority queue</summary>
   [TestMethod]
   public void TestEnqueue () {
      var data = new List<int> { 1, 2, 4, 5, 3 };    // Expected order 
      for (int i = 5; i > 0; i--) mPQ.Enqueue (i);
      Assert.IsTrue (data.SequenceEqual (mPQ.List));
   }

   PriorityQueue<int> mPQ = new ();
   TestQueue<int> mQueue = new ();
}
