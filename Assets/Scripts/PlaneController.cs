using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneController : MonoBehaviour
{
    // how much the engine throttle goes up by
    public float throttleIncrement = 0.1f;
    // maxmimum engine thrust when at 100% throttle
    public float maxThrust = 200f;
    // plane responsiveness when moving
    public float responsiveness = 10f;

    private float Pitch;
    private float Roll;
    private float Yaw;
    private float Throttle;

    Rigidbody rb;

    private float responseModifier
    {
        get
        {
            return (rb.mass / 10f) *responsiveness;
        }
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void handleInputs()
    {
        Roll = Input.GetAxis("Roll");
        Pitch = Input.GetAxis("Pitch");
        Yaw = Input.GetAxis("Yaw");

        if (Input.GetKey(KeyCode.Space)) Throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) Throttle -= throttleIncrement;
        Throttle = Mathf.Clamp(Throttle, 0f, 100f);
    }


    private void Update()
    {
        handleInputs();
    }


    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * maxThrust * Throttle);
        rb.AddTorque(transform.up * Yaw * responseModifier);
        rb.AddTorque(transform.right * Pitch * responseModifier);
        rb.AddTorque(transform.forward * Roll * responseModifier);
    }


}
