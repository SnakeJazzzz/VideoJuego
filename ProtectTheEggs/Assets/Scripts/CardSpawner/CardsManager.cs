using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public RSCards cartasEnMano;
    public RSCards mazo;
    int currentIndex = 0;
    public List<int> listaDeIndices = new List<int>();

    Coroutine shuffle;
    void Awake()
    {
        for(int i = 0; i < mazo.Items.Count; i++)
        {
            listaDeIndices.Add(i);
        }
        ShuffleList(listaDeIndices);

    }

    void OnDisable()
    {
        cartasEnMano.Items.Clear();
    }

    public void RefillCards()
    {
        while (currentIndex < mazo.Items.Count && cartasEnMano.Items.Count < 6)
        {
            cartasEnMano.Add(mazo.Items[listaDeIndices[currentIndex]]);
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

    public void StartShuffleCoroutine()
    {
        shuffle = StartCoroutine(ShuffleCoroutine());
    }

    IEnumerator ShuffleCoroutine()
    {
        yield return new WaitForSeconds(5f);
        ShuffleList(listaDeIndices);
        currentIndex = 0;
        RefillCards();
    }



}
