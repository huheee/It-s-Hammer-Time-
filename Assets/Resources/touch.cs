using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class touch : MonoBehaviour {


	Text g;
	int a=1;
	// Use this for initialization
	void Start () {
		
		//g = GetComponent<Text>();
		g = GameObject.FindWithTag("text").GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {

		if( Input.touchCount == 1)
		{
			

			if(Input.GetTouch(0).phase == TouchPhase.Began){
				
				a++;

				
				g.text = ""+a;
				
			
			}
		}

		

	
	}
}
