using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

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
    AudioSource engineSound;

    [SerializeField] TextMeshProUGUI HUD;
    

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
        engineSound = GetComponent<AudioSource>();
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
        UpdateHUD();

        engineSound.volume = Throttle * 0.01f;
    }


    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * maxThrust * Throttle);
        rb.AddTorque(transform.up * Yaw * responseModifier);
        rb.AddTorque(transform.right * Pitch * responseModifier);
        rb.AddTorque(transform.forward * Roll * responseModifier);
    }

    private void UpdateHUD()
    {
        HUD.text = "Throttle " + Throttle.ToString("F0") + "%\n";
        HUD.text += "Speed: " + (rb.velocity.magnitude * 3.6f).ToString("F0") + "km/h\n";
    }
}
