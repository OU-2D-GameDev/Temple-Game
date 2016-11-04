using UnityEngine;
using Fungus;
using System.Collections;

public class ItemSelector : MonoBehaviour {

	public int selectedItem = 1;
	public GameObject selectedItemObject;
	public GameObject ActiveTileObject;
	public GameObject SelectorTilesObject;
	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;
	public bool tutorialMode;
	public Flowchart flowchart;

	private SpriteRenderer selectedItemSpriteRenderer;
	private Animator animator;
	private bool active;

	void Start () {
		selectedItemSpriteRenderer = selectedItemObject.GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
	}
	

	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			active = !active;
			if (active)
				animator.Play ("OpenSwitcher");
			else
				animator.Play ("CloseSwitcher");
		}

		if (active) {
			if (Input.GetKeyDown (KeyCode.LeftArrow))
				ChangeItemTo (1);
			else if (Input.GetKeyDown (KeyCode.UpArrow))
				ChangeItemTo (2);
			else if (Input.GetKeyDown (KeyCode.RightArrow))
				ChangeItemTo (3);
			else if (Input.GetKeyDown (KeyCode.DownArrow))
				ChangeItemTo (4);
		}
	}

	public void ChangeItemTo(int item) {
		if (item != selectedItem) {
			selectedItem = item;
			if (item == 1) {
				selectedItemSpriteRenderer.sprite = sprite1;
			} else if (item == 2) {
				selectedItemSpriteRenderer.sprite = sprite2;
			} else if (item == 3) {
				selectedItemSpriteRenderer.sprite = sprite3;
			} else if (item == 4) {
				selectedItemSpriteRenderer.sprite = sprite4;
			}
			animator.Play ("CloseSwitcher");
			active = false;

			if (tutorialMode) {
				flowchart.SendFungusMessage ("p3");
				tutorialMode = false;
			}
		}
	}
}
