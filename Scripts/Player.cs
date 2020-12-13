using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public event Action Death;
    private bool isVector;
    private float vectorY;
    void Start()
    {
        vectorY = -10f;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isVector)
            {
                vectorY = 10f;
            }
            else
            {
                vectorY = -10f;
            }
        }
        rb.velocity = new Vector3(0f, vectorY, 0f);
        transform.position = new Vector3(-6f, transform.position.y, 0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Platform") isVector = false;

        else if (collision.transform.tag == "PlatformBottom") isVector = true;
        else if (collision.transform.tag == "Lose") Death.Invoke();
    }
}
