using System;

// Esta clase representa la información básica de una carta en el juego.
[System.Serializable]
public class Cards
{
    public string Nombre;
    public string Descripcion;
    public int Vida;
    public float Velocidad;
    public int Daño;
    public float VelocidadAtaque;
    public float Rango;
    public int CostoElixir;
    public string Tipo;
    public string NombreArchivoImagen;
    public string NombreMarco;
    public string NombreArchivoSonido;

    // Constructor
    public Cards(string nombre, string descripcion, int vida, float velocidad, int daño, float velocidadAtaque, float rango, int costoElixir, string tipo, string nombreArchivoImagen, string nombreMarco, string nombreArchivoSonido)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        Vida = vida;
        Velocidad = velocidad;
        Daño = daño;
        VelocidadAtaque = velocidadAtaque;
        Rango = rango;
        CostoElixir = costoElixir;
        Tipo = tipo;
        NombreArchivoImagen = nombreArchivoImagen;
        NombreMarco = nombreMarco;
        NombreArchivoSonido = nombreArchivoSonido;
    }
}

