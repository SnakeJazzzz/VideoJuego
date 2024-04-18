using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    PController pController;
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
            pController.target.GetComponent<IDamageable>().TakeDamage(pController.damage);
            Destroy(this.gameObject);
            return;
        }
    }

}
