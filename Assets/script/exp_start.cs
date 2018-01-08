using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Threading;


public class exp_start : MonoBehaviour {
	public static bool[] Fcheck = new bool[5]{false, false, false, false, false}; 
	public static bool[] Rcheck = new bool[5]{false, false, false, false, false}; 

	public static int[] Ftime = new int[5]{0 , 0, 0, 0, 0 };
	public static int[] Ftimeset = new int[5]{0 , 0, 0, 0, 0 };


	// Use this for initialization
	void Start () {
		for (int i = 0; i < 5; i++) {

			GameObject FImage = GameObject.Find ("fighting"+i);
			FImage.SetActive (Fcheck [i]);
			GameObject btnOj = GameObject.Find ("stage"+i);

			Button btn = btnOj.GetComponent<Button>();
			btn.enabled = !Fcheck [i];

			GameObject rewardBtn = GameObject.Find ("stageReward"+i);
			rewardBtn.SetActive (Rcheck[i]);


		}




	
		Debug.Log ("start");
		int nowM = System.DateTime.Now.Minute;
		int nowS = System.DateTime.Now.Second;
		int now = (nowM * 60) + nowS;
		Debug.Log ("now : "+nowM+" S : "+nowS);
		Debug.Log ("now : " + now);


		for (int i = 0; i < 5; i++) {


			if (Ftime [i] != 0) {
				Debug.Log ("Ftime : "+Ftime[i]);


				Ftimeset [i] = now;
				StartCoroutine( SetFightingEnd (i));



			}
		}

		Debug.Log ("es complete");



	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void exp(){
		
		StartCoroutine ("playD");
	}


	/*IEnumerator Loading_scr(){
		
		if (fades < 0.0f) {
			Loading.active = false;
			StopCoroutine ("Loading_scr");
		}

		fades -= 0.2f;
		Loading.GetComponent<Image> ().color = new Color (0, 0, 0, fades);

		yield return new WaitForSeconds (0.2f);


		StartCoroutine ("Loading_scr");
	}

*/




	IEnumerator playD(){

		int num = DungeonChoice.Dnum;
		yield return new WaitForSeconds (0.1f);

		Debug.Log ("Dungeon : "+num);


		if (num == 1000) {
			
			//Loading.active = true;
			//StartCoroutine ("Loading_scr");


			num -= 1000;
			SetFightingVisable(num);

			Debug.Log ("fight visable");


			StartCoroutine(SetFightingEnd(num));

		}


		else if (num == 1001) {


			//Loading.active = true;
			//StartCoroutine ("Loading_scr");

			num -= 1000;
			SetFightingVisable(num);
			StartCoroutine(SetFightingEnd(num));


		}


		else if (num == 1002) {


			num -= 1000;
			SetFightingVisable(num);
			StartCoroutine(SetFightingEnd(num));





		}



		else if (num == 1003) {
			

			//Loading.active = true;
			//StartCoroutine ("Loading_scr");

			num -= 1000;
			SetFightingVisable(num);
			StartCoroutine(SetFightingEnd(num));




		} 
		else if (num == 1004) {


			//fades = 3.0f;


			//Loading.active = true;
			//StartCoroutine ("Loading_scr");

			num -= 1000;
			SetFightingVisable(num);
			StartCoroutine(SetFightingEnd(num));


		}


		else {
			Debug.Log ("error");
		}



	}

	public IEnumerator SetFightingEnd(int i){

		yield return new WaitForSeconds (1.0f);
		Ftimeset[i] =  Ftimeset[i] + 1;
		Debug.Log (Ftime [i]);
		Debug.Log (Ftimeset[i]);
		if (Ftimeset[i] > Ftime [i]+5) {
			Fcheck [i] = false;
			GameObject mainStage = GameObject.Find ("stage-re");


			GameObject FImage = mainStage.transform.Find ("fighting" + i).gameObject;
			FImage.SetActive (Fcheck [i]);
			GameObject btnOj = mainStage.transform.Find ("stage" + i).gameObject;

			GameObject rewardBtn = mainStage.transform.Find ("stageReward" + i).gameObject;
			Rcheck [i] = !Fcheck [i];
			Ftime [i] = 0;

			rewardBtn.SetActive (Rcheck [i]);

			StopCoroutine (SetFightingEnd(i));
		} else {

			StartCoroutine (SetFightingEnd(i));
		}
	}


	public void SetFightingVisable(int i){

		Fcheck [i] = true;


		GameObject mainStage = GameObject.Find ("stage-re");

		GameObject FImage = mainStage.transform.Find ("fighting"+i).gameObject; 

		FImage.SetActive (Fcheck[i]);

		GameObject btnOj = mainStage.transform.Find ("stage"+i).gameObject;
		Button btn = btnOj.GetComponent<Button>();
		btn.enabled = !Fcheck [i];


		Ftime [i] = (System.DateTime.Now.Minute * 60) + System.DateTime.Now.Second;
		Ftimeset[i] = Ftime [i];

		Debug.Log ("stage"+i);

	}



	public static void GetRewardEnd(int i){

		Rcheck [i] = false;

		GameObject mainStage = GameObject.Find ("stage-re");

		GameObject btnOj = mainStage.transform.Find ("stage"+i).gameObject;
		Button btn = btnOj.GetComponent<Button>();
		btnOj.SetActive (!Rcheck[i]);
		btn.enabled = !Rcheck[i];
		GameObject rewardBtn =mainStage.transform.Find ("stageReward"+i).gameObject;
		rewardBtn.SetActive (Rcheck[i]);


	}



}
