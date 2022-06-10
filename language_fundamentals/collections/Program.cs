using System.Collections.Generic;
using System.Linq;

Random rdm = new Random();

//Collections Practice

/*Create an array to hold integer values 0 through 9
Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
Create an array of length 10 that alternates between true and false values, starting with true
*/

int[] nums = {0,1,2,3,4,5,6,7,8,9};
string[] names = {"Tim", "Martin", "Nikki", "Sara"};
bool[] switches = {true, false, true, false, true, false, true, false, true, false};

/*Create a list of ice cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
Output the length of this list after building it
Output the third flavor in the list, then remove this value
Output the new length of the list (It should just be one fewer!)*/


List<string> iceCreamFlavor = new List<string>();

iceCreamFlavor.Add("Vanilla");
iceCreamFlavor.Add("Chocolate");
iceCreamFlavor.Add("Cookies And Cream");
iceCreamFlavor.Add("Butter Pecan");
iceCreamFlavor.Add("Rocky Road");

Console.WriteLine(iceCreamFlavor.Count);

Console.WriteLine(iceCreamFlavor[2]);

iceCreamFlavor.Remove("Cookies And Cream");
Console.WriteLine(iceCreamFlavor.Count);

// Create a dictionary that will store both string keys as well as string values
// Add key/value pairs to this dictionary where:
// each key is a name from your names array
// each value is a randomly elected flavor from your flavors list.
// Loop through the dictionary and print out each user's name and their associated ice cream flavor

Dictionary<string,string> dict = new Dictionary<string,string>();

foreach(var name in names){
    dict.Add(name, iceCreamFlavor[rdm.Next(0,4)]);
}
foreach(var entry in dict){
    Console.WriteLine($"{entry.Key}: {entry.Value}");
}



