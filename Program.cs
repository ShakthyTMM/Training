﻿//Program to Get a Strong Password
using static System.Console;
Write ("Enter Password: ");
string password = ReadLine () ?? "";
char[] password = pass.ToCharArray ();
CheckPassword (pass, password);
void CheckPassword (string pass, char[] password) {
   bool IsDigit, IsLower, IsUpper, IsSpecial;
   if (pass.Length >= 6) {
      IsDigit = password.Any (Char.IsDigit);
      IsLower = password.Any (Char.IsLower);
      IsUpper = password.Any (Char.IsUpper);
      string specials = "!@#$%^&*()-+";
      IsSpecial = CheckSpecial (specials, password);
      if (IsDigit && IsLower && IsUpper && IsSpecial == true) WriteLine ("The Password is Strong");
      else IncorrectPassword (IsDigit, IsLower, IsUpper, IsSpecial);
   } else WriteLine ("Invalid Password. Password is less than 6 characters");
}
bool CheckSpecial (string specials, char[] password) {
   foreach (char c in specials)
      if (password.Contains (c)) return true;
   return false;
}
void IncorrectPassword (bool IsDigit, bool IsLower, bool IsUpper, bool IsSpecial) {
   if (IsDigit == false) WriteLine ("Invalid password. No digit in the password");
   if (IsLower == false) WriteLine ("Invalid password. No Lowercase letter in the password");
   if (IsUpper == false) WriteLine ("Invalid password. No Uppercase letter in the password");
   if (IsSpecial == false) WriteLine ("Invalid password. No Special Character in the password");
}
