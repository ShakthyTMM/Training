// Test cases
MyList<int> list = new ();
list.Add (1);
list.Add (2);
list.Add (3);
list.Add (4);
list.Add (5);
list.Add (6);
for (int i = 0; i < list.Count; i++) Console.Write (list[i] + " ");
Console.WriteLine ();
list.Insert (4, 7);
for (int i = 0; i < list.Count; i++) Console.Write (list[i] + " ");
Console.WriteLine ();
Console.WriteLine (list.Remove (22) ? "The element is removed" : "The element does not exist");
for (int i = 0; i < list.Count; i++) Console.Write (list[i] + " ");
Console.WriteLine ();
list.RemoveAt (4);
for (int i = 0; i < list.Count; i++) Console.Write (list[i] + " ");
Console.WriteLine ();
list[3] = 7;
for (int i = 0; i < list.Count; i++) Console.Write (list[i] + " ");
Console.WriteLine ();
list.Clear ();
for (int i = 0; i < list.Count; i++) Console.Write (list[i] + " ");
Console.WriteLine ();

/// <summary>The class MyList is created for the implementation of list with array as the underlying data structure</summary>
/// <typeparam name="T">The datatype of the elements to be stored in the list</typeparam>
class MyList<T> {

   /// <summary>Constructor of MyList</summary>
   public MyList () {
      mArray = new T[4];
      mCount = 0;
   }

   /// <summary>Property with the count of elements in the list</summary>
   public int Count => mCount;

   /// <summary>Property with the capacity of the list</summary>
   public int Capacity => mArray.Length;

   /// <summary>This property is to get and set values at the specified index in the list</summary>
   /// <returns>Returns the value at that index</returns>
   /// <exception cref="IndexOutOfRangeException"></exception>
   public T this[int index] {
      get {
         if (index < 0 || index >= Count) throw new IndexOutOfRangeException ();
         return mArray[index];
      }
      set {
         if (index < 0 || index >= Count) throw new IndexOutOfRangeException ();
         mArray[index] = value;
      }
   }

   /// <summary>This method is to add elements to the list</summary>
   /// <param name="a">The value of the element</param>
   public void Add (T a) {
      if (Count == Capacity) Array.Resize (ref mArray, Capacity * 2);
      mArray[Count] = a;
      mCount++;
   }

   /// <summary>This method is to remove an element from the lis </summary>
   /// <param name="a">The element to be removed</param>
   /// <returns>Returns true if the element is removed else returns false if the element is not found in the list</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public bool Remove (T a) {
      int index = Array.IndexOf (mArray, a);
      if (index == -1) return false;
      for (int i = index; i < mCount; i++)
         mArray[i] = mArray[i + 1];
      mCount--;
      return true;
   }

   /// <summary>This method is to delete (clear) all the elements from the list</summary>
   /// <exception cref="IndexOutOfRangeException"></exception>
   public void Clear () {
      if (mArray.Length < 0) throw new IndexOutOfRangeException ();
      Array.Clear (mArray, 0, Count);
      mCount = 0;
   }

   /// <summary>This method is to insert an element in the list</summary>
   /// <param name="index">The index at which the element needs to be inserted</param>
   /// <param name="a">The value of the element</param>
   /// <exception cref="InvalidOperationException"></exception>
   public void Insert (int index, T a) {
      if (index < 0 || index >= mCount) throw new InvalidOperationException ();
      if (mCount == Capacity) Array.Resize (ref mArray, Capacity * 2);
      for (int i = mCount; i >= index; i--)
         mArray[i + 1] = mArray[i];
      mArray[index] = a;
      mCount++;
   }

   /// <summary>This method is to remove an element at the given index from the list</summary>
   /// <param name="index">The index of the element to be removed</param>
   /// <exception cref="InvalidOperationException"></exception>
   public void RemoveAt (int index) {
      if (index < 0 || index >= mCount) throw new InvalidOperationException ();
      for (int i = index; i < mCount; i++)
         mArray[i] = mArray[i + 1];
      mCount--;
   }
   int mCount;
   T[] mArray;
}