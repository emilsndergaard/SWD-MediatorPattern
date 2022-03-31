





/**
 * ConcreteMediator er controller klassen som afkobler systemet fra at kende til hinanden, ved kun at kende ConcreteMediator.
 * 
 * 
 */
public class ConcreteMediator : IMediator
{
    private Kardiologi kardiologi;
    private Neurologi neurologi;
    private Ortopædkirugi ortopædkirugi;
    private PrintCenterNord printCenterNord;
    private PrintCenterSyd printCenterSyd;

    public ConcreteMediator(Kardiologi kardiologi, Neurologi neurologi, Ortopædkirugi ortopædkirugi, PrintCenterNord printCenterNord, PrintCenterSyd printCenterSyd)
    {
        this.kardiologi = kardiologi;
        this.kardiologi.SetMediator(this);

        this.neurologi = neurologi;
        this.neurologi.SetMediator(this);

        this.ortopædkirugi = ortopædkirugi;
        this.ortopædkirugi.SetMediator(this);

        this.printCenterNord = printCenterNord;
        this.printCenterNord.SetMediator(this);

        this.printCenterSyd = printCenterSyd;
        this.printCenterSyd.SetMediator(this);

    }

    /*
     * Notify er klassens single public metode, som kaldes af alle koblede klasser.
     * Den afgør hvilken Child of Afdeling, som har kaldt Notify() og kalder efterfølgende Notify- eller Notify-PrintCenter.
    */
    public void Notify(object sender, Print print)
    {
        Console.WriteLine("Mediator reagerer på " + sender + " og starter følgende handling:");
        if (sender.GetType().BaseType == typeof(Kirurgi)) 
            NotifyPrintCenter((Kirurgi)sender, print);
        else NotifyKirurgi((PrintCenter)sender, print);
    }

    /*
     * ConcreteMediator har 2 private metoder som kaldes af Notify().
     *
     * Hver især sikre de, at den korrete handling sker når en Afdeling anvender Notify().
     *  
     * De modtager begge en Afdeling, enten PrintCenten eller Kirugi som object og et Print object som skal printes, eller returneres.
     * 
     * 
     * NotifyKirurgi giver besked til en Kirurgisk afdeling når PrintCenter Notifier om at deres print er færdigt.
     * 
     * NotifyPrintCenter giver besked til PrintCenter, at et nyt print skal laves.
     * 
     */
    private void NotifyKirurgi(PrintCenter sender, Print print)
    {
        if (print.printSender.GetType() == typeof(Kardiologi)) 
            this.kardiologi.AfhenterPrint(print);
        else if (print.printSender.GetType() == typeof(Neurologi))  
            this.neurologi.AfhenterPrint(print);
        else if (print.printSender.GetType() == typeof(Ortopædkirugi)) 
            this.ortopædkirugi.AfhenterPrint(print);
        else Console.WriteLine("Den valgte afdeling er ikke implementeret i Mediator");
    }

    private void NotifyPrintCenter(Kirurgi sender, Print print)
    {
        if (sender.printType == "Blød") 
            this.printCenterSyd.PrintRequestRecieved(sender, print);
        else if (sender.printType == "Hård") 
            this.printCenterNord.PrintRequestRecieved(sender, print);
        else  Console.WriteLine("Det valgte element kan ikke håndteres"); 
    }
}
