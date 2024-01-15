using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetControls : MonoBehaviour
{
    //thrust moves jet forward
    public float thrust;

    //multiplies thrust value
    public float thrust_multiplier;

    //multiplies yaw value around the Y axis
    public float yaw_mulitplier;

    //multiplies yaw value around X axis
    public float pitch_multiplier;

    new Rigidbody rigidbody;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float pitch = Input.GetAxis("Vertical");
        float yaw = Input.GetAxis("Horizontal");

        rigidbody.AddRelativeForce(0f, 0f, thrust * thrust_multiplier * Time.deltaTime);
    }


}
