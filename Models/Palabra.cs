namespace TP07.Models;

public class Palabra
{
    public string Texto;
    public int Dificultad;
    public Palabra(string Texto, int dificultad){
        this.Texto = Texto;
        Dificultad = dificultad;
    }
}
