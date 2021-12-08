using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float LifePoints;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Damage")
        {
            this.LifePoints -= collision.gameObject.GetComponent<Damage>().DamagePoints;
        }
    }
}
