using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CraftOn : MonoBehaviour {


	public GameObject menu;
	public GameObject closeButton;

	private GameObject CraftItem1;
	private GameObject CraftItem2;

	public GameObject AlertTitle;
	public GameObject SuccesTitle;

	public void menuSetActive(){
		Debug.Log ("a");
		gameObject.GetComponent<CIcraft>().enabled = true;
		menu.SetActive(!menu.active);
		Debug.Log ("b");
		closeButton.SetActive(true);
		Debug.Log ("c");
		if (menu.active) {
			CraftItem1 = GameObject.Find ("CSlot Panel1");	
			CraftItem1.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("UI Explore/UI_Craft_Panel");
			CraftItem2 = GameObject.Find ("CSlot Panel2");
			CraftItem2.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("UI Explore/UI_Craft_Panel");
		}
		Debug.Log ("d");

	}

	public void Cdis(){

		CIcraft r =  GameObject.Find ("Craft").GetComponent<CIcraft>();
		r.openButton ();
	}
	public void Cdiv(){
		CIcraft r =  GameObject.Find ("Craft").GetComponent<CIcraft>();
		r.closeButton ();
	}




	// Use this for initialization
	void Start () {
		gameObject.GetComponent<CIcraft>().enabled = false;
		menu.active = false;
		closeButton.SetActive(false);
		AlertTitle.SetActive (false);
		SuccesTitle.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

	}
}
