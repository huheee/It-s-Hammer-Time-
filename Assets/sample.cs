using UnityEngine;
using System.Collections;

public class sample : MonoBehaviour {


	int indexNumber = 10;

	// Use this for initialization
	void Start () {
		Debug.Log(indexNumber);
	}
	
	void OnMouseDown(){
			Debug.Log("You clicked me");
		}

		void OnMouseUp(){
			Debug.Log("Mouse Up");
		}

	// Update is called once per frame
	void Update () {
		
		
	}
}
