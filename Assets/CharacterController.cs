using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CharacterController : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed;
    public bool switchLane;
    public Vector3 currentSpeed;
    public Vector3 targetpos;

    public Vector3[] Lane = new Vector3[3]
    {
        new Vector3(-3f, 0f, 0f),
        new Vector3(0f, 0f, 0f),
        new Vector3(3f, 0f, 0f)
    };

    public int currentLane;

    public float laneSwitchSpeed;
    public Vector3 jumpForce;

    public void Start()
    {
        //Physics.gravity = new Vector3(0f, -9.81f, 0f);
        Physics.gravity = new Vector3(0f, -9.81f * 2, 0f);
    }

    public void Update()
    {
        if (switchLane)
            return;
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (currentLane - 1 >= 0)
            {
                currentLane -= 1;
                switchLane = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (currentLane + 1 <= 2)
            {
                currentLane += 1;
                switchLane = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }
    }

    public void FixedUpdate()
    {
        //rb.MovePosition(rb.position + Vector3.up * Time.deltaTime);
        //rb.AddForce(transform.forward * Speed, ForceMode.VelocityChange);
        rb.velocity = transform.forward * Speed + new Vector3(0, rb.velocity.y, 0);
        ;
        currentSpeed = rb.velocity;
        if (switchLane)
        {
            rb.MovePosition(Vector3.Lerp(rb.position, new Vector3(Lane[currentLane].x, rb.position.y, rb.position.z),
                laneSwitchSpeed * Time.fixedDeltaTime));
            Debug.Log(Mathf.Abs(rb.position.x - Lane[currentLane].x));
            if (Mathf.Abs(rb.position.x - Lane[currentLane].x) < 0.2f)
            {
                switchLane = false;
                rb.position = new Vector3(Lane[currentLane].x, rb.position.y, rb.position.z);
                //rb.MovePosition(rb.position + Lane[currentLane]);
            }
        }
    }
}