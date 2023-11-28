using ListProgram;

namespace TestList {
   [TestClass]
   public class UnitTest1 {

      ///<summary>To test the Add method's functionality</summary>
      [TestMethod]
      public void TestAdd () {
         for (int i = 1; i <= 3; i++) {
            myList.Add (i);
            mList.Add (i);
         }
         Assert.AreEqual (mList.Count, myList.Count);
         myList.Add (4);
         mList.Add (4);
         Assert.AreEqual (mList.Capacity, myList.Capacity);
         myList.Add (5);
         mList.Add (5);
         Assert.AreEqual (mList.Capacity, myList.Capacity);
         Assert.AreEqual (mList[1], myList[1]);
         myList[3] = 10;
         mList[3] = 10;
         Assert.AreEqual (mList[3], myList[3]);
         Assert.ThrowsException<IndexOutOfRangeException> (() => myList[10]);
         Assert.ThrowsException<IndexOutOfRangeException> (() => myList[10] = 4);
      }

      ///<summary>To test the Remove method's functionality</summary>
      [TestMethod]
      public void TestRemove () {
         for (int i = 1; i <= 3; i++) {
            myList.Add (i);
            mList.Add (i);
         }
         Assert.AreEqual (mList.Remove (3), myList.Remove (3));
         Assert.AreEqual (mList.Count, myList.Count);
         Assert.AreEqual (mList.Capacity, myList.Capacity);
         for (int i = 5; i <= 7; i++) {
            myList.Add (i);
            mList.Add (i);
         }
         Assert.AreEqual (mList.Capacity, myList.Capacity);
         Assert.AreEqual (mList.Remove (-5), myList.Remove (-5));
      }

      ///<summary>To test the RemoveAt method's functionality</summary>
      [TestMethod]
      public void TestRemoveAt () {
         for (int i = 1; i <= 3; i++) {
            myList.Add (i);
            mList.Add (i);
         }
         myList.RemoveAt (2);
         mList.RemoveAt (2);
         Assert.AreEqual (mList.Count, myList.Count);
         Assert.ThrowsException<InvalidOperationException> (() => myList.RemoveAt (10));
      }

      ///<summary>To test the Insert method's functionality</summary>
      [TestMethod]
      public void TestInsert () {
         for (int i = 1; i <= 4; i++) {
            myList.Add (i);
            mList.Add (i);
         }
         myList.Insert (1, 5);
         mList.Insert (1, 5);
         Assert.AreEqual (mList.Count, myList.Count);
         Assert.ThrowsException<InvalidOperationException> (() => myList.Insert (10, 5));
         Assert.AreEqual (mList.Capacity, myList.Capacity);
      }

      ///<summary>To test the Clear method's functionality</summary>
      [TestMethod]
      public void TestClear () {
         myList.Add (1);
         mList.Add (1);
         myList.Clear ();
         mList.Clear ();
         Assert.AreEqual (mList.Count, myList.Count);
         Assert.ThrowsException<InvalidOperationException> (myList.Clear);
      }

      ///<summary>To test the Display method's functionality</summary>
      [TestMethod]
      public void TestDisplay () {
         Assert.ThrowsException<InvalidOperationException> (myList.Display);
         myList.Add (1);
         myList.Display ();
      }

      MyList<int> myList = new ();
      List<int> mList = new ();
   }
}