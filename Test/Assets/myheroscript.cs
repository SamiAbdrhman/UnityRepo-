using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myheroscript : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("is running", false);

        if (Input.GetKey(KeyCode.W))
       {

            transform.position += transform.forward * Time.deltaTime;
            animator.SetBool("is running", true);

        }

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up, 120 * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            transform.position -= transform.forward * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.down,120*Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
            transform.position += Vector3.left * Time.deltaTime;

        if (Input.GetKey(KeyCode.E))
            transform.position += Vector3.right * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject);
        
       
        footballscript myFootball = collision.gameObject.GetComponent<footballscript>();
        if ( myFootball != null) 
        {
            myFootball.Kick();
        }



    }
}
