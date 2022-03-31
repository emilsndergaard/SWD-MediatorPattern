







public abstract class Kirurgi : Afdeling
{
    public string printType { get; protected set; }
    public void RequestPrint(string request)
    {
        Console.WriteLine(this + " efterspørg print af " + request + ".");
        this._mediator.Notify(this, new Print(printType, request, this));
    }
    public void AfhenterPrint(Print print) => Console.WriteLine(this + " henter print " + print.name + " nu.");
}
