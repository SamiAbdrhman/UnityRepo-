using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class myheroscript : MonoBehaviour
{
    public GameObject snowBallCloneTemplate;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            print("Could not find Animator Component");
        else
            print("Animator Component found");
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("is running", false);

        if (Input.GetMouseButtonDown(0))

        {
            GameObject newSnowballGo = Instantiate(snowBallCloneTemplate, transform.position + transform.forward + Vector3.up, Quaternion.identity);
            SnowballScript myNewSnowball = newSnowballGo.GetComponent<SnowballScript>();
            myNewSnowball.throwSnowball(transform);
        }


            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * Time.deltaTime;
                animator.SetBool("isRunning", true);
            }
            {
                if (Input.GetKey(KeyCode.A))
                    transform.Rotate(Vector3.up, -30 * Time.deltaTime);

                if (Input.GetKey(KeyCode.S))
                    transform.position -= transform.forward * Time.deltaTime;

                if (Input.GetKey(KeyCode.D))
                    transform.Rotate(Vector3.down, 30 * Time.deltaTime);

                if (Input.GetKey(KeyCode.Q))
                    transform.position += Vector3.left * Time.deltaTime;

                if (Input.GetKey(KeyCode.E))
                    transform.position += Vector3.right * Time.deltaTime;
            }
            void OnCollisionEnter(Collision collision)
            {
                print(collision.gameObject);


                footballscript myFootball = collision.gameObject.GetComponent<footballscript>();
                if (myFootball != null)
                {
                    myFootball.Kick();
                }



            }
        }
    }

