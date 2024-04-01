using PriorityQueue;
namespace PriorityQueue_Test;

[TestClass]
public class UnitTest1 {
   /// <summary>Tests the operations of the priority queue</summary>
   [TestMethod]
   public void TestPriorityQueue () {
      PriorityQueue<int> PQ = new ();
      TestQueue<int> dumbQueue = new ();
      List<List<int>> data = new () {
      new List<int>() { 45, 28, 69, 84, 4, 71, 32, 91, 12, 50 },    // Random values
      new List<int>() { 10, 9, 8, 7, 3, 6, 5, 4, 3, 4, 2 }    // Repeated values
      };
      List<List<int>> enqueueOrder = new () {    // Order of data after enqueue
      new List<int>() {0, 4, 12, 32, 28, 45, 71, 69, 91, 84, 50 },
      new List<int>() {0, 2, 3, 5, 4, 3, 9, 6, 10, 7, 8, 4 }
      };

      for (int listidx = 0; listidx < data.Count; listidx++) {
         var list = data[listidx];
         foreach (var value in list) {
            PQ.Enqueue (value); dumbQueue.Enqueue (value);
         }
         Assert.IsTrue (PQ.AreSequenceEqual (enqueueOrder[listidx]));
         foreach (var _ in list) Assert.AreEqual (PQ.Dequeue (), dumbQueue.Dequeue ());    // Checks dequeue
      }
   }
}
