// Program to check for Strong Password
using static System.Console;
Write ("Enter Password: ");
string password = ReadLine () ?? "";
string specials = "!@#$%^&*()-+";
string checkPassword = "";
if (password.Length >= 6) {
   checkPassword += (password.Any (Char.IsDigit) ? "" : "The Password must contain atleast one digit.\n");
   checkPassword += (password.Any (Char.IsLower) ? "" : "The Password must contain atleast one Lowercase alphabet.\n");
   checkPassword += (password.Any (Char.IsUpper) ? "" : "The Password must contain atleast one Uppercase alphabet.\n");
   checkPassword += (password.Any (specials.Contains) ? "" : "The Password must contain atleast one of these !@#$%^&*()-+ special characters.\n");
   WriteLine ((checkPassword == "" ? "The Password is Strong" : "Invalid password\n" + checkPassword));
} else WriteLine ("Invalid password. The Password must contain atleast 6 characters.");