using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class CraftTootltip : MonoBehaviour {
	private Item item;
	private string data;

	private JsonData itemData;

    public GameObject CClot1;
	public GameObject CClot2;
	public GameObject CSlot1;
	public GameObject CSlot2;

	public GameObject AlertTitle;
	public GameObject SuccesTitle;

	int count = 0;
	int recipe_count = 0;
    
	int material_count;
	int craft_item1,craft_item2;

	// Use this for initialization
	IEnumerator Start () {

		WWW www = new WWW(Application.streamingAssetsPath + "/Items.json");
		yield return www;
		itemData = JsonMapper.ToObject(www.text);


		//itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));

		CClot1 = GameObject.Find ("CContent Panel1");
		CClot2 = GameObject.Find ("CContent Panel2");

		CSlot1 = CClot1.transform.Find ("CSlot Panel1").gameObject;
		CSlot2 = CClot2.transform.Find ("CSlot Panel2").gameObject;

	}

	// Update is called once per frame
	void Update () {
	}
		
	public void check_cnt(){
		count = 0;
	
	}


	public void Activate(Item item)
	{
		this.item = item;
		if (count == 0) {
			InsertItem ();
			count++;
		} else if (count == 1) {
			InsertItemTwo ();
			count = 0;
		} 
	}


	/*public void Deactivate()
	{
	}*/

	public void InsertItem()
	{	
		CSlot1.GetComponent<Image> ().sprite = item.Sprite;
		if (craft_item1 != -1) {
			craft_item1 = -1;
		}
		craft_item1 = item.ID;
	}
	public void InsertItemTwo()
	{
		CSlot2.GetComponent<Image> ().sprite = item.Sprite;
		if (craft_item2 != -1) {
			craft_item2 = -1;
		}
		craft_item2 = item.ID;
	}

	public void Craft()
	{	
			
			if (craft_item1 == -1) {
				AlertTitle.SetActive (true);
				Invoke ("AlertActive", 0.8f);
			} else if (craft_item2 == -1) {
				AlertTitle.SetActive (true);
				Invoke ("AlertActive", 0.8f);
			} else {

			CraftStart ();
			Debug.Log (craft_item1);
			craft_item1 = -1;
			craft_item2 = -1;
			}
	}


	void AlertActive(){
		AlertTitle.SetActive (false);
	}
	public void CraftStart()
	{	
		bool flag = true;

		Text msg = SuccesTitle.transform.Find ("Text").gameObject.GetComponent<Text> ();

		for (int i = 0; i < 30; i++) {
			
			if ((int)itemData["recipe"][i]["mate1"] == craft_item1) {
				if ((int)itemData ["recipe"] [i] ["mate2"] == craft_item2) {

					int item1Cnt = PlayerPrefs.GetInt ("item" + craft_item1);

					PlayerPrefs.SetInt ("item" + craft_item1, item1Cnt - 1);

					int item2Cnt = PlayerPrefs.GetInt ("item" + craft_item2);

					PlayerPrefs.SetInt ("item" + craft_item2, item2Cnt - 1);

					i += 51;
					recipe_count = PlayerPrefs.GetInt ("recipe" + i);

					if (recipe_count <= 0) {
						recipe_count = 1;

						PlayerPrefs.SetInt ("recipe" + i, recipe_count);
						i -= 51;
						Debug.Log (PlayerPrefs.GetInt ("item51"));
						Debug.Log (PlayerPrefs.GetInt ("item52"));
						Debug.Log (PlayerPrefs.GetInt ("item53"));

						msg.text = itemData ["recipe"] [i] ["title"].ToString ()+ " 제작완료!";
					}

					else {
						i -= 51;
						int val = (int)itemData ["recipe"] [i] ["value"];
						Debug.Log (val);
						GameObject BP = GameObject.Find ("Background Panel5");
						BP = BP.transform.Find ("Content Panel").gameObject;
						Coin coin = BP.transform.Find ("Coin").gameObject.GetComponent<Coin> ();
						Debug.Log (coin.gold);
						coin.gold += val;

						msg.text = itemData ["recipe"] [i] ["title"].ToString () + "을(를) 팔아서 " + val + "g 획득!";
					}
					Debug.Log ("ok");
					flag = false;
					SuccesTitle.SetActive (true);
					CIcraft r = GameObject.Find ("Craft").GetComponent<CIcraft> ();
					r.closeButton ();
					r.openButton ();
					Invoke ("Succes", 2.0f);

					break;
				} 

			}
		}

		if (flag) {
			msg.text = "맞는 조합이 없습니다.";
			SuccesTitle.SetActive (true);
			Invoke ("Succes", 2.0f);
			craft_item1 = -1;
			craft_item2 = -1;
			CSlot1.GetComponent<Image> ().sprite = Resources.Load<Sprite>("UI Explore/UI_Craft_Panel");
			CSlot2.GetComponent<Image> ().sprite = Resources.Load<Sprite>("UI Explore/UI_Craft_Panel");
		}


	}

	void Succes(){
		SuccesTitle.SetActive (false);
		CSlot1.GetComponent<Image> ().sprite = Resources.Load<Sprite>("UI Explore/UI_Craft_Panel");
		CSlot2.GetComponent<Image> ().sprite = Resources.Load<Sprite>("UI Explore/UI_Craft_Panel");
		if (craft_item1 != -1) {
			craft_item1 = -1;
		}
		if (craft_item2 != -1) {
			craft_item2 = -1;
		}

		Debug.Log (craft_item1);
		Debug.Log (craft_item2);
	}
}
