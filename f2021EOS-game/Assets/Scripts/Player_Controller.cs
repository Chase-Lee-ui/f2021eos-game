using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float MoveSpeed;
    public float TurnSpeed;
    public float JumpHeight = 10f;
    private Rigidbody PlayerBody;
    private bool OnGround;
    void Start ()
    {
        this.PlayerBody = this.gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update ()
    {
        if(this.OnGround && Input.GetKeyDown(KeyCode.Space))
        {
            this.PlayerBody.AddForce(Vector3.up * this.JumpHeight);
            this.OnGround = false;
        }
        //Moves Forward and back along z axis                           //Up/Down
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical")* this.MoveSpeed);
        //Moves Left and right along x Axis                               //Left/Right
        transform.Rotate(Vector3.up, this.TurnSpeed*Input.GetAxis("Horizontal")*Time.deltaTime);      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            this.OnGround = true;
        }
    }
}
