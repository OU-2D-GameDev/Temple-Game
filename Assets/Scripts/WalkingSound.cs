using UnityEngine;
using System.Collections;

public class WalkingSound : MonoBehaviour
{



    public GameObject SimpleProtag;
    public AudioClip walkingSound;



    private AudioSource source;



    void Awake()
    {

        source = GetComponent<AudioSource>();

    }


    void Update()
    {

        if (Input.GetAxis("Horizontal") != 0 && !source.isPlaying)

            source.PlayOneShot(walkingSound);
        else if (Input.GetAxis("Horizontal") == 0)
            source.Stop();

    }
}
    