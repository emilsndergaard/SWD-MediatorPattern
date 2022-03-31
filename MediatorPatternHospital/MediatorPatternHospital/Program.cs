

Console.WriteLine("Hello, Hospital!");

Kardiologi kardi = new Kardiologi("Blød");
Neurologi neuro = new Neurologi("Blød");
Ortopædkirugi orto = new Ortopædkirugi("Hård");
ConcreteMediator cm = new ConcreteMediator(kardi, neuro, orto, new PrintCenterNord(), new PrintCenterSyd());

Console.WriteLine("Kardiologi har behov for et hjerte print.");
kardi.RequestPrint("Hjerte");
Console.WriteLine("");
Console.WriteLine("");

Console.WriteLine("Ortopæd har behov for et femur print.");
orto.RequestPrint("Femur");
Console.WriteLine("");
Console.WriteLine("");

Console.WriteLine("Neurologi har behov for et hjerne print.");
neuro.RequestPrint("Hjerne");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("Tryk på en knap for at lukke programmet.");
Console.ReadKey();


public abstract class Afdeling
{
    /*
     * Afdeling er implementeret som et BaseComponent, som holder styr på, at alle som anvender Mediator, anvender det samme objekt.
     */
    protected IMediator _mediator;
    public Afdeling(IMediator mediator = null) => this._mediator = mediator;
    public void SetMediator(IMediator mediator) => this._mediator = mediator;
}
