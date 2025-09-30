using System;
namespace TP07.Models;

public class Juego
{
    public List<Palabra> ListaPalabras = new List<Palabra>();
    public List<Usuario> Jugadores = new List<Usuario>();
    public Usuario JugadorActual;
    public string PalabraActual {get; private set;}

    public void LlenarListaPalabras(){
        ListaPalabras = new List<Palabra>
            {
                // Dificultad 1 (fáciles)
                new Palabra("Sol", 1),
                new Palabra("Mar", 1),
                new Palabra("Pan", 1),
                new Palabra("Casa", 1),
                new Palabra("Gato", 1),
                new Palabra("Perro", 1),
                new Palabra("Flor", 1),
                new Palabra("Mesa", 1),
                new Palabra("Libro", 1),
                new Palabra("Mano", 1),

                // Dificultad 2 (intermedias)
                new Palabra("Amigos", 2),
                new Palabra("Ventana", 2),
                new Palabra("Camino", 2),
                new Palabra("Escuela", 2),
                new Palabra("Jardin", 2),
                new Palabra("Mercado", 2),
                new Palabra("Animal", 2),
                new Palabra("Cocina", 2),
                new Palabra("Trabajo", 2),
                new Palabra("Sombrero", 2),

                // Dificultad 3 (difíciles)
                new Palabra("Mariposa", 3),
                new Palabra("Aventura", 3),
                new Palabra("Esperanza", 3),
                new Palabra("Relampago", 3),
                new Palabra("Biblioteca", 3),
                new Palabra("Computadora", 3),
                new Palabra("Tradicion", 3),
                new Palabra("Montana", 3),
                new Palabra("Hipopotamo", 3),
                new Palabra("Constelacion", 3),

                // Dificultad 4 (muy difíciles / poco comunes)
                new Palabra("Quimera", 4),
                new Palabra("Quetzal", 4),
                new Palabra("Xilofono", 4),
                new Palabra("Circunstancia", 4),
                new Palabra("Paralelepipedo", 4),
                new Palabra("Anacronico", 4),
                new Palabra("Idiosincrasia", 4),
                new Palabra("Onomatopeya", 4),
                new Palabra("Inconmensurable", 4),
                new Palabra("Metempsicosis", 4),
            };
    }

    public void InicializarJuego(string usuario, int dificultad){
        Usuario jugador = new Usuario(usuario, 0);
        JugadorActual = jugador;
        PalabraActual = CargarPalabra(dificultad);
    }
    private string CargarPalabra(int dificultad){
        List<Palabra> palabrasDificultad = new List<Palabra>();
        foreach (Palabra palabra in ListaPalabras){
            if (palabra.Dificultad == dificultad){
                palabrasDificultad.Add(palabra);
            }
        }
        Random aleatorio = new Random();
        int numeroAleatorio = aleatorio.Next(1, palabrasDificultad.Count);
        return palabrasDificultad[numeroAleatorio].Texto;

    }
    public void FinJuego(){
        bool yaExiste = false;
        int posicion = -1;
        int i = 0;
        while(i < Jugadores.Count && yaExiste == false){
            if (Jugadores[i].Nombre == JugadorActual.Nombre){
                yaExiste = true;
                posicion = i;
            }
            i++;
        }
        if (yaExiste){
            if(Jugadores[i].CantidadIntentos > JugadorActual.CantidadIntentos){
                Jugadores[i].CantidadIntentos = JugadorActual.CantidadIntentos;
            }
        }else{
            Jugadores.Add(JugadorActual);
        }
    }
    public List<Usuario> DevolverListaUsuarios(){ //arreglar!!
        List<Usuario> usuariosOrdenados = new List<Usuario>();
        foreach (Usuario usuario in Jugadores){
            bool tieneMenosIntentos = false;
            int i = 0;
            while(i < usuariosOrdenados.Count && tieneMenosIntentos == false){
                if(usuariosOrdenados[i].CantidadIntentos < usuario.CantidadIntentos){
                    tieneMenosIntentos = true;
                }
                i++;
            }
            usuariosOrdenados[i] = usuario;
        }
        return usuariosOrdenados
    }
}