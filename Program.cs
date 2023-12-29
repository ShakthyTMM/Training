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
   public class TQueue<T> {
      public TQueue () => mArray = new T[4];

      /// <summary>Capacity of the deque</summary>
      public int Capacity => mArray.Length;

      /// <summary>Count of the elements in the array</summary>
      public int Count => mCount;

      /// <summary>To check whether the deque is empty</summary>
      public bool IsEmpty => mCount == 0;

      /// <summary>To check whether the deque is full</summary>
      public bool IsFull => Capacity == Count;

      /// <summary>Deletes an element from the front of the deque</summary>
      /// <returns>Returns the element to be deleted</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T Dequeue_front () {
         if (IsEmpty) throw new InvalidOperationException ();
         T item = mArray[mFront];
         if (mFront == (mFront + mRear) % Capacity && mCount == 1) mFront = -1;
         mCount--;
         mFront = (mFront + 1) % Capacity;
         return item;
      }

      /// <summary>Deletes an element from the rear of the deque</summary>
      /// <returns>Returns the element to be deleted</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T Dequeue_rear () {
         if (IsEmpty) throw new InvalidOperationException ();
         if (mRear < 1) mRear = Capacity - 1;
         else mRear = (mRear - 1) % Capacity;
         T item = mArray[mRear];
         mCount--;
         return item;
      }

      /// <summary>Adds elements to the front of the deque</summary>
      /// <param name="a">The value of the element to be added</param>
      public void Enqueue_front (T a) {
         if (IsFull) ResizeArray ();
         if (mFront < 1) mFront = Capacity - 1;
         else mFront = (mFront - 1) % Capacity; ;
         mArray[mFront] = a;
         mCount++;
      }

      /// <summary>Adds elements to the rear of the deque</summary>
      /// <param name="a">The value of the element to be added</param>
      public void Enqueue_rear (T a) {
         if (IsFull) ResizeArray ();
         mArray[mRear] = a;
         mRear = (mRear + 1) % Capacity;
         mCount++;
      }

      /// <summary>Returns the first element added to the front of the deque</summary>
      /// <returns>Returns the first element of the queue</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T Peek_front () {
         if (IsEmpty) throw new InvalidOperationException ();
         return mArray[mFront];
      }

      /// <summary>Returns the first element added to the rear of the deque</summary>
      /// <returns>Returns the first element of the queue</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T Peek_rear () {
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
