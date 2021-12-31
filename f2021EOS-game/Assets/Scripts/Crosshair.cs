using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Crosshair : MonoBehaviour
{
    private GameObject player;
    private RectTransform crosshair;
    private float weaponMult;
    public float restingSize;
    public float maxSize;
    private float currentSize;
    private float velocity;
    public float maxSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        velocity = 0.0f;
        weaponMult = 1.0f;
        currentSize = restingSize;
        crosshair = GetComponent<RectTransform>();
        player = (GameObject)Variables.Application.Get("PlayerObject");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.timeScale > 0)
        {
            velocity = GetPlayerVelocity();

            if (velocity != 0)
            {
                float newSize = maxSize * (velocity / maxSpeed) * weaponMult;
                newSize = Mathf.Clamp(newSize, restingSize, maxSize);
                currentSize = Mathf.Lerp(currentSize, newSize, Time.deltaTime * 10);
            }

            else
                currentSize = Mathf.Lerp(currentSize, restingSize, Time.deltaTime * 10);

            crosshair.sizeDelta = new Vector2(currentSize, currentSize);
        }
    }

    // Set inaccuracy multiplier of weapon
    public void SetWeaponMult(float mult)
    {
        weaponMult = mult;
    }

    // Get the player's velocity
    private float GetPlayerVelocity()
    {
        float v = player.GetComponent<CharacterController>().velocity.magnitude;

        //Debug.Log(velocity);

        return v;
    }
}
