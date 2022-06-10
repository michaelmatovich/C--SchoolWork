using System.Collections.Generic;

Random rdm = new Random();


//Random Array

static int[] RandomArray()
{
    Random rdm = new Random();
    int[] numArray = new int[10];
    int low = 26;
    int high = 0;
    int sum = 0;

    for (int i = 0; i < 10; i++)
    {
        numArray[i] = rdm.Next(5, 26);

        sum += numArray[i];

        if (numArray[i] < low)
        {
            low = numArray[i];
        }
        if (numArray[i] > high)
        {
            high = numArray[i];
        }
    }

    Console.WriteLine($"Sum: {sum}");
    Console.WriteLine($"Low: {low}");
    Console.WriteLine($"High: {high}");

    return numArray;
}

int[] nums = new int[10];

nums = RandomArray();

foreach (var num in nums)
{
    Console.Write($"{num}, ");
}

//Coin Flip

static string TossCoin()
{
    Console.WriteLine("\nTossing a Coin!");

    Random rdm = new Random();

    return rdm.Next(1, 3) == 1 ? "Heads" : "Tails";
}

Console.WriteLine(TossCoin());

//Names

static List<string> Names()
{
    List<string> nameList = new List<string>();

    nameList.Add("Todd");
    nameList.Add("Tiffany");
    nameList.Add("Charlie");
    nameList.Add("Geneva");
    nameList.Add("Sydney");

    for (int i = 4; i > -1; i--)
    {
        if (nameList[i].Length < 6)
        {
            nameList.Remove(nameList[i]);
        }
    }
    return nameList;
}

var test = Names();

foreach (var t in test)
{
    Console.WriteLine(t);
}





