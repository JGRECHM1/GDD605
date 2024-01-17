using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class MissileFire : MonoBehaviour
{
    public Transform missileSpawn;
    public GameObject missilePrefab;
    public float speed = 5f;


    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var missile = Instantiate(missilePrefab, missileSpawn.position, missileSpawn.rotation);
            missile.GetComponent<Rigidbody>().velocity = missileSpawn.forward * speed;
        }
    }
}
