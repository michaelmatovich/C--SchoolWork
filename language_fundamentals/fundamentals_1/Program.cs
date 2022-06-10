using System.Collections.Generic;


//Fundamentals I
// Create a Loop that prints all values from 1-255


// for(int i = 1; i < 256; i++){
//     Console.WriteLine(i);
// }

// Create a new loop that prints all values from 1-100 that are divisible by 3 or 5, but not both

// for(int i = 1; i < 101; i++){
//     if(i % 3 == 0 && i % 5 == 0){

//     }
//     else if(i % 3 == 0 || i % 5 == 0){
//         Console.WriteLine(i);
//     }
// }

// Modify the previous loop to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for numbers that are multiples of both 3 and 5

// for(int i = 1; i < 101; i++){
//     if(i % 3 == 0 && i % 5 == 0){
//         Console.WriteLine("FizzBuzz");
//     }
//     else if(i % 3 == 0){
//         Console.WriteLine("Fizz");
//     }
//     else if(i % 5 == 0){
//         Console.WriteLine("Buzz");
//     }    
// }

//(Optional) If you used "for" loops for your solution, try doing the same with "while" loops. Vice-versa if you used "while" loops!

//int i = 1;

//while(i < 101){
//    if(i % 3 == 0 && i % 5 == 0){
//        Console.WriteLine("FizzBuzz");
//    }
//    else if(i % 3 == 0){
//        Console.WriteLine("Fizz");
//    }
//    else if(i % 5 == 0){
//        Console.WriteLine("Buzz");
//    }
//    i++;    
//}
int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
string[] names = { "Tim", "Martin", "Nikki", "Sara" };
bool[] switches = { true, false, true, false, true, false, true, false, true, false };

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