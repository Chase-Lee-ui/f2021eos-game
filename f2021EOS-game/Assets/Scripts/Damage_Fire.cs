using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//MonoBehavior is the base class from which every Unity script derives.  Must derive from this if using C#
public class Damage_Fire : MonoBehaviour
{
    public float startTime;
    public float time;
    public Health playerHealth;
    public float decay;

    // Update is called once per frame
    void Update()
    {
        //Time is a Unity engine object to detect time. deltaTime is the in-game time. Time.deltaTime is amount of time in between each frame update.
        //question: why subtract the delta time from time?
        time -= Time.deltaTime;
        if(time <= 0)
        {
            this.playerHealth.LifePoints -= decay;
            time = startTime;
        }
    }
    //if an object is in it, OnTriggerStay continues to detect the object as long as it's on the object.
    //OnTriggerEnter only activates on first frame that it collides with object.
    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            //LifePoints is the public float variable from the Health script.
            this.playerHealth = collision.gameObject.GetComponent<Health>();
        }
    }


    void OnTriggerExit(Collider collision)
    {
        //question: is the Collider collision referring to something attached to the player or the fire itself?
        if (collision.gameObject.tag == "Player")
        {
            //LifePoints is the public float variable from the Health script.
            //question: why null?
            this.playerHealth = null;
        }
    }
}
