using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    PController pController;
    public float speed;
    public float angleOffset;
    void Awake()
    {
        pController = GetComponent<PController>();
    }

    void Update()
    {
        if (pController.target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, pController.target.transform.position, pController.speed * Time.deltaTime);
        float distanceToClosest = Vector3.Distance(transform.position, pController.target.transform.position); // Ensure you're using the `closest` variable correctly
        if(distanceToClosest <= 0.3)
        {
            //Debug.Log("Invoking Action");
            pController.Attack?.Invoke();
        }

        Vector2 directionToTarget = pController.target.transform.position - transform.position;

        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - angleOffset);
    
    }

}
