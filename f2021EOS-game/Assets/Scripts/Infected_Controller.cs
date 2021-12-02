using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infected_Controller : Player_Controller
{
    public float Timer;
    public float TimerCap;
    public float MaxSpeed;
    public override void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(this.OnGround && Input.GetKey(KeyCode.Space))
        {
            if(this.Timer <= this.TimerCap)
            {
                this.Timer +=  Time.deltaTime * 2;
            }
        }
        else
        {
            var vertInput = Input.GetAxis("Vertical");
            this.PlayerBody.AddForce(Vector3.up * this.JumpHeight * this.Timer);
            this.Timer = 0;
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

            
        }
        //Moves Left and right along x Axis                               //Left/Right
        transform.Rotate(Vector3.up, this.TurnSpeed*Input.GetAxis("Horizontal")*Time.deltaTime);
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            this.OnGround = false;
        }
    }
}
