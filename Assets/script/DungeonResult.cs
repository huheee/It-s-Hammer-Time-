using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Threading;

public class DungeonResult : MonoBehaviour {

	public GameObject reImg1;
	public GameObject reImg2;
	public GameObject reImg3;
	public GameObject reImg4;

	public GameObject RWindow;
	public GameObject closeBtn;
	public GameObject Loading;



	public string[] ItemName;





	// Use this for initialization
	void Start () {
		ItemName = new string[13]{"copper_ore","iron_ore","silver_ore","gold_ore","mithril_ore","tera_ore","wood","stone","ruby","sapphire","topaz","diamond","emerald"};
		Debug.Log ("DR complete");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Result0(){

		int item0 = (int)Random.Range (1, 3);
		int item6 = (int)Random.Range (1, 3);
		int item7 = (int)Random.Range (1, 3);



		result_screen (item0, item6,item7, 0, 6,7);

		exp_start.GetRewardEnd(0);

	}

	public void Result1(){

		int item1 = (int)Random.Range (1, 3);
		int item2 = (int)Random.Range (1, 1.5f);
		int item8 = (int)Random.Range (0, 1.5f);
		int item9 = (int)Random.Range (0, 1.3f);

		if(PlayerPrefs.GetInt("stage") == 1)
		{
			PlayerPrefs.SetInt ("stage", 2);
		}
		result_screen (item1,item2,item8,item9,1,2,8,9);
		exp_start.GetRewardEnd(1);

	}

	public void Result2(){
		int item2 = (int)Random.Range (1, 3);
		int item3 = (int)Random.Range (0, 1.3f);
		int item9 = (int)Random.Range (0, 1.7f);
		int item10 = (int)Random.Range (0, 1.3f);
		if(PlayerPrefs.GetInt("stage") == 2)
		{
			PlayerPrefs.SetInt ("stage", 3);
		}

		result_screen (item2,item3,item9,item10,2,3,9,10);

		exp_start.GetRewardEnd(2);

	}


	public void Result3(){


		int item3 = (int)Random.Range (1, 3);
		int item4 = (int)Random.Range (1, 2);
		int item10 = (int)Random.Range (0, 1.7f);
		int item11 = (int)Random.Range (0, 1.3f);




		result_screen (item3,item4,item10,item11,3,4,10,11);

		exp_start.GetRewardEnd(3);



	}

	public void Result4(){

		int item4 = (int)Random.Range (1, 3);
		int item5 = (int)Random.Range (1, 3);
		int item11 = (int)Random.Range (1, 2);
		int item12 = (int)Random.Range (0, 1.7f);


		result_screen (item4,item5,item11,item12,4,5,11,12);


		exp_start.GetRewardEnd(4);



	}








	public void result_screen(int item0, int item1, int iNum0, int iNum1){

		RWindow.active = true;
		closeBtn.SetActive (true);


		if (item0 > 0) {
			reImg1.active = true;
			reImg1.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Item/" + ItemName [iNum0]);
			reImg1.transform.GetChild (0).GetComponent<Text> ().text = item0.ToString ();
		} else {
			reImg1.active = false;
		}
		if (item1 > 0) {
			reImg2.active = true;
			reImg2.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Item/" + ItemName [iNum1]);
			reImg2.transform.GetChild (0).GetComponent<Text> ().text = item1.ToString ();
		} else {
			reImg2.active = false;
		}


		reImg3.active = false;
		reImg4.active = false;



		item0 += PlayerPrefs.GetInt ("item"+iNum0);
		PlayerPrefs.SetInt ("item"+iNum0, item0);
		Debug.Log (ItemName [iNum0]+" : " + item0);



		item1 += PlayerPrefs.GetInt ("item"+iNum1);
		PlayerPrefs.SetInt ("item"+iNum1, item1);
		Debug.Log (ItemName [iNum1]+" : " + item1);




	}

	public void result_screen(int item0, int item1, int item2, int iNum0, int iNum1, int iNum2){

		RWindow.active = true;
		closeBtn.SetActive (true);



		if (item0 > 0) {
			reImg1.active = true;
			reImg1.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Item/" + ItemName [iNum0]);
			reImg1.transform.GetChild (0).GetComponent<Text> ().text = item0.ToString ();
		} else {
			reImg1.active = false;
		}
		if (item1 > 0) {
			reImg2.active = true;
			reImg2.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Item/" + ItemName [iNum1]);
			reImg2.transform.GetChild (0).GetComponent<Text> ().text = item1.ToString ();
		} else {
			reImg2.active = false;
		}

		if (item2 > 0) 
		{	reImg3.active = true;
			reImg3.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Item/" + ItemName [iNum2]);
			reImg3.transform.GetChild (0).GetComponent<Text> ().text = item2.ToString ();
		} else {
			reImg3.active = false;
		}
		reImg4.active = false;



		item0 += PlayerPrefs.GetInt ("item"+iNum0);
		PlayerPrefs.SetInt ("item"+iNum0, item0);
		Debug.Log (ItemName [iNum0]+" : " + item0);



		item1 += PlayerPrefs.GetInt ("item"+iNum1);
		PlayerPrefs.SetInt ("item"+iNum1, item1);
		Debug.Log (ItemName [iNum1]+" : " + item1);



		item2 += PlayerPrefs.GetInt ("item"+iNum2);
		PlayerPrefs.SetInt ("item"+iNum2, item2);
		Debug.Log (ItemName [iNum2]+" : " + item2);





	}

	public void result_screen(int item0, int item1, int item2, int item3, int iNum0, int iNum1, int iNum2, int iNum3){

		RWindow.active = true;
		closeBtn.SetActive (true);

		if (item0 > 0) {
			reImg1.active = true;
			reImg1.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Item/" + ItemName [iNum0]);
			reImg1.transform.GetChild (0).GetComponent<Text> ().text = item0.ToString ();
		} else {
			reImg1.active = false;
		}
		if (item1 > 0) {
			reImg2.active = true;
			reImg2.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Item/" + ItemName [iNum1]);
			reImg2.transform.GetChild (0).GetComponent<Text> ().text = item1.ToString ();
		} else {
			reImg2.active = false;
		}

		if (item2 > 0) {
			reImg3.active = true;
			reImg3.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Item/" + ItemName [iNum2]);
			reImg3.transform.GetChild (0).GetComponent<Text> ().text = item2.ToString ();
		} else {
			reImg3.active = false;
		}

		if (item3 > 0) {
			reImg4.active = true;
			reImg4.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Item/" + ItemName [iNum3]);
			reImg4.transform.GetChild (0).GetComponent<Text> ().text = item3.ToString ();
		} else {
			reImg4.active = false;
		}




		item0 += PlayerPrefs.GetInt ("item"+iNum0);
		PlayerPrefs.SetInt ("item"+iNum0, item0);
		Debug.Log (ItemName [iNum0]+" : " + item0);



		item1 += PlayerPrefs.GetInt ("item"+iNum1);
		PlayerPrefs.SetInt ("item"+iNum1, item1);
		Debug.Log (ItemName [iNum1]+" : " + item1);



		item2 += PlayerPrefs.GetInt ("item"+iNum2);
		PlayerPrefs.SetInt ("item"+iNum2, item2);
		Debug.Log (ItemName [iNum2]+" : " + item2);


		item3 += PlayerPrefs.GetInt ("item"+iNum3);
		PlayerPrefs.SetInt ("item"+iNum3, item3);
		Debug.Log (ItemName [iNum3]+" : " + item3);





	}








}
