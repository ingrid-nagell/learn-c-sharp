Console.WriteLine("Input first number:");
var usersFirstInput = Console.ReadLine();
int number1 = int.Parse(usersFirstInput);

Console.WriteLine("Input second number:");
var usersSecondInput = Console.ReadLine();
int number2 = int.Parse(usersSecondInput);

Console.WriteLine("");

Console.WriteLine("What do you want to do? ");
Console.WriteLine("[A]dd numbers");
Console.WriteLine("[S]ubtract numbers");
Console.WriteLine("[M]ultiply numbers");

var usersChoice = Console.ReadLine();

if(usersChoice.ToLower() == "a")
{
    int sum = number1 + number2;
    Console.WriteLine(
        $"The sum of {number1} and {number2} is {sum}");
}
else if(usersChoice.ToLower() == "s")
{
    int difference = number1 - number2;
    Console.WriteLine(
        $"The difference of {number1} and {number2} is {difference}");
}
else if(usersChoice.ToLower() == "m")
{
    int product = number1 * number2;
    Console.WriteLine(
        $"The product of {number1} and {number2} is {product}");
}
else
{
    Console.WriteLine("Not a valid option.");
}

Console.WriteLine("Press any key to close.");
Console.ReadKey();
