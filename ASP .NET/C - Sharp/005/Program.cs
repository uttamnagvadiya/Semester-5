// See https://aka.ms/new-console-template for more information

using _005;
using Banks;
using Hospitals;
using Trafiic;

// =============== Method Overloading ===============

Addition addition = new Addition();
Console.WriteLine("Addition of integer numbers are 10 + 20 : " + addition.addition(10, 20));
Console.WriteLine("Addition of float numbers are 5.5 + 5.5 : " + addition.addition(5.5f, 5.5f));



// =============== Operator Overloading ===============

/*OperatorOverloading o = new OperatorOverloading(10, 20, 30);
o++;
o.display();*/



// =============== Properties ===============

/*Properties p = new Properties();
//Console.WriteLine(p.n);               // Its not access because it is private.
Console.WriteLine(p.numberGetSet);      // before set n
p.numberGetSet = 25;
Console.WriteLine(p.numberGetSet);*/    // after set n



// =============== Indexers ===============

/*Indexers i = new Indexers();
i[0] = "Apple";
i[1] = "Banana";
i[2] = "Orange";
i.display();*/



// =============== Areas of Square, Rectangle & Circle ===============

/*Area area = new Area();
Console.WriteLine($"Area of square = {area.area(23.8f)}");
Console.WriteLine($"Area of rectangle = {area.area(23.8f, 45.1f)}");
Console.WriteLine($"Area of circle = {area.area(25)}");*/



// =============== Method Overrides ===============

/*RBI r = new RBI();
r.calculateInterest();
HDFC h = new HDFC();
h.calculateInterest();
SBI s = new SBI();
s.calculateInterest();
ICICI i = new ICICI();
i.calculateInterest();
-----------------------------------------
Hospital h = new Hospital();
h.hospitalDetails();
Apollo a = new Apollo();
a.hospitalDetails();
Wockhard w = new Wockhard();
w.hospitalDetails();
Gokul g = new Gokul();
g.hospitalDetails();*/



// =============== Delegate ===============

/*DelegateClass d = new DelegateClass();
FactorialDelegate del = d.calculateFactorial;

Console.WriteLine($"Factorial of 5 is {del(5)}.");

----------------------------------------------------------------------------

TrafficSignals signals = new TrafficSignals();
 
TrafficDelegate redDelegate = signals.redSignal;
TrafficDelegate yellowDelegate = signals.yellowSignal;
TrafficDelegate greenDelegate = signals.greenSignal;
Console.WriteLine(redDelegate());
Console.WriteLine(yellowDelegate());
Console.WriteLine(greenDelegate());*/



// =============== Calculator using delegate ===============

/*Calculator cal = new Calculator();

CalculatorDelegate<int> addDelegate = cal.Addition;
CalculatorDelegate<int> subDelegate = cal.Substraction;
CalculatorDelegate<double> multiDelegate = cal.Multiplication;
CalculatorDelegate<double> divDelegate = cal.Division;

int x = 5, y = 0;

Console.WriteLine($"Addition: {x} + {y} = {addDelegate(x, y)}");
Console.WriteLine($"Substraction: {x} - {y} = {subDelegate(x, y)}");
Console.WriteLine($"Multiplication: {x} * {y} = {multiDelegate(x, y)}");
try
{
    Console.WriteLine($"Division: {x} / {y} = {divDelegate(x, y)}");
}
catch (DivideByZeroException e)
{
    Console.WriteLine($"Division: {e.Message}");
}*/
