using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    // how much the engine throttle goes up by
    public float throttleIncrement = 0.1f;
    // maxmimum engine thrust when at 100% throttle
    public float maxThrust = 200f;
    // plane responsiveness when moving
    public float responsiveness = 10f;

    private float pitch;
    private float roll;
    private float yaw;
    private float throttle;

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
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Roll");
        yaw = Input.GetAxis("Roll");

        if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }


    private void Update()
    {
        handleInputs();
    }


    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(transform.forward * roll * responseModifier);
    }


}
