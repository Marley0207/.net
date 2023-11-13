namespace Test1.Models;

public class Casas_duenio
{
    public int Id { set; get;}

    public string? nombre_casa { set; get; }

    public int? precio { set; get; }

    public int DuenioId { set; get;}

    public Duenio? Duenio { set; get; }  
}