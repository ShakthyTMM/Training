namespace Eval;
#region Program ---------------------------------------------------------------------------------------- 
/// <summary>Class token gets the string or expression from tokenizer and returns them as tokens</summary>
class Token { }
#region TNumber class ---------------------------------------------------------------------------------------- 
/// <summary>Derived class from the base class Token to return the numbers</summary>
class TNumber : Token {
   public virtual double Value { get; }
}

/// <summary>Derived class from base class TNumber returns the variable name</summary>
class TVariable : TNumber {
   public TVariable (Evaluator eval, string var) { mVar = var; mEval = eval; }
   public override string ToString () => $"variable:{mVar}";
   public override double Value => mEval.GetVariable (Variable);
   public string Variable => mVar;
   readonly string mVar;
   readonly Evaluator mEval;
}

/// <summary>Derived class from the base class TNumber which returns the numerals</summary>
class TLiteral : TNumber {
   public TLiteral (double f) => mDouble = f;
   public override string ToString () => $"number:{mDouble}";
   public override double Value => mDouble;
   readonly double mDouble;
}
#endregion
#region TOperator class ---------------------------------------------------------------------------------------- 
/// <summary>Derived class from the base class Token which returns the operators</summary>
class TOperator : Token {
   public virtual int Priority { get; }
   public virtual int FinalPriority { get; set; }
}

/// <summary>Derived class from the base class TOperator which returns the binary operators</summary>
class TOpbinary : TOperator {
   public TOpbinary (char op) => mOp = op;
   public override string ToString () => $"Binary:{mOp}";

   /// <summary>Returns the priority of the operator</summary>
   public override int Priority
       => Op switch {
          '+' or '-' => 1,
          '*' or '/' => 2,
          '^' => 3,
          _ => throw new NotImplementedException ()
       };

   /// <summary>Applies the operation based on the operator</summary>
   /// <param name="a">Second operand</param>
   /// <param name="b">First operand</param>
   /// <returns>Returns the result of the operation</returns>
   /// <exception cref="NotImplementedException"></exception>
   public double Apply (double a, double b)
       => Op switch {
          '+' => a + b,
          '-' => a - b,
          '*' => a * b,
          '/' => a / b,
          '^' => Math.Pow (a, b),
          _ => throw new NotImplementedException ()
       };

   public char Op => mOp;
   readonly char mOp;
}

/// <summary>Derived class from the base class TOperator which returns the functions</summary>
class TOpfunction : TOperator {
   public TOpfunction (string op) => mFunc = op;
   public override string ToString () => $"Function:{mFunc}";

   /// <summary>Returns the priority of the function</summary>
   public override int Priority => 4;

   /// <summary>Applies the operation based on the functiom</summary>
   /// <param name="a">Operand to be evaluated</param>
   /// <returns>Returns the result of the operation</returns>
   /// <exception cref="NotImplementedException"></exception>
   public double Apply (double a)
       => Function switch {
          "sin" => Math.Sin (D2R (a)),
          "cos" => Math.Cos (D2R (a)),
          "tan" => Math.Tan (D2R (a)),
          "sqrt" => Math.Sqrt (a),
          "asin" => R2D (Math.Asin (a)),
          "acos" => R2D (Math.Acos (a)),
          "atan" => R2D (Math.Atan (a)),
          "log" => Math.Log (a),
          "exp" => Math.Exp (a),
          _ => throw new NotImplementedException ()
       };

   /// <summary>Converts the given degree into radian</summary>
   /// <param name="a">Operand to be evaluated</param>
   /// <returns>Returns the result of the operation</returns>
   double D2R (double a) => a * Math.PI / 180;

   /// <summary>Converts the given radian into degree</summary>
   /// <param name="a">Operand to be evaluated</param>
   /// <returns>Returns the result of the operation</returns>
   double R2D (double a) => a * 180 / Math.PI;

   public string Function => mFunc;
   readonly string mFunc;
}

/// <summary>Derived class from the base class TOperator which returns the unary operators</summary>
class TOpUnary : TOperator {
   public TOpUnary (char op) => mOp = op;

   /// <summary>Returns the priority of the operator</summary>
   public override int Priority => 5;

   /// <summary>Applies the operation based on the operator</summary>
   /// <param name="a">Operand to be evaluated</param>
   /// <returns>Returns the result of the operation</returns>
   /// <exception cref="NotImplementedException"></exception>
   public double Apply (double a)
       => mOp switch {
          '+' => +a,
          '-' => -a,
          _ => throw new NotImplementedException ()
       };

   public char Op => mOp;
   readonly char mOp;
}
#endregion

/// <summary>Derived class from the base class Token returns the punctuations</summary>
class TPunctuation : Token {
   public TPunctuation (char Punc) => mPunc = Punc;
   public override string ToString () => $"punctuation:{mPunc}";
   public char Punctuation => mPunc;
   readonly char mPunc;
}

/// <summary>Derived class from the base class Token which returns the errors</summary>
class TError : Token {
   public TError (string msg) => mMessage = msg;
   public override string ToString () => $"{Message}";
   public string Message => mMessage;
   readonly string mMessage;
}

/// <summary>Derived class from the base class Token to end the operation</summary>
class TEnd : Token { }
#endregion