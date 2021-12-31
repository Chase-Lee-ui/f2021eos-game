using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//MonoBehavior is the base class from which every Unity script derives.  Must derive from this if using C#
public class Damage_Fire : MonoBehaviour
{
    public float startTime;
    public float time;
    public float decay;

    void OnTriggerStay(Collider collision)
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            collision.gameObject.GetComponent<Health>().LifePoints -= decay;
            time = startTime;
        }
    }
}
