string userInput;
// var toDoList = new List<string>();
var toDoList = new List<string>
    {
        "Collect the package from postoffice.",
        "Buy milk.",
        "Go to Kim's bday on wed19h.",
    };
var runApp = true;

do
{
    Thread.Sleep(1000);
    Console.WriteLine(
    $"\nTODO list options:\n[A]dd a TODO\n[R]emove a TODO\n[S]ee all TODOs\n[E]xit");
    userInput = Console.ReadLine().ToUpper();
    switch (userInput)
    {
        case "A":
            PrintOption("Add a TODO:");
            toDoList = AddToDos(toDoList);
            break;
        case "R":
            PrintOption("Remove a TODO:");
            RemoveToDosMsg(toDoList);
            break;
        case "S":
            PrintOption("See all todos");
            SeeToDos(toDoList);
            break;
        case "E":
            PrintOption("Exit program");
            if(ConfirmExit())
            {
                runApp = false;
            }
            break;
        default:
            Console.WriteLine("Not a valid option. Try again.");
            break;
    }
} while (runApp);


// Methods:
void PrintOption(string userChoice)
{
    Console.WriteLine(
        $"\nYou selected option: {userChoice}");
}


List<string> AddToDos(List<string> toDoList)
{
    var newList = toDoList;
    Console.WriteLine("Type a new TODO:");
    var newToDo = Console.ReadLine();

    if(string.IsNullOrEmpty(newToDo))
    {
        Console.WriteLine("\nNothing is added to the list.");
        return toDoList;
    }
    else
    {
        Console.WriteLine($"\nYou typed <{newToDo}>\nPress [Y] to commit this TODO.");
        var commitAnswer = Console.ReadLine().ToLower();

        if(commitAnswer == "y" || commitAnswer == "yes")
        {
            Console.WriteLine($"\n<{newToDo}> has successfully been added to the list.");
            newList.Add(newToDo);
            return newList;
        }
        else
        {
            Console.WriteLine("\nNothing is added to the list.");
            return toDoList;
        }
    }
}


// List<string>
void RemoveToDosMsg(List<string> toDoList)
{
    Console.WriteLine($"Type the number of the index number in the console to remove it.\nThe TODO list contains the following items:\n");
    SeeToDos(toDoList);
    var userInput = Console.ReadLine();
    int removeToDo = int.Parse(userInput); // Evaluate if parseable

    if(removeToDo < toDoList.Count)
    {
        Console.WriteLine($"Do you want to remove TODO number {userInput}? [Y] to confirm");

        var removeCommit = Console.ReadLine();
        if(removeCommit == "y" || removeCommit == "yes")
        {
            var newList = RemoveToDo(toDoList, removeToDo);
        }
    }
}

List<string> RemoveToDo(List<string> toDoList, int choice)
{
    var newList = toDoList;
    int itemIndex = 0;
    foreach(string item in newList)
    {
        if(itemIndex == choice)
        {
            Console.WriteLine($"\n--- Deleting {item} ---.");
            // newList.remove(item);
            // return newList;
        }
        itemIndex++;
    }
    return toDoList;
}


void SeeToDos(List<string> toDoList)
{
    var itemNumber = 0;
    foreach(var item in toDoList)
    {
        Console.WriteLine($"{itemNumber}. {item}");
        itemNumber++;
    }
    if(itemNumber==0)
    {
        Console.WriteLine("TODO list is empty.");
    }
}


bool ConfirmExit()
{
    string exitAnswer;
    Console.WriteLine("Are you sure you want to exit the program? Press [Y] to confirm.");

    exitAnswer = Console.ReadLine().ToLower();
    if(exitAnswer == "y" || exitAnswer == "yes")
    {
        return true;
    }
    else
    {
        return false;
    }
}
