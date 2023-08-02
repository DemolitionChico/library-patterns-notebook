namespace PatternsNotebook.Behavioral.TemplateMethod.FirearmsExample;

public abstract class FirearmShooter
{
    public void Shoot()
    {
        Load();
        ShootTillEmpty();
        Unload();
        Clean();
    }

    // Virtual method - this might not be required along the process
    protected virtual void Clean()
    {
    }

    protected abstract void Unload();

    protected abstract void ShootTillEmpty();

    protected abstract void Load();
}

class AK74Shooter : FirearmShooter
{
    protected override void Unload()
    {
        Console.WriteLine("Drop all the magazines in the mud not giving a single fuck");
    }

    protected override void ShootTillEmpty()
    {
        Console.WriteLine("Close range, no need to aim");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Pew!");
        }
        Console.WriteLine("Haha, I have a second magazine");
        Console.WriteLine("Long range now, still no need to aim");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Pew!");
        }
    }

    protected override void Load()
    {
        Console.WriteLine("Inserting a dirty old magazine");
    }
}

class CzShadowShooter : FirearmShooter
{
    protected override void Unload()
    {
        Console.WriteLine("Perform a fancy reload catching the last bullet");
    }

    protected override void ShootTillEmpty()
    {
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine("Aim...");
            Console.WriteLine("Pew!");
        }
    }

    protected override void Load()
    {
        Console.WriteLine("Insert magazine and pull the slide");
    }

    protected override void Clean()
    {
        Console.WriteLine("Spend next hour on cleaning the gun");
    }
}