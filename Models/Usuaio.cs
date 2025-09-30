namespace TP07.Models;

public class Usuario
{
    public string Nombre;
    public int CantidadIntentos;

    public Usuario(string nombre, int cantidadintentos){
        Nombre = nombre;
        CantidadIntentos = cantidadintentos;
    }
}