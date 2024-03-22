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
      SiftDown (mList[1]);
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
   void SiftDown (T value) {
      mIndex = mList.IndexOf (value);
      mLeft = mIndex * 2;
      if (mLeft > mList.Count - 1) return;
      mRight = mLeft + 1;
      if (mRight <= mList.Count - 1) {
         if (mList[mLeft].CompareTo (mList[mIndex]) >= 0 && mList[mRight].CompareTo (mList[mIndex]) >= 0) return;
         int smallChild = (mList[mLeft].CompareTo (mList[mRight]) >= 0) ? mRight : mLeft;
         (mList[mIndex], mList[smallChild]) = (mList[smallChild], mList[mIndex]);
         SiftDown (value);
      } else {
         if (mList[mLeft].CompareTo (mList[mIndex]) >= 0) return;
         (mList[mIndex], mList[mLeft]) = (mList[mLeft], mList[mIndex]);
      }
   }
   int mLeft, mRight;   // Left and right child of the node

   // Swaps a node that is lesser than its parent (thereby moving it up)
   // until it is no lesser than the node above it.
   void SiftUp (T value) {
      mIndex = mList.LastIndexOf (value);
      int parent = mIndex / 2;
      if (mList[mIndex].CompareTo (mList[parent]) >= 0) return;
      else {
         (mList[mIndex], mList[parent]) = (mList[parent], mList[mIndex]);
         SiftUp (value);
      }
   }
   #endregion

   #region Private data ----------------------------------------------------
   List<T> mList;    // Underlying data structure which stores the data of priority queue
   int mIndex;    // Index of the element in use
   #endregion
}
#endregion
class Program {
   static void Main () { }
}
