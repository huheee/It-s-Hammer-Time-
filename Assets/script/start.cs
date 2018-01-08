using UnityEngine;
using System.Collections;

public class start : MonoBehaviour {

	// Use this for initialization
	void Start () {
		 Screen.SetResolution(Screen.width, Screen.width *2 / 3, true);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Application.Quit();
        }
	}
}
