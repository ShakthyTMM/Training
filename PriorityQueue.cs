// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// PriorityQueue.cs
// Priority Queue
// To implement a PriorityQueue<T> using the heap data structure
// ----------------------------------------------------------------------------------------
namespace PriorityQueue;

#region class PriorityQueue ----------------------------------------------------------------------------------------
public class PriorityQueue<T> where T : IComparable<T> {
   #region Constructor -----------------------------------------------------
   public PriorityQueue () => mList = new List<T> { default };
   #endregion

   #region Implementation --------------------------------------------------
   /// <summary>Checks whether the priority queue is empty</summary>
   public bool IsEmpty { get { return mList.Count == 1; } }

   // Gets the elements of the priority queue (for testing purpose)
   public List<T> List { get { var temp = mList; temp.RemoveAt (0); return temp; } }

   /// <summary>Deletes an element from the priority queue</summary>
   /// <returns>Returns the deleted element</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Dequeue () {
      if (IsEmpty) throw new InvalidOperationException ();
      if (mList.Count == 2) { T element = mList[1]; mList.Remove (mList[1]); return element; }
      (mList[^1], mList[1]) = (mList[1], mList[^1]);
      T item = mList[^1]; mList.RemoveAt (mList.Count - 1);
      SiftDown (1);
      return item;
   }

   /// <summary>Displays the elements of the priority queue</summary>
   /// <exception cref="InvalidOperationException"></exception>
   public void Display () {
      if (IsEmpty) throw new InvalidOperationException ();
      for (int i = 1; i < mList.Count; i++) Console.Write ($"  {mList[i]}  ");
      Console.WriteLine ();
   }

   /// <summary>Adds elements to the priority queue</summary>
   /// <param name="value">Value to be added</param>
   public void Enqueue (T value) { mList.Add (value); SiftUp (value); }

   // Swaps a node that is larger then its childern with the smallest of its childern
   // (thereby moving it down) until it is lesser than both of its childern.
   void SiftDown (int index) {
      mLeft = index * 2;
      if (mLeft > mList.Count - 1) return;
      var left = mList[mLeft]; var parent = mList[index];
      mRight = mLeft + 1;
      if (mRight <= mList.Count - 1) {
         var right = mList[mRight];
         if (left.CompareTo (parent) >= 0 && right.CompareTo (parent) >= 0) return;
         int smallChild = (left.CompareTo (right) >= 0) ? mRight : mLeft;
         (mList[index], mList[smallChild]) = (mList[smallChild], mList[index]);
         SiftDown (smallChild);
      } else {
         if (left.CompareTo (parent) >= 0) return;
         (mList[index], mList[mLeft]) = (mList[mLeft], mList[index]);
      }
   }
   int mLeft, mRight;   // Left and right child of the node

   // Swaps a node that is lesser than its parent (thereby moving it up)
   // until it is no lesser than the node above it.
   void SiftUp (T value) {
      mIndex = mList.LastIndexOf (value);
      mParent = mIndex / 2; var parent = mList[mParent];
      if (value.CompareTo (parent) >= 0) return;
      else {
         (mList[mIndex], mList[mParent]) = (mList[mParent], mList[mIndex]);
         SiftUp (value);
      }
   }
   int mIndex, mParent;    // Parent and child node
   #endregion

   #region Private data ----------------------------------------------------
   List<T> mList;    // Underlying data structure which stores the data of priority queue
   #endregion
}
#endregion

#region class TestQueue --------------------------------------------------------------------------------------------
// Priority Queue's other implementation which is always correct and
// used for testing purpose
public class TestQueue<T> {
   #region Constructor -----------------------------------------------------
   public TestQueue () { mList = new List<T> { default }; }
   #endregion

   #region Implementation --------------------------------------------------
   public bool IsEmpty { get { return mList.Count == 1; } }

   public void Enqueue (T value) => mList.Add (value);

   public T Dequeue () {
      if (IsEmpty) throw new InvalidOperationException ();
      mList.Sort ();
      T item = mList[1]; mList.Remove (item);
      return item;
   }
   #endregion

   #region Private data ----------------------------------------------------
   List<T> mList;
   #endregion
}
#endregion
class Program {
   static void Main () { }
}
