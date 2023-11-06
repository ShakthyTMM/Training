using ListProgram;
using System;

namespace TestList {
   [TestClass]
   public class UnitTest1 {
      MyList<int> list = new ();
      [TestMethod]
      public void TestAdd () {
         list.Add (1);
         list.Add (2);
         list.Add (3);
         Assert.AreEqual (3, list.Count);
         list.Add (4);
         Assert.AreEqual (4, list.Capacity);
         list.Add (5);
         Assert.AreEqual (8, list.Capacity);
         Assert.AreEqual (2, list[1]);
         list[3] = 10;
         Assert.AreEqual (10, list[3]);
         Assert.ThrowsException<IndexOutOfRangeException> (() => list[10]);
         Assert.ThrowsException<IndexOutOfRangeException> (() => list[10] = 4);

      }
      [TestMethod]
      public void TestRemove () {
         list.Add (1);
         list.Add (2);
         list.Add (3);
         Assert.IsTrue (list.Remove (3));
         Assert.AreEqual (2, list.Count);
         Assert.AreEqual (4, list.Capacity);
         list.Add (5);
         list.Add (6);
         list.Add (7);
         Assert.AreEqual (8, list.Capacity);
         Assert.IsFalse (list.Remove (-5));
      }
      [TestMethod]
      public void TestRemoveAt () {
         list.Add (1);
         list.Add (2);
         list.Add (3);
         list.RemoveAt (2);
         Assert.AreEqual (2, list.Count);
         Assert.ThrowsException<InvalidOperationException> (() => list.RemoveAt (10));
      }
      [TestMethod]
      public void TestInsert () {
         list.Add (1);
         list.Add (2);
         list.Add (3);
         list.Add (4);
         list.Insert (1, 5);
         Assert.AreEqual (5, list.Count);
         Assert.ThrowsException<InvalidOperationException> (() => list.Insert (10, 5));
         Assert.AreEqual (8, list.Capacity);
      }
      [TestMethod]
      public void TestClear () {
         list.Add (1);
         list.Clear ();
         Assert.AreEqual (0, list.Count);
         Assert.ThrowsException<InvalidOperationException> (() => list.Clear ());
      }
      [TestMethod]
      public void TestDisplay () {
         Assert.ThrowsException<InvalidOperationException>(() => list.Display ());
         list.Add (1);
         list.Add (2);
         list.Display ();
      }
   }
}