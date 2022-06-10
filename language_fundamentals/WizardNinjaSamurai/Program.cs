Wizard gandalf = new Wizard ("Gandalf", 5, 10);
Ninja hanzo = new Ninja("Hanzo", 25, 5, 75);
Samurai goat = new Samurai("Chuck Norris", 500, 500, 500);

Console.WriteLine($"Name: {gandalf.Name}");
Console.WriteLine($"Strength: {gandalf.Strength}");
Console.WriteLine($"Intelligence: {gandalf.Intelligence}");
Console.WriteLine($"Dexterity: {gandalf.Dexterity}");
Console.WriteLine($"Health: {gandalf.Health}");

Console.WriteLine("");

Console.WriteLine($"Name: {hanzo.Name}");
Console.WriteLine($"Strength: {hanzo.Strength}");
Console.WriteLine($"Intelligence: {hanzo.Intelligence}");
Console.WriteLine($"Dexterity: {hanzo.Dexterity}");
Console.WriteLine($"Health: {hanzo.Health}");

Console.WriteLine("");

Console.WriteLine($"Name: {goat.Name}");
Console.WriteLine($"Strength: {goat.Strength}");
Console.WriteLine($"Intelligence: {goat.Intelligence}");
Console.WriteLine($"Dexterity: {goat.Dexterity}");
Console.WriteLine($"Health: {goat.Health}");

gandalf.Attack(hanzo);
gandalf.Attack(hanzo);

hanzo.Steal(gandalf);
hanzo.Attack(gandalf);
hanzo.Attack(gandalf);

gandalf.Attack(hanzo);
gandalf.Attack(hanzo);

goat.Meditate();
goat.Attack(gandalf);
goat.Attack(hanzo);



