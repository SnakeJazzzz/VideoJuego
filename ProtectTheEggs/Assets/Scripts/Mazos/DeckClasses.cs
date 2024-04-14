using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListaMazo 
{
   public List<Mazo> Mazos;
}

[System.Serializable]
public class Mazo 
{
   public string NombreMazo;
   public int IDMazo;
   public List<Dato> Datos;

   public void Reset()
   {
      NombreMazo = "";
      Datos.Clear();
   }

}

[System.Serializable]
public class Dato 
{
   public int Cantidad;
   public Card Carta;

}
