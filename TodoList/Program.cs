Console.WriteLine("TODO list:");
Console.WriteLine("[A]dd a TODO");
Console.WriteLine("[R]emove a TODO");
Console.WriteLine("[E]xit");
Console.WriteLine("[S]ee all TODOs");

string userInput;

do
{
    userInput = Console.ReadLine().ToUpper();
    switch (userInput)
    {
        case "S":
            PrintOption("See all todos");
            break;
        case "A":
            PrintOption("Add a TODO:");
            break;
        case "R":
            PrintOption("Remove a TODO:");
            break;
        case "E":
            PrintOption("Exiting program...");
            break;
        default:
            Console.WriteLine("Not a valid option. Try again.");
            break;
    }
} while (userInput!="E");


// Methods:
void PrintOption(string userChoice)
{
    Console.WriteLine(
        $"Selected option: {userChoice}");
}
