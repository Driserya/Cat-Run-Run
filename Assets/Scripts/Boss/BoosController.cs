using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BoosController : MonoBehaviour
{
    public GameObject Cat;

    public GameObject Grounds;

    public GameObject UI;

    private Rigidbody2D rb;

    public float speed;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(Cat.transform.position.x+12, transform.position.y);
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "UpRoom"||other.name==("DownRoom"))
        {
            speed *= -1;
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(rb.velocity.x,speed * Time.deltaTime);
    }

}
