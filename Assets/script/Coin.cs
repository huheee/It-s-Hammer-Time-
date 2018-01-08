using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class Coin : MonoBehaviour {

	public int gold;
	public GameObject seecoin;
	// Use this for initialization
	void Start () {
		gold = PlayerPrefs.GetInt ("coin");
		if (gold == null) {
			gold = 0;
		
		}
	}
	
	// Update is called once per frame
	void Update () {
		Text c = seecoin.GetComponent<Text> ();
		c.text = gold + " g";
		PlayerPrefs.SetInt ("coin",gold);
	}
}
