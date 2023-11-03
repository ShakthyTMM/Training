﻿// ---------------------------------------------------------------------
// Training 
// Copyright (c) Metamation India.
// ---------------------------------------------------------------------
// Program.cs
// QueueProgram
// Create a queue TQueue<T> with array as the underlying data structure
// ---------------------------------------------------------------------
namespace QueueProgram;
internal class Program {
   private static void Main (string[] args) {
      TQueue<int> queue = new();
      queue.Enqueue (1);
      queue.Enqueue (2);
      queue.Enqueue (3);
      queue.Enqueue (4);
      queue.Dequeue ();
      queue.Dequeue ();
      queue.Display ();
      queue.Enqueue (8);
      queue.Enqueue (9);
      queue.Enqueue (10);
      queue.Enqueue (11);
      queue.Enqueue (12);
      queue.Enqueue (13);
      queue.Enqueue (14);
      queue.Enqueue (15);
      queue.Display ();
      queue.Dequeue ();
      queue.Dequeue ();
      queue.Display ();
      Console.WriteLine ("Peek:" + queue.Peek ());
   }
}
public class TQueue<T> {
   /// <summary>Constructor of TQueue</summary>
   public TQueue () {
      mFront = -1;
      mRear = -1;
      mCount = 0;
      mArray = new T[4];
   }

   /// <summary>Capacity of the queue</summary>
   public int Capacity => mArray.Length;

   /// <summary>Count of the elements in the array</summary>
   public int Count => mCount;

   /// <summary>Adds elements to the queue</summary>
   /// <param name="a">The value of the element to be added</param>
   public void Enqueue (T a) {
      if (IsFull) ArrayResize ();
      if (mFront == -1) mFront = 0;
      mRear = (mRear + 1) % Capacity;
      mArray[mRear] = a;
      mCount++;
   }

   /// <summary>Deletes an element from the queue</summary>
   /// <returns>Returns the element to be deleted</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Dequeue () {
      if (IsEmpty) throw new InvalidOperationException();
      T item = mArray[mFront];
      if (mFront == mRear) {
         mFront = -1;
         mRear = -1;
      }
      else mFront = (mFront + 1) % Capacity;
      mCount--;
      return item;
   }

   /// <summary>Returns the first element added to the queue</summary>
   /// <returns>Returns the first element of the queue</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Peek () {
      if (IsEmpty) throw new InvalidOperationException();
      return mArray[mFront];
   }

   /// <summary>To check whether the queue is empty</summary>
   public bool IsEmpty => mFront == -1;

   /// <summary>To check whether the queue is full</summary>
   public bool IsFull => (mFront == 0 && mRear == (Capacity - 1)) || mFront == mRear + 1;

   /// <summary>Displays the elements of the queue</summary>
   public void Display () {
      if (IsEmpty) Console.WriteLine("Empty queue");
      int i = mFront;
      for (; i != mRear; i = (i + 1) % Capacity) Console.Write(mArray[i] + " ");
      Console.WriteLine(mArray[i]);
      Console.WriteLine();
   }

   /// <summary>Rearranges the elements in the array while resizing the array</summary>
   public void ArrayResize () {
      T[] newArray = new T[Capacity*2];
      int i = 0;
      do {
         newArray[i] = mArray[mFront];
         mFront = (mFront + 1) % Capacity;
         i++;
      } while (mFront != (mRear + 1) % Capacity);
      mArray = newArray;
      mFront = 0;
      mRear = Capacity - 1;
   }

   int mFront, mRear, mCount;
   T[] mArray;
}

