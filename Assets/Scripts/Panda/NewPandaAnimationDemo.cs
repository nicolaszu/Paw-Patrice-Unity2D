using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPandaAnimationDemo : MonoBehaviour
{
    public float speed;
    public GameObject face;

    Animator anim;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", rb.velocity.x);

        if (Input.GetKeyDown("a"))
        {
            rb.velocity = Vector2.left * speed;
            face.GetComponent<Animator>().SetBool("Walking", true);
        }

        if (Input.GetKeyUp("a"))
        {
            rb.velocity = new Vector2(0, 0);
            face.GetComponent<Animator>().SetBool("Walking", false);
        }

        if (Input.GetKeyDown("d"))
        {
            rb.velocity = Vector2.right * speed;
            face.GetComponent<Animator>().SetBool("Walking", true);
        }

        if (Input.GetKeyUp("d"))
        {
            rb.velocity = new Vector2(0, 0);
            face.GetComponent<Animator>().SetBool("Walking", false);
        }

        if (Input.GetKey("w"))
            face.GetComponent<Animator>().SetBool("Happy", true);

        if (Input.GetKey("s"))
            face.GetComponent<Animator>().SetBool("Happy", false);

        if (Input.GetKeyDown("q")) {
            anim.SetBool("IsWaving", true);
        }

        if (Input.GetKeyUp("q")) {
            anim.SetBool("IsWaving", false);
        }
    }
}
