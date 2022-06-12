// See https://aka.ms/new-console-template for more information

Random rdm = new Random();

string passcode = "";
string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

for(int i = 0; i < 14; i++)
{
    passcode = passcode + chars[rdm.Next(0,37)].ToString();
}

Console.WriteLine(passcode);