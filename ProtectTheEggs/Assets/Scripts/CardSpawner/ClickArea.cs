using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickArea : MonoBehaviour
{
    public CardSOSystem cardSOSystem;
    public float highlightDuration = 0.5f; // Duration in seconds for which the outline is visible
    private LineRenderer lineRenderer;
    private PolygonCollider2D polygonCollider;
    private Coroutine highlightCoroutine;
    public string buttonClickSoundName;

    void Awake()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Start()
    {
        lineRenderer.startColor = Color.yellow;
        lineRenderer.endColor = Color.yellow;

        lineRenderer.positionCount = polygonCollider.points.Length;
        //Hide
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!polygonCollider.OverlapPoint(mousePosition))
            { 
                StartCoroutine(ShowHighlight());
            }
            else
            {
                cardSOSystem.OnClick();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Debug.Log("1 selected.");
            cardSOSystem.NewSelected(1);
            SoundManager.Instance.PlaySFXByName(buttonClickSoundName);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Debug.Log("2 selected.");
            cardSOSystem.NewSelected(2);
            SoundManager.Instance.PlaySFXByName(buttonClickSoundName);        
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Debug.Log("3 selected.");
            cardSOSystem.NewSelected(3); 
            SoundManager.Instance.PlaySFXByName(buttonClickSoundName);       
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //Debug.Log("4 selected.");
            cardSOSystem.NewSelected(4);
            SoundManager.Instance.PlaySFXByName(buttonClickSoundName);        
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //Debug.Log("5 selected.");
            cardSOSystem.NewSelected(5);
            SoundManager.Instance.PlaySFXByName(buttonClickSoundName);        
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            //Debug.Log("6 selected.");
            cardSOSystem.NewSelected(6);
            SoundManager.Instance.PlaySFXByName(buttonClickSoundName);        
        }
    }


    private void DrawOutline()
    {
        Vector2 transformPosition = transform.position;
        for (int i = 0; i < polygonCollider.points.Length; i++)
        {
            lineRenderer.SetPosition(i, transformPosition + polygonCollider.points[i]);
        }
        lineRenderer.loop = true; // Ensure the outline is closed
        lineRenderer.enabled = true;
    }

    private IEnumerator ShowHighlight()
    {
        DrawOutline();
        yield return new WaitForSeconds(highlightDuration);
        Debug.Log("Hiding outline.");
        lineRenderer.enabled = false;
    }

     public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
   
}