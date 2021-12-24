using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float LifePoints;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            this.LifePoints -= collision.gameObject.GetComponent<Damage>().DamagePoints;
        }
    }

    //Revamp starts:
    /*
    public void addHealth(float addAmount)
    {
        LifePoints += addAmount;
    }

    public void updateHealth()
    {
        LifePointsValue.text = LifePoints.ToString();
        healthSlider.value = LifePoints;
    }

    */
}
