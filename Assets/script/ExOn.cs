using UnityEngine;
using System.Collections;

public class ExOn : MonoBehaviour {

	public GameObject ex;
	public GameObject closeButton;

	GameObject EquipPanel;

	public void exSetActive(){

		gameObject.GetComponent<HeroInventory> ().enabled = true;
		ex.SetActive (!ex.active);
		closeButton.SetActive (true);
	}

	public void Rdis(){

		HeroInventory r =  GameObject.Find ("Explore").GetComponent<HeroInventory>();
		r.openButton ();
	}
	public void Rdiv(){
		HeroInventory r =  GameObject.Find ("Explore").GetComponent<HeroInventory>();
		r.closeButton ();
	}

	public void ItemPanelOpen(){

		HeroInventory r = GameObject.Find ("Explore").GetComponent<HeroInventory> ();
		r.ItemPanelOpen ();

	}
		
	// Use this for initialization
	void Start () {
		EquipPanel = GameObject.Find ("Equip Panel");
		gameObject.GetComponent<HeroInventory>().enabled = false;
		EquipPanel.SetActive (false);
		ex.active = false;
		closeButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
