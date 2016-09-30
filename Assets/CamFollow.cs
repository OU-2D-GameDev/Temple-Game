using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

    // Use this for initialization
    GameObject player;

    void Start () {

        

        player = GameObject.FindWithTag("Player");
	
	}
	
	// This is for you!
	void Update () {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
