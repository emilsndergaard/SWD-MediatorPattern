public abstract class PrintCenter : Afdeling
{

    public void PrintRequestRecieved(object sender, Print print)
    {
        Console.WriteLine(this + " har startet et print med " + print.name + "fra " + sender + ".");
        
        int sleepTime = 5;
        while (sleepTime != 0)
        {
            Console.WriteLine("...");
            Thread.Sleep(1000);
            sleepTime--;
        }
        PrintDone(sender, print);
    }

    private void PrintDone(object sender, Print print)
    {
        Console.WriteLine(sender + " har et " + print.name + " print som er klar til afhentning hos " + this + ".");
        this._mediator.Notify(this, print);
    }

}

public class PrintCenterSyd : PrintCenter { }
public class PrintCenterNord : PrintCenter { }

