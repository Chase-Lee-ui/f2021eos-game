using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float MoveSpeed;
    public float TurnSpeed;
    public float JumpHeight = 10f;
    protected Rigidbody PlayerBody;
    protected bool OnGround;
    private float MaxSpeed = 20.0f;
    void Start ()
    {
        this.PlayerBody = this.gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    public virtual void Update ()
    {
        if(this.OnGround && Input.GetKeyDown(KeyCode.Space))
        {
            this.PlayerBody.AddForce(Vector3.up * this.JumpHeight);
            this.OnGround = false;
        }
        //Moves Forward and back along z axis                           //Up/Down
        var vertInput = Input.GetAxis("Vertical");
            //Moves Forward and back along z axis                           //Up/Down
            this.PlayerBody.AddRelativeForce(Vector3.forward * vertInput * this.MoveSpeed, ForceMode.Impulse);
            if(!this.OnGround)
            {
                this.PlayerBody.AddRelativeForce(Vector3.down * 9.8f);
            }
            
            if(this.PlayerBody.velocity.magnitude > this.MaxSpeed)
            {
                this.PlayerBody.velocity = this.PlayerBody.velocity.normalized * this.MaxSpeed;
            }

            if(vertInput == 0)
            {
                this.PlayerBody.velocity = new Vector3(this.PlayerBody.velocity.x / 2.0f, this.PlayerBody.velocity.y, this.PlayerBody.velocity.z / 2.0f);
            }
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

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            this.OnGround = false;
        }
    }
}
