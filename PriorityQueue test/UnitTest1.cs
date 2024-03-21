using PriorityQueue;

namespace PriorityQueue_Test;
[TestClass]
public class UnitTest1 {
   /// <summary>Tests the dequeue operation of the priority queue</summary>
   [TestMethod]
   public void TestDequeue () {
      Random random = new ();
      (int[] data, int[] result) = (new int[10], new int[10]);
      for (int i = 0; i < 10; i++) {
         data[i] = random.Next (1, 100);
         mPQ.Enqueue (data[i]);
      }
      Array.Sort (data, 0, data.Length);
      for (int i = 0; i < 10; i++) result[i] = mPQ.Dequeue ();
      Assert.IsTrue (IsEqual (data, result));
      Assert.ThrowsException<InvalidOperationException> (() => mPQ.Dequeue ());
   }

   bool IsEqual (int[] data, int[] result) {    // Checks whether given two arrays are equal
      for (int i = 0; i < data.Length; i++)
         if (data[i] != result[i]) return false;
      return true;
   }

   /// <summary>Tests the enqueue operation of the priority queue</summary>
   [TestMethod]
   public void TestEnqueue () {
      int[] data = new[] { 1, 2, 4, 5, 3 };
      mPQ.Enqueue (5);
      mPQ.Enqueue (4);
      mPQ.Enqueue (3);
      mPQ.Enqueue (2);
      mPQ.Enqueue (1);
      Assert.IsTrue (IsEqual (data, mPQ.List.ToArray ()));
   }

   PriorityQueue<int> mPQ = new ();
}
