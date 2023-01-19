using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speedMove = 0.1f;
    [SerializeField] private float speedRun = 0.1f;
    private Vector3 movement;
    private bool inLand = true;

    [SerializeField] private float smoothRotate = 0.05f;
    private float rVelocity;
     
    private float gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.01f;
    private float gVelocity;

    private Animator ani;
    
    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        ani = GetComponent<Animator>();
    }

   
    void Update()
    {   
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();


        
    }
    private void ApplyMovement()
    {
        float speed;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speedRun;
        }
        else
        {
            speed = speedMove;
        }

            movement = new Vector3(horizontal * speed, gVelocity, vertical* speed);
        
        Vector3 moveSpeed = new Vector3(movement.x, 0f, movement.z);
        if (moveSpeed.magnitude >= 1) {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                ani.SetFloat("Speed", 1.5f);
            }
            else
            {
                ani.SetFloat("Speed", 0.5f);
            }
             
        
        }
        else { ani.SetFloat("Speed", 0f); 
        }

        cc.Move(movement* Time.deltaTime);

        //Debug.Log(movement);
    }
    private void ApplyGravity()
    {
        if(cc.isGrounded && gVelocity < 0.0f)
        {
            gVelocity = -1.0f;
        }
        else
        {
            
            gVelocity += gravity * gravityMultiplier * Time.deltaTime;
        }
    }
    
    private void ApplyRotation()
    {
        Vector2 moveTest = new Vector2(movement.x, movement.z);

        if (moveTest.sqrMagnitude == 0) return;

        var targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.localEulerAngles.y, targetAngle, ref rVelocity, smoothRotate);

        transform.rotation = Quaternion.Euler(0.0f , angle , 0.0f);
    }

    }
