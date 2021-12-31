using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player_Controller : MonoBehaviour
{
    public CharacterController Controller;
    public float Speed = 12.0f;
    public float Gravity = -9.81f;
    public float JumpHeight = 3.0f;
    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    Vector3 Velocity;
    public bool IsGrounded;
    PhotonView View;
    public Camera LocalCamera;
    // Update is called once per frame

    private void Start()
    {
        View = GetComponent<PhotonView>();
        if(View.IsMine) LocalCamera.enabled = true;
    }
    void Update()
    {
        this.IsGrounded = Physics.CheckSphere(this.GroundCheck.position, this.GroundDistance, this.GroundMask);

        if(this.IsGrounded && this.Velocity.y < 0)
        {
            this.Velocity.y = -2f;
        }

        if(View.IsMine)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            this.Controller.Move(move * this.Speed * Time.deltaTime);

            if(Input.GetKeyDown("space") && this.IsGrounded)
            {
                this.Velocity.y = Mathf.Sqrt(this.JumpHeight * -2.0f * this.Gravity);
            }

            this.Velocity.y += this.Gravity * Time.deltaTime;

            this.Controller.Move(this.Velocity * Time.deltaTime);
        }
    }
}
