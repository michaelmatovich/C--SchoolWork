class Ninja : Human{
    
    public Ninja(string name, int str, int intel, int hp, int dex = 175) : base(name, str, intel, dex, hp)
    {
        
    }

    public override int Attack(Human target)
    {   
        Random rdm = new Random();
        bool isCritical = rdm.Next(1,6) == 1;

        int dmg = isCritical ? Dexterity * 5 + 10: Dexterity * 5;
        target.Health -= dmg;
        Health += dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;        
    }
    public int Steal(Human target)
    {        
        target.Health += 5;
        Health += 5;
        Console.WriteLine($"{Name} healed {target.Name} for 5 health!");
        return target.Health;
    }
}