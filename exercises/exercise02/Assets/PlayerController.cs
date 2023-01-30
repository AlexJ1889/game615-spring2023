using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public float speed;
    public float launchForce;

    float inclineSpeed = 0.1f;

    public Rigidbody rb;
    float lastInclineSwitchTime = 0;

    void Start()
    {

    }

    void Update()
    {
        if (Time.time - lastInclineSwitchTime > 1f)
        {
            inclineSpeed *= -1;
            lastInclineSwitchTime = Time.time;
        }
        gameObject.transform.Rotate(0, inclineSpeed, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.useGravity = true;
            rb.AddForce(gameObject.transform.forward * launchForce);
        }
    }

   void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Target")
        {
            Destroy(col.gameObject);
        }
      
    }
}
