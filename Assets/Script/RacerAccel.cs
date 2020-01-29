using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerAccel : MonoBehaviour
{
    public IKeypad ikeypad;
    public Rigidbody rb;

    void FixedUpdate()
    {
        if (ikeypad.Accel())
        {
            rb.AddForce(Vector3.forward);
        }
    }

}
