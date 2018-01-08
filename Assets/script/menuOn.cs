using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuOn : MonoBehaviour {


	public GameObject menu;
	public GameObject closeButton;
	public void menuSetActive(){

		gameObject.GetComponent<Inventory>().enabled = true;
		menu.SetActive(!menu.active);

		closeButton.SetActive(true);
	}

	public void Mdis(){

		Inventory r =  GameObject.Find ("Inventory").GetComponent<Inventory>();
		r.openButton ();
	}
	public void Mdiv(){
		Inventory r =  GameObject.Find ("Inventory").GetComponent<Inventory>();
		r.closeButton ();
	}





	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Inventory>().enabled = false;
		menu.active = false;
		closeButton.SetActive(false);
	}




	
	// Update is called once per frame
	void Update () {
	
	}
}
