//// Test Cases
TQueue<int> queue = new ();
//queue.Enqueue (1);
//queue.Enqueue (2);
//queue.Enqueue (3);
//// Enqueued 3 item, intial capacity is 4 so now
//// capacity should be 4
//if (queue.Capacity != 4) {
//   queue.Display ();
//   Console.WriteLine ($"Expected capacity 4 but found {queue.Capacity}");
//   // return;
//}
// Test case 2
queue = new ();
queue.Enqueue (1);
queue.Enqueue (2);
queue.Enqueue (3);
queue.Enqueue (4);
queue.Enqueue (5);
queue.Enqueue (6);
queue.Enqueue (7);
queue.Dequeue ();
queue.Dequeue ();
queue.Display();
queue.Enqueue (8);
queue.Display ();
queue.Enqueue (9);
queue.Display ();
queue.Enqueue (10);
queue.Display ();
int count = 0;
while (!queue.IsEmpty) {
   Console.Write (queue.Dequeue ()+" ");
   count++;
}
Console.WriteLine ();
if (count != 8) {
   Console.WriteLine ("Expected 10 9 8 7 6 5 4 3");
   return;
}


/// <summary>Class TQueue is to implement queue with array as the underlying data structure</summary>
/// <typeparam name="T">Datatype of the queue</typeparam>
class TQueue<T> {
   /// <summary>Constructor of TQueue</summary>
   public TQueue () {
      mFront = -1;
      mRear = -1;
      count = 0;
      mArray = new T[4];
   }

   /// <summary>Property with capacity of the queue</summary>
   public int Capacity => mArray.Length;

   /// <summary>The method to add elements to the queue</summary>
   /// <param name="a">The value of the element to be added</param>
   public void Enqueue (T a) {
      if (mFront == -1) mFront = 0;
      if (IsFull && mRear!=-1 && count==Capacity) Array.Resize (ref mArray, Capacity * 2);
      else if (mRear == (Capacity - 1))
         mRear = -1;
      mArray[++mRear] = a;
      count++;
      //Console.WriteLine (count);
   }

   /// <summary>The method to delete a element from the queue</summary>
   /// <returns>Returns the element to be deleted</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Dequeue () {
      if (IsEmpty) throw new InvalidOperationException ();
      T item = mArray[mFront];
      if (mFront == mRear) {
         mFront = -1;
         mRear = -1;
      } else if (mFront == (Capacity - 1))
         mFront = 0;
      else mFront++;
      count--;
      //Console.WriteLine (count);
      return item;
   }

   /// <summary>The method to return the first element added to the queue</summary>
   /// <returns>Returns the first element of the queue</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Peek () {
      if (IsEmpty) throw new InvalidOperationException ();
      return mArray[mFront];
   }

   /// <summary>IsEmpty Property to check whether the queue is empty</summary>
   public bool IsEmpty => (mFront == -1 && mRear == -1);

   /// <summary>IsFull Property to check whether the queue is full</summary>
   public bool IsFull => (mFront == 0 && mRear == (Capacity - 1)) || mFront == mRear + 1;

   /// <summary>The method to display the elements of the queue</summary>
   public void Display () {
      if (IsEmpty) Console.WriteLine ("Empty queue");
      if (mRear > mFront) {
         for (int i = mFront; i <=mRear; i++) Console.Write (mArray[i] + " ");
         Console.WriteLine ();
      } else {
         for (int i = 0; i < Capacity; i++) Console.Write (mArray[i] + " ");
         Console.WriteLine ();
      }
   }

   int mFront, mRear,count;
   T[] mArray;
}
