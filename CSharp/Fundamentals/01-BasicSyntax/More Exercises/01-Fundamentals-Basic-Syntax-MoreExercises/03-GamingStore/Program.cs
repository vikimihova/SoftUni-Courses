decimal currentBalance = decimal.Parse(Console.ReadLine());
decimal totalCosts = 0M;

string gameTitle = Console.ReadLine();
while (gameTitle != "Game Time")
{
    decimal price = 0M;

    if (gameTitle == "OutFall 4")
    {
        price = 39.99M;        
    }
    else if (gameTitle == "CS: OG")
    {
        price = 15.99M;
    }
    else if (gameTitle == "Zplinter Zell")
    {
        price = 19.99M;
    }
    else if (gameTitle == "Honored 2")
    {
        price = 59.99M;
    }
    else if (gameTitle == "RoverWatch")
    {
        price = 29.99M;
    }
    else if (gameTitle == "RoverWatch Origins Edition")
    {
        price = 39.99M;
    }

    if (price == 0M) 
    {
        Console.WriteLine("Not Found");
    }
    else if (price > currentBalance)
    {
        Console.WriteLine("Too Expensive");
    }
    else if (price < currentBalance)
    {
        currentBalance -= price;
        totalCosts += price;
        Console.WriteLine($"Bought {gameTitle}");
    }
    else if (price == currentBalance)
    {
        Console.WriteLine($"Bought {gameTitle}");
        Console.WriteLine("Out of money!");
        return;
    }     

    gameTitle = Console.ReadLine();
}

Console.WriteLine($"Total spent: ${totalCosts}. Remaining: ${currentBalance}");

