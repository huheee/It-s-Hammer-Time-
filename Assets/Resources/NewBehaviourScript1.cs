using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NewBehaviourScript1 : MonoBehaviour {
		Text g;
		int a=1;
	// Use this for initialization
	void Start () {
		g = GameObject.FindWithTag("text").GetComponent<Text>();
		g.text = "하이";
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.touchCount == 1)
		{
			

			if(Input.GetTouch(0).phase == TouchPhase.Began){
				g.text = "박스"+a;
					a++;
			}
				
				
		}


	}

}
