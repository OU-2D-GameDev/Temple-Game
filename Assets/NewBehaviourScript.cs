using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D simpleprotag;

    private Rigidbody2D crouchedprotag;

    [SerializeField]
    private float speed;
    private bool crouched;
    private Rigidbody2D animationcrouchedprotag;

    // Use this for initialization
    void Start()
    {
        simpleprotag = GetComponent<Rigidbody2D>();

        

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);

        speed = 7;

        if (Input.GetKeyDown(KeyCode.S))
        {
            crouchedprotag = GetComponent<Rigidbody2D>();

            animationcrouchedprotag = GetComponent<Rigidbody2D>();
        }


    }

    private void HandleMovement(float horizontal)
    {
        simpleprotag.velocity = new Vector2(horizontal * speed, simpleprotag.velocity.y);

    }

   

    }

