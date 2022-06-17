using System;
using System.Collections;



    static bool Palindrome(string a){

        int first = 0;
        int last = a.Length-1;

        if(a.Length == 0){
            return false;
        }

        for(int i = 0; i < a.Length/2; i++){
            Console.Write($"First: {a[first]}, Last: {a[last]}, Index: {i}");
            
            if(a[first] != a[last]){
                return false;
            }
            first++;
            last--;
        }

        return true;
    }


Console.WriteLine(Palindrome("dot saw I was tod"));//expect true
// Console.WriteLine(Palindrome("I think I like pizza"));//expect false
// Console.WriteLine(Palindrome(""));//expect falsey? 
// Console.WriteLine(Palindrome("bob"));//expect true


