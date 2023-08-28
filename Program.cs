Console.WriteLine ("Enter a text: ");
string name = Console.ReadLine () ?? "";
name=name.ToLower ().Replace (" ", "");
string reverse = "";
for (int i = name.Length - 1; i >= 0; i--) 
   reverse += name[i];
string result = "It is a "+ (name==reverse ? "": "not a") + " palindrome";
Console.WriteLine (result);
