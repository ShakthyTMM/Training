namespace Eval;
#region Program ---------------------------------------------------------------------------------------- 
/// <summary>Sortes the expression into tokens</summary>
class Tokenizer {
   public Tokenizer (Evaluator eval, string input) {
      mText = input;
      mN = 0;
      mEval = eval;
   }

   #region Implementation ----------------------------------------
   /// <summary>Separates the individual tokens from the given expression</summary>
   /// <returns></returns>
   public Token GetToken () {
      while (mN < mText.Length) {
         char ch = mText[mN++];
         if (ch == ' ') continue;
         if (ch is >= '0' and <= '9') return GetLiteral ();
         if (ch is '+' or '-' or '*' or '/' or '^' or '=') return GetOperator ();
         if (ch is '(' or ')') return new TPunctuation (ch);
         if (ch is >= 'a' and <= 'z') return GetVariable ();
         return new TError ($"Unexpected character{ch}");
      }
      return new TEnd ();
   }

   /// <summary>Gets the literal token from the expression</summary>
   /// <returns>Returns the literal token</returns>
   Token GetLiteral () {
      int start = mN - 1;
      while (mN < mText.Length) {
         char ch = mText[mN++];
         if (ch is (>= '0' and <= '9') or '.') continue;
         mN--; break;
      }
      string number = mText.Substring (start, mN - start);
      double f = double.Parse (number);
      return new TLiteral (f);
   }

   /// <summary>Gets the variable token from the expression</summary>
   /// <returns>Returns the variable token</returns>
   Token GetVariable () {
      int start = mN - 1;
      while (mN < mText.Length) {
         char ch = mText[mN++];
         if (ch is (>= 'a' and <= 'z') or (>= '0' and <= '9')) continue;
         mN--; break;
      }
      string variable = mText.Substring (start, mN - start);
      if (mFunctions.Contains (variable)) return new TOpfunction (variable);
      else return new TVariable (mEval, variable);
   }

   /// <summary>Gets the operator token from the expression</summary>
   /// <returns>Returns the operator token</returns>
   Token GetOperator () {
      int start = mN - 1;
      char ch = mText[start];
      if (ch is '+' or '-') {
         if (start is 0 || (mText[--start] is '+' or '-' or '*' or '/' or '^' or '=' or '(' or ' ')) return new TOpUnary (ch);
         if (mText[mN] is '+' or '-') {
            char a = ch == mText[mN] ? '+' : '-';
            mN++;
            return new TOpbinary (a);
         }
      }
      return new TOpbinary (ch);
   }
   #endregion

   #region Private data ------------------------------------------
   readonly string mText;
   int mN;
   readonly Evaluator mEval;
   readonly string[] mFunctions = { "sin", "cos", "tan", "sqrt", "asin", "acos", "atan", "log", "exp" };
   #endregion
}
#endregion