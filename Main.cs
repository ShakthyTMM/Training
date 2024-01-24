ComplexNumber num1 = new ComplexNumber (2, 7);
ComplexNumber num2 = new ComplexNumber (3, 5);

num1.Addition (num2);
num1.Subtraction (num2);
Console.WriteLine ($"Magnitude: {num1.norm}");