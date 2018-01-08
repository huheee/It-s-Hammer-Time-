using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CIcraft : MonoBehaviour 
{
	GameObject inventoryPanel; //인벤토리패널
	GameObject slotPanel; //슬롯패널

	Itemdept database;

	public GameObject inventorySlot; //아이템슬롯 패널
	public GameObject inventoryItem; //아이템패널


	public List<Item> items = new List<Item>();

	public List<GameObject> slots = new List<GameObject> ();
	int slotAmount;

	int[] item_count = new int[15];

	// Use this for initialization
	void Start () {
		
		//slot에 item database에 있는 id값 기준으로 생성
	}

	// Update is called once per frame
	void Update () {

	}

	void Craft(){
		database = GetComponent<Itemdept> ();
		slotAmount = 70;
		inventoryPanel = GameObject.Find ("CIContent Panel");//Inventory Panal
		slotPanel = inventoryPanel.transform.Find ("CISlot Panel").gameObject;



		for (int i = 0; i < slotAmount; i++) {
			items.Add (new Item ());
			slots.Add (Instantiate (inventorySlot));
			slots [i].transform.SetParent(slotPanel.transform);
		}

		for (int i = 0; i < 11; i++) {
			item_count [i] = PlayerPrefs.GetInt("item"+i);
			for (int j = 0; j < item_count [i]; j++) {
				AddItem (i);
			}
		}

	}



	public void AddItem(int id)
	{
		Item itemToAdd = database.FetchItemById (id);
	
		if (itemToAdd.Stackable && CheckIfItemIsInInventory (itemToAdd)) {
			for (int i = 0; i < items.Count; i++) {
				if (items [i].ID == id) {
					CraftData data = slots [i].transform.GetChild (0).GetComponent<CraftData> ();
					if (data.amount == 0) {
						data.amount = 1;
					}
					data.amount++;
					data.transform.GetChild (0).GetComponent<Text> ().text = data.amount.ToString ();
					break;
				}
			}
		} 
		else {
			for (int i = 0; i < items.Count; i++) {
				if (items [i].ID == -1) {
					items [i] = itemToAdd;

					GameObject itemObj = Instantiate (inventoryItem);
					itemObj.GetComponent<CraftData>().item = itemToAdd; // Itemdata 
					itemObj.transform.SetParent (slots [i].transform);
					itemObj.GetComponent<Image> ().sprite = itemToAdd.Sprite;
					//itemObj.transform.position = Vector2.zero;
					itemObj.name = itemToAdd.Title;
					break;
				}
			}
		}
	}
		
	bool CheckIfItemIsInInventory(Item item)
	{
		for (int i = 0; i < items.Count; i++)
			if (items [i].ID == item.ID)
				return true;

		return false;
	}

	public void openButton(){
		Craft ();
	}


	public void closeButton(){
		items.Clear ();
		slots.Clear ();
		Debug.Log ("close craft");
		int numC = slotPanel.transform.childCount;
		for (int i = 1; i <= numC; i++) {
			Destroy (slotPanel.transform.GetChild (numC - i).gameObject);
		}	
	}




}
