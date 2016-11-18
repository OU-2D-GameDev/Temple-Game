using UnityEngine;
using System.Collections;

public class TutorialController : MonoBehaviour {

	public GameObject playerObject;
	public EdgeCollider2D stageBlocker;
	public EdgeCollider2D voidCollider;

	void Update() {
		if (voidCollider.IsTouching (playerObject.GetComponent<Collider2D>())) {
			playerObject.transform.position = new Vector3 (-7.31f, -1.45f, 0f);
		}
	}

	public void RemoveStageBlocker() {
		stageBlocker.enabled = false;
	}

}
