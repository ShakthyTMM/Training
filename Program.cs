// Test Cases
TQueue<int> queue = new ();
queue.Enqueue (1);
queue.Enqueue (2);
queue.Enqueue (3);
queue.Enqueue (4);
queue.Enqueue (5);
queue.Display ();
Console.WriteLine (queue.Dequeue ());
queue.Display ();
Console.WriteLine (queue.Peek ());
queue.Display ();
Console.WriteLine (queue.Dequeue ());
queue.Display ();

/// <summary>Class TQueue is to implement queue with array as the underlying data structure</summary>
/// <typeparam name="T">Datatype of the queue</typeparam>
class TQueue<T> {
   /// <summary> Constructor of TQueue </summary>
   public TQueue () {
      mFront = 0;
      mRear = -1;
      mArray = new T[4];
   }

   /// <summary>Property with capacity of the queue</summary>
   public int Capacity => mArray.Length;

   /// <summary>The method to add elements to the queue</summary>
   /// <param name="a">The value of the element to be added</param>
   public void Enqueue (T a) {
      if (mRear == (Capacity - 1)) Array.Resize (ref mArray, Capacity * 2);
      mArray[++mRear] = a;
   }

   /// <summary>The method to delete a element from the queue</summary>
   /// <returns>Returns the element to be deleted</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public T Dequeue () {
      if (IsEmpty) throw new InvalidOperationException ();
      T item = mArray[mFront];
      mFront++;
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
   public bool IsEmpty => mFront > mRear;

   /// <summary>The method to display the elements of the queue</summary>
   public void Display () {
      for (int i = mFront; i <= mRear; i++) Console.Write (mArray[i] + " ");
      Console.WriteLine ();
   }

   int mFront, mRear;
   T[] mArray;
}
