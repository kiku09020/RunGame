using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 200;

    //--------------------------------------------------

    void Awake()
    {
        
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var vec = new Vector3(x, 0, z);

        rb.AddForce(vec * speed);
        print(vec);
    }
}
