namespace Eval;
#region Evaluator class ---------------------------------------------------------------------------------------- 
/// <summary>Evaluator class</summary>
class Evaluator {
   /// <summary>Derived exception from base class exception</summary>
   class EvalException : Exception {
      public EvalException (string message) : base (message) { }
   }
   #region Implementation ----------------------------------------
   /// <summary>Evaluates the tokens returned from the tokenizer</summary>
   /// <param name="s">Expression to be evaluated</param>
   /// <returns>Returns a double which is the result of the given expression</returns>
   public double Evaluate (string s) {
      Reset ();
      var tokenizer = new Tokenizer (this, s);
      List<Token> tokens = new ();
      for (; ; ) {
         var token = tokenizer.GetToken ();
         if (token is TEnd) break;
         tokens.Add (token);
      }
      TVariable var = null;
      if (tokens.Count > 1 && tokens[0] is TVariable tv && tokens[1] is TOpbinary bin && bin.Op == '=') {
         var = tv;
         tokens.RemoveRange (0, 2);
      }
      foreach (var token in tokens)
         Process (token);
      while (mOperators.Count > 0)
         ApplyOperator ();
      if (mBasePriority != 0) Error ("Mismatched Parentheses");
      if (mOperators.Count > 0) Error ("Too many operators");
      if (mOperands.Count > 1) Error ("Too many operands");
      double f = mOperands.Pop ();
      if (var != null)
         mVariables[var.Variable] = f;
      return f;
   }
   /// <summary>Evaluates the operand and operator stack with appropriate functinality</summary>
   void ApplyOperator () {
      var op = mOperators.Pop ();
      if (op is TOpbinary bin) {
         if (mOperands.Count < 2) Error ("Too few operands");
         double f1 = mOperands.Pop (), f2 = mOperands.Pop ();
         mOperands.Push (bin.Apply (f2, f1));
      }
      if (op is TOpfunction func) {
         if (mOperands.Count < 1) Error ("Too few operands");
         double f = mOperands.Pop ();
         mOperands.Push (func.Apply (f));
      }
      if (op is TOpUnary unary) {
         if (mOperands.Count < 0) Error ("Too few operands");
         double f = mOperands.Pop ();
         mOperands.Push (unary.Apply (f));
      }
   }

   /// <summary>Throws EvalException with the error message</summary>
   /// <param name="s">Error Message</param>
   /// <exception cref="EvalException"></exception>
   void Error (string s) => throw new EvalException (s);

   /// <summary>Pushes the tokens into the appropriate stacks</summary>
   /// <param name="token">Tokens to be pushed into the stacks</param>
   /// <exception cref="NotImplementedException"></exception>
   void Process (Token token) {
      switch (token) {
         case TNumber num:
            mOperands.Push (num.Value);
            break;
         case TOperator op:
            op.FinalPriority = op.Priority + mBasePriority;
            while (!OktoPush (op)) ApplyOperator ();
            mOperators.Push (op);
            break;
         case TPunctuation punc:
            if (punc.Punctuation == '(') mBasePriority += 10;
            else mBasePriority -= 10;
            break;
         default: throw new NotImplementedException ();
      }
   }
   int mBasePriority = 0;

   /// <summary>Resets the stacks and operator priority variable</summary>
   void Reset () {
      mOperands.Clear ();
      mOperators.Clear ();
      mBasePriority = 0;
   }

   /// <summary>Checks the priority of the operators</summary>
   /// <param name="op">Operator token</param>
   /// <returns>Returns true if the operator is appropriate to push else false</returns>
   bool OktoPush (TOperator op) {
      if (mOperators.Count == 0) return true;
      TOperator prev = mOperators.Peek ();
      return prev.FinalPriority <= op.FinalPriority;
   }

   /// <summary>Gets the name of the variable given in the expression</summary>
   /// <param name="name">Name of the variable</param>
   /// <returns>Returns the name of the variable</returns>
   public double GetVariable (string name) {
      if (mVariables.TryGetValue (name, out var v)) return v;
      Error ($"Unknown Variable {name}");
      return 0;
   }
   #endregion

   #region Private data ------------------------------------------
   Stack<double> mOperands = new ();
   Stack<TOperator> mOperators = new ();
   Dictionary<string, double> mVariables = new ();
   #endregion
}
#endregion