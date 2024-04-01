﻿// ----------------------------------------------------------------------------------------
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
   public PriorityQueue () { }
   #endregion

   #region Implementation --------------------------------------------------
   /// <summary>Returns the number of elements in the priority queue</summary>
   public int Count => mList.Count;

   /// <summary>Checks whether the priority queue is empty</summary>
   public bool IsEmpty => Count == 1;

   /// <summary>Returns true if the given list and priority queue are equal</summary>
   public bool AreSequenceEqual (List<T> data) => data.SequenceEqual (mList);

   /// <summary>Deletes an element from the priority queue</summary>
   /// <returns>Returns the deleted element</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Dequeue () {
      if (IsEmpty) throw new InvalidOperationException ();
      (mList[^1], mList[1]) = (mList[1], mList[^1]);
      T item = mList[^1]; mList.RemoveAt (Count - 1);
      if (Count > 2) SiftDown (1);
      return item;
   }

   /// <summary>Adds elements to the priority queue</summary>
   public void Enqueue (T value) { mList.Add (value); SiftUp (Count - 1); }

   // Swaps a node that is larger than its childern with the smallest of its childern
   // (thereby moving it down) until it is lesser than both of its childern.
   void SiftDown (int index) {
      int left = index * 2;
      if (left > Count - 1) return;
      var (right, leftChild, parent) = (left + 1, mList[left], mList[index]);
      if (right <= Count - 1) {
         var rightChild = mList[right];
         if (leftChild.CompareTo (parent) >= 0 && rightChild.CompareTo (parent) >= 0) return;
         int smallChild = (leftChild.CompareTo (rightChild) >= 0) ? right : left;
         (mList[index], mList[smallChild]) = (mList[smallChild], mList[index]);
         SiftDown (smallChild);
      } else {
         if (leftChild.CompareTo (parent) >= 0) return;
         (mList[index], mList[left]) = (mList[left], mList[index]);
      }
   }

   // Swaps a node that is lesser than its parent (thereby moving it up)
   // until it is no lesser than the node above it.
   void SiftUp (int index) {
      int parentNode = index / 2;
      var (parent, value) = (mList[parentNode], mList[index]);
      if (value.CompareTo (parent) >= 0) return;
      else {
         (mList[index], mList[parentNode]) = (mList[parentNode], mList[index]);
         SiftUp (parentNode);
      }
   }
   #endregion

   #region Private data ----------------------------------------------------
   List<T> mList = new () { default };    // Underlying data structure which stores the data of priority queue
   #endregion
}
#endregion

#region class TestQueue --------------------------------------------------------------------------------------------
// Priority Queue's other implementation which is always correct and
// used for testing purpose
public class TestQueue<T> {
   #region Constructor -----------------------------------------------------
   public TestQueue () { }
   #endregion

   #region Implementation --------------------------------------------------
   /// <summary>Checks whether the queue is empty</summary>
   public bool IsEmpty => mList.Count == 1;

   /// <summary>Adds elements to the queue</summary>
   public void Enqueue (T value) => mList.Add (value);

   /// <summary>Deletes an element from the queue</summary>
   /// <returns>Returns the deleted element</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Dequeue () {
      if (IsEmpty) throw new InvalidOperationException ();
      mList.Sort ();
      T item = mList[1]; mList.Remove (item);
      return item;
   }
   #endregion

   #region Private data ----------------------------------------------------
   List<T> mList = new () { default };
   #endregion
}
#endregion
class Program {
   static void Main () { }
}
