using UnityEngine;
using System.Collections;

public class FirstStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.SetResolution(Screen.width, Screen.width *2 / 3, true);
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("stage") == 0)
		{
			PlayerPrefs.SetInt("stage",1);
		}

		if (Input.GetMouseButton (0))
			Application.LoadLevel ("wqer1");
	
		
		/*if (Input.touchCount > 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Began)
				Application.LoadLevel ("wqer1");
		}*/
	}
}
