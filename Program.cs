//Test cases
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
list.Remove (4);
for (int i = 0; i < list.Count; i++) Console.Write (list[i] + " ");
Console.WriteLine ();
list.RemoveAt (4);
for (int i = 0; i < list.Count; i++) Console.Write (list[i] + " ");
Console.WriteLine ();
list[3] = 0;
for (int i = 0; i < list.Count; i++) Console.Write (list[i] + " ");
Console.WriteLine ();
list.Clear ();
for (int i = 0; i < list.Count; i++) Console.Write (list[i] + " ");
Console.WriteLine ();


/// <summary>
/// The class MyList is created for the implementation of list with array as the underlying data structure
/// </summary>
/// <typeparam name="T">The datatype of the elements to be stored in the list</typeparam>
class MyList<T> {
   int count;
   T[] array;

   /// <summary>
   /// Constructor of MyList
   /// </summary>
   public MyList () {
      count = 0;
      array = new T[4];
   }
   /// <summary>
   /// The property with the count of elements in the list
   /// </summary>
   public int Count => count;

   /// <summary>
   /// The property with the capacity of the list
   /// </summary>
   public int Capacity => array.Length;

   /// <summary>
   /// This property is to get and set values at the specified index in the list 
   /// </summary>
   /// <returns>Returns the value at that index</returns>
   /// <exception cref="IndexOutOfRangeException"></exception>
   public T this[int index] {
      get {
         if (index < 0 || index >= Count) throw new IndexOutOfRangeException ();
         return array[index];
      }
      set {
         if (index < 0 || index >= Count) throw new IndexOutOfRangeException ();
         array[index] = value;
      }
   }

   /// <summary>
   /// This method is to add elements to the list
   /// </summary>
   /// <param name="a"></param>
   public void Add (T a) {
      if (Count == Capacity) Array.Resize (ref array, Capacity * 2);
      array[Count] = a;
      count++;
   }

   /// <summary>
   /// This method is to remove an element from the list
   /// </summary>
   /// <param name="a">The element to be removed </param>
   /// <returns>Returns true if the element is removed</returns>
   /// <exception cref="InvalidOperationException"></exception>
   public bool Remove (T a) {
      if (!array.Contains (a)) throw new InvalidOperationException ();
      int index = Array.IndexOf (array, a);
      for (int i = index; i < count; i++)
         array[i] = array[i + 1];
      count--;
      return true;
   }

   /// <summary>
   /// This method is to delete(clear) all the elements from the list
   /// </summary>
   /// <exception cref="IndexOutOfRangeException"></exception>
   public void Clear () {
      if (array.Length < 0) throw new IndexOutOfRangeException ();
      Array.Clear (array, 0, Count);
      count = 0;
   }

   /// <summary>
   /// This method is to insert an element in the list
   /// </summary>
   /// <param name="index">The index at which the element needs to be inserted</param>
   /// <param name="a">The value of the element</param>
   /// <exception cref="InvalidOperationException"></exception>
   public void Insert (int index, T a) {
      if (index < 0 || index >= count) throw new InvalidOperationException ();
      if (count == Capacity) Array.Resize (ref array, Capacity * 2);
      for (int i = count; i >= index; i--)
         array[i + 1] = array[i];
      array[index] = a;
      count++;
   }

   /// <summary>
   /// This method is to remove an element at the given index from the list
   /// </summary>
   /// <param name="index">The index of the element to be removed</param>
   /// <exception cref="InvalidOperationException"></exception>
   public void RemoveAt (int index) {
      if (index < 0 || index >= count) throw new InvalidOperationException ();
      for (int i = index; i < count; i++)
         array[i] = array[i + 1];
      count--;
   }
}
