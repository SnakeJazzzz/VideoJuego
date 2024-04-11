using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadDecks : MonoBehaviour
{

    public UserInformation userInformation;
    public RSRSCards mazos;
    public string apiURL = "http://localhost:3000/api/mazo/";
    void Start()
    {
        mazos.Reset();
        if(!userInformation.loadedDeck)
        {
            StartCoroutine(GetDecks());
        }
        
    }

   
    IEnumerator GetDecks()
    {
        Debug.Log("Starting Coroutine");
        string ruta = apiURL + userInformation.username ;

        UnityWebRequest www = UnityWebRequest.Get(ruta); 
        yield return www.SendWebRequest();

        // If the request fails, we log the error
        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log($"Request failed: {www.error}");
        }
        else 
        {
           
            string data = www.downloadHandler.text;
            Debug.Log(data);

            ListaMazo MyMazos = JsonUtility.FromJson<ListaMazo>(data);

            userInformation.loadedDeck = true;
            
            Debug.Log(MyMazos.Mazos.Count);


            for (int i = 0; i < MyMazos.Mazos.Count; i++)
            {
                mazos.Items[i].nombreMazo = MyMazos.Mazos[i].NombreMazo;
                for (int j = 0; j < MyMazos.Mazos[i].Datos.Count; j++)
                {
                   
                    Debug.Log("Cantidad: "+MyMazos.Mazos[i].Datos[j].Cantidad+"\nCardName: "+MyMazos.Mazos[i].Datos[j].Carta.stats.name);
                    for (int k = 0; k < MyMazos.Mazos[i].Datos[j].Cantidad; k++)
                    {
                        mazos.Items[i].Items.Add(MyMazos.Mazos[i].Datos[j].Carta);
                    }
                }
            }


        }
    }
}
