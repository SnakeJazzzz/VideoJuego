using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour
{
    public float speed;
    public float damage;
    public GameObject target;

    public void SetData(GameObject t, float s, float d)
    {
        target = t;
        speed = s;
        damage = d;
    }
}
