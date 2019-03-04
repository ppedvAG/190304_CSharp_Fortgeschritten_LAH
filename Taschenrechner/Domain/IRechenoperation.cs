namespace Domain
{
    public interface IRechenoperation
    {
        string Operator { get; }
        int Berechne(int zahl1, int zahl2);
    }

}
