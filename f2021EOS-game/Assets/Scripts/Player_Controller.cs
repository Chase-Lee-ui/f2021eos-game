using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player_Controller : MonoBehaviour
{
    private CharacterController controller;
    private float verticalVelocity;
    private float groundedTimer;        // to allow jumping when going down ramps
    public float playerSpeed;
    public float jumpHeight;
    private float gravityValue = 9.81f;

    private void Start()
    {
        // always add a controller
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        bool groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            // cooldown interval to allow reliable jumping even whem coming down ramps
            groundedTimer = 0.2f;
        }
        if (groundedTimer > 0)
        {
            groundedTimer -= Time.deltaTime;
        }

        // slam into the ground
        if (groundedPlayer && verticalVelocity < 0)
        {
            // hit ground
            verticalVelocity = 0f;
        }

        // apply gravity always, to let us track down ramps properly
        verticalVelocity -= gravityValue * Time.deltaTime;

        // gather lateral input control
        Vector3 move = Vector3.zero;
        move += transform.right * Input.GetAxis("Horizontal");
        move += transform.forward * Input.GetAxis("Vertical");
        move.y = 0;

        // scale by speed
        move *= playerSpeed;

        // allow jump as long as the player is on the ground
        if (Input.GetButtonDown("Jump"))
        {
            // must have been grounded recently to allow jump
            if (groundedTimer > 0)
            {
                // no more until we recontact ground
                groundedTimer = 0;

                // Physics dynamics formula for calculating jump up velocity based on height and gravity
                verticalVelocity += Mathf.Sqrt(jumpHeight * 2 * gravityValue);
            }
        }

        // inject Y velocity before we use it
        move.y = verticalVelocity;

        // call .Move() once only
        controller.Move(move * Time.deltaTime);
    }
}

/*--------------------------Old code--------------------------
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
            this.Velocity.y = 0;
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
--------------------------Old code--------------------------*/
