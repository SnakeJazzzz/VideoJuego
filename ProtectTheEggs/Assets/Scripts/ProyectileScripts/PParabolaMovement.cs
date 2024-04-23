using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PParabolaMovement : MonoBehaviour
{
    PController pController;
    List<float> equation;

    float maxX;
    void Awake()
    {
        pController = GetComponent<PController>();
    }

    void Start()
    {
        
        float x1 = transform.position.x;
        float y1 = transform.position.y;
        float x2 = pController.target.transform.position.x;
        float y2 = pController.target.transform.position.y;
        maxX = x2;
        /*
        float x1 = 1;
        float y1 = 1;
        float x2 = 4;
        float y2 = 2;*/


        //Debug.Log("Start: ("+x1+","+y1+")");
        //Debug.Log("Finish: ("+x2+","+y2+")");
        equation = FindParabolaEquation(x1,y1,x2,y2, pController.angle);
        //Debug.Log("A: " + equation[0] + "B: " + equation[1] + "C:" + equation[2]);
    }


     void Update()
    {
        
        Vector3 vector3 = transform.position;
        vector3.x += pController.speed * Time.deltaTime;
        vector3.y = equation[0] * vector3.x * vector3.x + equation[1] * vector3.x + equation[2];

        transform.position = vector3;

        if (vector3.x > maxX)
        {
            pController.Attack?.Invoke();
        }

        //transform.position = Vector3.MoveTowards(transform.position, pController.target.transform.position, pController.speed * Time.deltaTime);
    }

    public List<float> FindParabolaEquation(float x1, float y1, float x2, float y2, float angle)
    {
        float m = (float) Math.Tan(angle * (Math.PI / 180));

        float a =  (float) (y2-x2*m-y1+x1*m)/(x2*x2-2*x1*x2+x1*x1);

        float b = m - 2*a*x1;

        float c = (float)  y1 - (a*x1*x1+ b *x1);

        return new List<float> {a, b, c};
    }


}
