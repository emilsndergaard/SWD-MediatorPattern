







public class Print
{
    public string printElement { get; }
    public string name { get; }
    public object printSender { get; }
    public Print(string printElement, string name, object printSender)
    {
        this.printElement = printElement;
        this.name = name;
        this.printSender = printSender;
    }
}
