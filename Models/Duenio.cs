namespace Test1.Models;

public class Duenio
{
    public int Id { set; get;}

    public int? Edad { set; get;}

    public string? Nombre { set; get;}

    public string? Correo { set; get;}

    public List<Casas_duenio>Casas_Duenios { set; get; }

    public List<Carros_duenio>Carros_Duenios { get; set; }

    public Duenio(){
        Casas_Duenios = new List<Casas_duenio>(); 
        Carros_Duenios = new List<Carros_duenio>();
    }
}