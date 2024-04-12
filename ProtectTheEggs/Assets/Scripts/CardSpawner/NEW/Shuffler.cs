using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shuffler : MonoBehaviour
{
    public CardSOSystem cardSOSystem;
    public RSCards cartasEnMano;
    int currentIndex = 0;
    public List<int> listaDeIndices = new List<int>();
    public float shuffleTime = 5f;

    Coroutine shuffle;
    void Awake()
    {   
        cardSOSystem.SetMazo();
        for(int i = 0; i < cardSOSystem.mazo.Items.Count; i++)
        {
            listaDeIndices.Add(i);
        }
        ShuffleList(listaDeIndices);
    }
    
    void OnEnable()
    {
        cardSOSystem.GetNewCard += GiveCard;
        cardSOSystem.Shuffle += StartShuffleCoroutine;
    }

    void OnDisable()
    {
        cardSOSystem.GetNewCard -= GiveCard;
        cardSOSystem.Shuffle -= StartShuffleCoroutine;
    }

    public void GiveCard()
    {
        if (currentIndex < cardSOSystem.mazo.Items.Count)
        {
        cartasEnMano.Add(cardSOSystem.mazo.Items[listaDeIndices[currentIndex]]);
        currentIndex++;
        }
    }

    void ShuffleList(List<int> list)
    {
        int n = list.Count;
        for (int i = 0; i < n; i++)
        {
            int newIndex = Random.Range(0,n);
            int temp = list[i];
            list[i] = list[newIndex];
            list[newIndex] = temp;
        }
    }

    public void StartShuffleCoroutine(float time)
    {
        shuffleTime = time;
        shuffle = StartCoroutine(ShuffleCoroutine());
    }

    IEnumerator ShuffleCoroutine()
    {
        yield return new WaitForSeconds(shuffleTime);
        ShuffleList(listaDeIndices);
        currentIndex = 0;
        cardSOSystem.ShuffleOver();   
    }
}