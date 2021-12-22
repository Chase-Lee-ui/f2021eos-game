using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float LifePoints;

    public void TakeDamage(float damageAmount)
    {
        LifePoints -= damageAmount;
        if (LifePoints < 0)
            LifePoints = 0;

        Debug.Log(this.name + " took " + damageAmount + " damage : " + LifePoints + " hp left");

        if (LifePoints <= 0)
            Destroy(gameObject);
    }
}
