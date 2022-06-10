class Samurai : Human{
    
    public Samurai(string name, int str, int intel, int dex, int hp = 200) : base(name, str, intel, dex, hp)
    {
        
    }
    public override int Attack(Human target)
    {
        int dmg = Strength * 3;
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        if(target.Health < 50){
            target.Health = 0;
            Console.WriteLine($"{Name} lands a killing blow!");
        }
        return target.Health;
    }

    public int Meditate(){
        Console.WriteLine($"{Name} meditates deeply... Full health restored!");
        Health = 200;
        return Health;
    }

}