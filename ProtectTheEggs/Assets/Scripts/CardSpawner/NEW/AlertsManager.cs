using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertsManager : MonoBehaviour
{
    public CardSOSystem cardSOSystem;
    public GameObject NoCardSelectedoBanner;
    public GameObject NotEnoughElixirBanner;
    public GameObject ReshufflingDeckBanner;
    Coroutine NoCardSelectedCoroutine;
    Coroutine NotEnoughElixirCoroutine;
    Coroutine ReshufflingDeckCoroutine;

    void OnEnable()
    {
        cardSOSystem.NoCardSelected += DisplayNoCardSelected;
        cardSOSystem.NotEnoughElixir += DisplayNotEnoughElixir;
        cardSOSystem.Shuffle += DisplayReshufflingDeck;
    }

    void DisplayNoCardSelected()
    {
        if (NoCardSelectedCoroutine != null)
        {
            StopCoroutine(NoCardSelectedCoroutine);
        }
        NoCardSelectedCoroutine = StartCoroutine(NoCardSelected());
    }

    IEnumerator NoCardSelected()
    {
        NoCardSelectedoBanner.SetActive(true);
        yield return new WaitForSeconds(1f);
        NoCardSelectedoBanner.SetActive(false);
    }

    void DisplayNotEnoughElixir()
    {
        if (NotEnoughElixirCoroutine != null)
        {
            StopCoroutine(NotEnoughElixirCoroutine);
        }
        NotEnoughElixirCoroutine = StartCoroutine(NotEnoughElixir());
    }

    IEnumerator NotEnoughElixir()
    {
        NotEnoughElixirBanner.SetActive(true);
        yield return new WaitForSeconds(1f);
        NotEnoughElixirBanner.SetActive(false);
    }

    void DisplayReshufflingDeck(float time)
    {
        ReshufflingDeckCoroutine = StartCoroutine(Shuffle(time));
    }

    IEnumerator Shuffle(float time)
    {
        ReshufflingDeckBanner.SetActive(true);
        yield return new WaitForSeconds(time);
        ReshufflingDeckBanner.SetActive(false);
    }
}