using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed = 7;

    private Rigidbody2D playerRigidBody;

    void Start()
    {
		playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
		playerRigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRigidBody.velocity.y);
    }
}