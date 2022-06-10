class Wizard : Human{


    
    public Wizard(string name, int str, int dex, int intel = 25, int hp = 50) : base(name, str, intel, dex, hp)
    {
        
    }

    public override int Attack(Human target)
    {
        int dmg = Intelligence * 5;
        target.Health -= dmg;
        Health += dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;        
    }
    public int Heal(Human target)
    {
        int heal = Intelligence * 10;
        target.Health += heal;
        Console.WriteLine($"{Name} healed {target.Name} for {heal} health!");
        return target.Health;
    }
}