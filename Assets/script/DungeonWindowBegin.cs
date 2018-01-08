using UnityEngine;
using System.Collections;

public class DungeonWindowBegin : MonoBehaviour {


	public GameObject DWindow;
	public GameObject closeBtn;
	public GameObject RWindow;
	public GameObject closeBtnR;



	// Use this for initialization
	void Start () {
		DWindow.active = false;
		closeBtn.SetActive (false);
		RWindow.active = false;
		closeBtnR.SetActive (false);
		Debug.Log ("DW complete");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void offDWindow(){
		DWindow.active = false;
		closeBtn.SetActive (false);
		}
	public void offRWindow(){
		RWindow.active = false;
		closeBtnR.SetActive (false);


	}
}
