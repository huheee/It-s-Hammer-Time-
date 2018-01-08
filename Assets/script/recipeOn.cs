using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class recipeOn : MonoBehaviour {

	public GameObject menu;
	public GameObject closeButton;

	public void menuSetActive(){

	gameObject.GetComponent<RecipeInventory> ().enabled = true;
	menu.SetActive(!menu.active);
	closeButton.SetActive(true);

	}

	public void Rdis(){
		
		RecipeInventory r =  GameObject.Find ("Recipe").GetComponent<RecipeInventory>();
		r.openButton ();
	}
	public void Rdiv(){
		RecipeInventory r =  GameObject.Find ("Recipe").GetComponent<RecipeInventory>();
		r.closeButton ();
	}

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<RecipeInventory>().enabled = false;
		menu.active = false;
		closeButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
