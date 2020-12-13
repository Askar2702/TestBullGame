using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    void Start()
    {
        Destroy(this.gameObject, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + -transform.right * speed * Time.fixedDeltaTime);
    }
}
