// ----------------------------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ----------------------------------------------------------------------------------------
// Program.cs
// Deque or double ended queue
// To implement a double ended queue which allows insertion and deletion both in front and rear end
// ----------------------------------------------------------------------------------------
namespace deque {
   internal class Program {
      static void Main (string[] args) {
      }
   }
   public class TDeque<T> {
      public TDeque () => mArray = new T[4];

      /// <summary>Capacity of the deque</summary>
      public int Capacity => mArray.Length;

      /// <summary>Count of the elements in the array</summary>
      public int Count => mCount;

      /// <summary>To check whether the deque is empty</summary>
      public bool IsEmpty => mCount == 0;

      /// <summary>To check whether the deque is full</summary>
      public bool IsFull => Capacity == Count;

      /// <summary>Checks the given index for 1</summary>
      /// <param name="mIndex">Index to be checked</param>
      /// <returns>Returns the appropriate index value</returns>
      public int Check(int mIndex)=> mIndex < 1 ? Capacity - 1 : (mIndex - 1) % Capacity;

      /// <summary>Deletes an element from the front of the deque</summary>
      /// <returns>Returns the element to be deleted</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T DequeueFront () {
         if (IsEmpty) throw new InvalidOperationException ();
         T item = mArray[mFront];
         mArray[mFront]=default;
         if (mFront == (mFront + mRear) % Capacity && mCount == 1) mFront = -1;
         mCount--;
         mFront = (mFront + 1) % Capacity;
         return item;
      }

      /// <summary>Deletes an element from the rear of the deque</summary>
      /// <returns>Returns the element to be deleted</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T DequeueRear () {
         if (IsEmpty) throw new InvalidOperationException ();
         mRear = Check(mRear);
         T item = mArray[mRear];
         mArray[mRear] = default;
         mCount--;
         return item;
      }

      /// <summary>Adds elements to the front of the deque</summary>
      /// <param name="a">The value of the element to be added</param>
      public void EnqueueFront (T a) {
         if (IsFull) ResizeArray ();
         mFront = Check(mFront);
         mArray[mFront] = a;
         mCount++;
      }

      /// <summary>Adds elements to the rear of the deque</summary>
      /// <param name="a">The value of the element to be added</param>
      public void EnqueueRear (T a) {
         if (IsFull) ResizeArray ();
         mArray[mRear] = a;
         mRear = (mRear + 1) % Capacity;
         mCount++;
      }

      /// <summary>Returns the first element added to the front of the deque</summary>
      /// <returns>Returns the first element of the queue</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T PeekFront () {
         if (IsEmpty) throw new InvalidOperationException ();
         return mArray[mFront];
      }

      /// <summary>Returns the first element added to the rear of the deque</summary>
      /// <returns>Returns the first element of the queue</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T PeekRear () {
         if (IsEmpty) throw new InvalidOperationException ();
         return mRear == 0 ? mArray[mRear] : mArray[--mRear];
      }

      /// <summary>Arranges the elements in the array while resizing the array</summary>
      public void ResizeArray () {
         T[] newArray = new T[Capacity * 2];
         for (int i = 0; i < Count; i++) {
            newArray[i] = mArray[i];
         }
         (mArray, mFront, mRear) = (newArray, 0, Count);
      }

      int mFront, mRear, mCount;
      T[] mArray;
   }
}
