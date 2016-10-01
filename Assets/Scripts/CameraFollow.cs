using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private GameObject player;

    void Start ()
	{
        player = GameObject.FindWithTag("Player");
	}

	void Update ()
	{
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}