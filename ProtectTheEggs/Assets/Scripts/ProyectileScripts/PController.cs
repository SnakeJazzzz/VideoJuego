using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PController : MonoBehaviour
{
    public float speed;
    public float damage;
    public float radius;
    public int team;
    public GameObject target;
    public Action Attack;

    public void SetData(GameObject t, float s, float d, float r, int _team)
    {
        target = t;
        speed = s;
        damage = d;
        radius = r;
        team = _team;
    }
}
