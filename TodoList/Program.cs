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
    PrintToDoOptions();
    userInput = Console.ReadLine().ToUpper();
    switch(userInput)
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
void PrintToDoOptions()
{
    Console.WriteLine(
        $"\nTODO list options:\n[A]dd a TODO\n[R]emove a TODO\n[S]ee all TODOs\n[E]xit"
    );
}


void PrintOption(string userChoice)
{
    Console.WriteLine(
        $"\nYou selected option: {userChoice}");
}


List<string> AddToDos(List<string> toDoList)
{
    var newList = toDoList;

    bool newToDoIsValid = false;
    while(!newToDoIsValid)
    {
        Console.WriteLine("Type a new TODO:");
        var newToDo = Console.ReadLine();

        if(string.IsNullOrEmpty(newToDo))
        {
            Console.WriteLine("\nThe TODO string cannot be empty.");
        }
        else if(toDoList.Contains(newToDo))
        {
            Console.WriteLine("\nThe TODO string already exists.");
        }
        else
        {
            Console.WriteLine($"\nYou typed <{newToDo}>\nPress [ENTER] or [Y] to commit this TODO.");
            var commitAnswer = Console.ReadLine().ToLower();
            newToDoIsValid = true;
            if(commitAnswer == "y" || commitAnswer == "yes" || commitAnswer == "")
            {
                Console.WriteLine($"\n<{newToDo}> has successfully been added to the list.");
                newList.Add(newToDo);
            }
            else
            {
                Console.WriteLine("\nNothing is added to the list.");
            }
        }
    }
    return newList;
}


void RemoveToDosMsg(List<string> toDoList)
{
    if(toDoList.Count == 0)
    {
        SeeToDos(toDoList);
    }
    else
    {
        Console.WriteLine($"Type the number of the index number in the console to remove it.\nThe TODO list contains the following items:\n");
        SeeToDos(toDoList);
        var userInput = Console.ReadLine();
        if
        (
            int.TryParse(userInput, out int index)
            && index >= 1
            && index<= toDoList.Count
        )
        {
            int removeToDo = index-1; // Evaluate if parseable

            Console.WriteLine($"Do you want to remove TODO number {userInput}? Press [ENTER] or [Y] to confirm");

            var removeCommit = Console.ReadLine();
            if(removeCommit == "y" || removeCommit == "yes" || removeCommit == "")
            {
                var newList = RemoveToDo(toDoList, removeToDo);
            }
        }

        else
        {
            Console.WriteLine($"{userInput} is not a number on the TODO List");
        }
    }
}


List<string> RemoveToDo(List<string> toDoList, int choice)
{
    Console.WriteLine($"\n--- Deleting item: {toDoList[choice]} ---");
    toDoList.RemoveAt(choice);
    return toDoList;
}


void SeeToDos(List<string> toDoList)
{
    if(toDoList.Count ==0)
    {
        Console.WriteLine("TODO list is empty.");
    }
    else
    {
        for (int i = 0; i < toDoList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {toDoList[i]}");
        }
    }

}


bool ConfirmExit()
{
    string exitAnswer;
    Console.WriteLine("Are you sure you want to exit the program? Press [ENTER] or [Y] to confirm.");

    exitAnswer = Console.ReadLine().ToLower();
    if(exitAnswer == "y" || exitAnswer == "yes" || exitAnswer == "")
    {
        return true;
    }
    else
    {
        return false;
    }
}
