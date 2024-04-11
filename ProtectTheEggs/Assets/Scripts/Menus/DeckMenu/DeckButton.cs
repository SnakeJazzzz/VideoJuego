using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DeckButton : MonoBehaviour
{
    public Selector selector;
    public int index;
    public bool selectable;
    Image image;
    TMP_Text text;
    public void Awake()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<TMP_Text>();
    }
    public void Selected()
    {
        if (selectable)
        {
            selector.NewSelect(index);
        }
    }
    public void Highlight()
    {
        image.color = Color.blue;
    }

    public void UnHighlight()
    {
        image.color = Color.white;
    }

    public void SetText(string s, bool _selectable)
    {
        text.text = s;
        selectable = _selectable;
    }
}
