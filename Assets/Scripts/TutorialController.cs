using UnityEngine;
using System.Collections;

public class TutorialController : MonoBehaviour {

	public EdgeCollider2D stageBlocker;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RemoveStageBlocker() {
		stageBlocker.enabled = false;
	}
}
