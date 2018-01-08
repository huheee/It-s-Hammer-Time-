using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;


public class ChatEvent : MonoBehaviour {


	public GameObject BC_panel;
	GameObject chat_panel;

	GameObject CText;
	Text CName;


	// Use this for initialization
	void Start () {
		chat_panel = BC_panel.transform.Find ("Chat Panal").gameObject;
		CText = chat_panel.transform.Find ("ChatText").gameObject;
		CName = chat_panel.transform.Find ("ChatName").gameObject.transform.Find("Text").gameObject.GetComponent<Text>();
		BC_panel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void opening(){
		BC_panel.SetActive (true);

		BC_panel.SetActive (false);
	}

	public void first_com(){
		BC_panel.SetActive (true);

		BC_panel.SetActive (false);

	}

	public void second_com(){
		BC_panel.SetActive (true);

		BC_panel.SetActive (false);
	}

	public void third_com(){
		BC_panel.SetActive (true);

		BC_panel.SetActive (false);
	}


	public void ending(){
		BC_panel.SetActive (true);

		BC_panel.SetActive (false);

	}



}
