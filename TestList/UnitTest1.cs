using ListProgram;

namespace TestList {
   [TestClass]
   public class UnitTest1 {

      ///<summary>To test the Add method's functionality</summary>
      [TestMethod]
      public void TestAdd () {
         for (int i = 1; i <= 3; i++)
            mList.Add (i);
         Assert.AreEqual (3, mList.Count);
         mList.Add (4);
         Assert.AreEqual (4, mList.Capacity);
         mList.Add (5);
         Assert.AreEqual (8, mList.Capacity);
         Assert.AreEqual (2, mList[1]);
         mList[3] = 10;
         Assert.AreEqual (10, mList[3]);
         Assert.ThrowsException<IndexOutOfRangeException> (() => mList[10]);
         Assert.ThrowsException<IndexOutOfRangeException> (() => mList[10] = 4);
      }

      ///<summary>To test the Remove method's functionality</summary>
      [TestMethod]
      public void TestRemove () {
         for (int i = 1; i <= 3; i++)
            mList.Add (i);
         Assert.IsTrue (mList.Remove (3));
         Assert.AreEqual (2, mList.Count);
         Assert.AreEqual (4, mList.Capacity);
         for (int i = 5; i <= 7; i++)
            mList.Add (i);
         Assert.AreEqual (8, mList.Capacity);
         Assert.IsFalse (mList.Remove (-5));
      }

      ///<summary>To test the RemoveAt method's functionality</summary>
      [TestMethod]
      public void TestRemoveAt () {
         for (int i = 1; i <= 3; i++)
            mList.Add (i);
         mList.RemoveAt (2);
         Assert.AreEqual (2, mList.Count);
         Assert.ThrowsException<InvalidOperationException> (() => mList.RemoveAt (10));
      }

      ///<summary>To test the Insert method's functionality</summary>
      [TestMethod]
      public void TestInsert () {
         for (int i = 1; i <= 4; i++)
            mList.Add (i);
         mList.Insert (1, 5);
         Assert.AreEqual (5, mList.Count);
         Assert.ThrowsException<InvalidOperationException> (() => mList.Insert (10, 5));
         Assert.AreEqual (8, mList.Capacity);
      }

      ///<summary>To test the Clear method's functionality</summary>
      [TestMethod]
      public void TestClear () {
         mList.Add (1);
         mList.Clear ();
         Assert.AreEqual (0, mList.Count);
         Assert.ThrowsException<InvalidOperationException> (mList.Clear);
      }

      ///<summary>To test the Display method's functionality</summary>
      [TestMethod]
      public void TestDisplay () {
         Assert.ThrowsException<InvalidOperationException> (mList.Display);
         mList.Add (1);
         mList.Display ();
      }

      MyList<int> mList = new ();
   }
}