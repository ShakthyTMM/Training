class ComplexNumber {
   public ComplexNumber (int real, int imag) {
      r = real;
      i = imag;
   }
   public int Real => r;
   public int Imag => i;

   public double norm => Math.Sqrt (Math.Pow (r, 2) + Math.Pow (i, 2));

   public void Addition (ComplexNumber num) {
      Console.WriteLine ($"Addition:  { r + num.r}");
   }
   public void Subtraction (ComplexNumber num) {
      Console.WriteLine ($"Subtraction: { i - num.i}");
   }
   readonly int r;
   readonly int i;
}