using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HeroInventory : MonoBehaviour 
{
	GameObject inventoryPanel; //인벤토리패널
	GameObject slotPanel; //슬롯패널

	Herodept database;
	Recipedept recipe_database;

	public GameObject inventorySlot; //아이템슬롯 패널
	public GameObject inventoryItem; //아이템패널

	public GameObject DeptPanel;

	public GameObject Weapon;
	public GameObject Defense;

	GameObject itemPanel;
	GameObject itemSlotPanel;

	public GameObject item;
	public GameObject itemSlot;


	public List<Hero> heros = new List<Hero>();
	public List<GameObject> slots = new List<GameObject> ();
	int slotAmount;

	public List<Recipe> recipes = new List<Recipe>();
	public List<GameObject> recipe_slots = new List<GameObject> ();

	public GameObject EquipPanel;

	public List<GameObject> hW = new List<GameObject> ();
	public List<GameObject> hD = new List<GameObject> ();

    public List<GameObject> texture = new List<GameObject>();

	int[] item_count = new int[15];
	int recipe_count;

	void Craft(){
		database = GetComponent<Herodept> ();

		slotAmount = 3;
		inventoryPanel = GameObject.Find ("HContent Panel");//Inventory Panal
		slotPanel = inventoryPanel.transform.Find ("HSlot Panal").gameObject;



		for (int i = 0; i < slotAmount; i++) {
			heros.Add (new Hero ());
			slots.Add (Instantiate (inventorySlot));
			slots [i].transform.SetParent(slotPanel.transform);
		}

		/*
		switch(PlayerPrefs.GetInt("stage"))
		{
		case 1: 
			AddHero (100);
			break;
		case 2: 
			AddHero (100);
			AddHero (101);
			break;
		case 3: 
			AddHero (100);
			AddHero (101);
			AddHero (102);
			break;

		default:
			break;
		}*/
		AddHero (100);
		AddHero (101);
	}



	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Equip", 0);
		//slot에 item database에 있는 id값 기준으로 생성
	}

	// Update is called once per frame
	void Update () {

	}

	public void AddHero(int id)
	{
		Hero heroToAdd = database.FetchHeroById (id);


		for (int i = 0; i < heros.Count; i++) {
			if (heros [i].ID == -1) {
				heros [i] = heroToAdd;
				GameObject heroObj = Instantiate (inventoryItem) as GameObject;
				heroObj.transform.SetParent (slots [i].transform);
				heroObj.GetComponent<Image> ().sprite = heroToAdd.Sprite;


                if(i==0 && PlayerPrefs.GetInt("Hdefault") == 0)
                {
                    PlayerPrefs.SetInt("ManPower",heroToAdd.Power);
                    PlayerPrefs.SetInt("ManDefen", heroToAdd.Defence);
                    PlayerPrefs.SetInt("Hdefault", 1);
                }
                if(i==1 && PlayerPrefs.GetInt("Hdefault") == 1)
                {
                    PlayerPrefs.SetInt("WomanPower", heroToAdd.Power);
                    PlayerPrefs.SetInt("WomanDefen", heroToAdd.Defence);
                    PlayerPrefs.SetInt("Hdefault", 2);
                }


				GameObject heroDept = Instantiate(DeptPanel);
                texture.Add(heroDept);
				heroDept.transform.SetParent (slots [i].transform);
				heroDept.transform.GetChild(0).GetComponent<Text> ().text = heroToAdd.Title;
                if(i == 0)
				    heroDept.transform.GetChild (1).GetComponent<Text> ().text = "power : " + PlayerPrefs.GetInt("ManPower") + "\n" + "defence : " + PlayerPrefs.GetInt("ManDefen") + "\n";
                if(i == 1)
                    heroDept.transform.GetChild(1).GetComponent<Text>().text = "power : " + PlayerPrefs.GetInt("WomanPower") + "\n" + "defence : " + PlayerPrefs.GetInt("WomanDefen") + "\n";

                heroDept.transform.GetChild (2).GetComponent<Text> ().text = heroToAdd.HumanDescription; 
                //itemObj.transform.position = Vector2.zero;

				GameObject heroWeapon = Instantiate (Weapon) as GameObject;
				heroWeapon.GetComponent<HeroData> ().Equip = heroToAdd;
				//heroWeapon.transform.SetParent (slots [i].transform);
				hW.Add(heroWeapon);
				heroWeapon.transform.SetParent(heroObj.transform);

                if (PlayerPrefs.GetString("ManW") != null && i == 0)
                     hW[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("Recipe/" + PlayerPrefs.GetString("ManW"));
                if (PlayerPrefs.GetString("WomW") != null && i == 1)
                    hW[1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Recipe/" + PlayerPrefs.GetString("WomW"));

                GameObject heroDefense = Instantiate (Defense);
				heroDefense.GetComponent<Defence> ().Equip = heroToAdd;
				hD.Add (heroDefense);
				heroDefense.transform.SetParent (slots [i].transform);

                if (PlayerPrefs.GetString("ManD") != null && i == 0)
                    hD[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("Recipe/" + PlayerPrefs.GetString("ManD"));
                if (PlayerPrefs.GetString("WomD") != null && i == 1)
                    hD[1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Recipe/" + PlayerPrefs.GetString("WomD"));


                heroObj.name = heroToAdd.Title;
				heroWeapon.name = heroToAdd.Title + "Weapon";
				heroDefense.name = heroToAdd.Title + "Defense";
				break;
			}
		}
	}
	bool CheckIfHeroIsInInventory(Hero hero)
	{
		for (int i = 0; i < heros.Count; i++)
			if (heros [i].ID == hero.ID)
				return true;

		return false;
	}

	public void openInventory(){
		recipe_database = GetComponent<Recipedept> ();

		slotAmount = 30;
		itemPanel = GameObject.Find ("Item Content Panel");//Inventory Panal
		itemSlotPanel = itemPanel.transform.Find ("Item Slot Panel").gameObject;

		for (int i = 0; i < slotAmount; i++) {
			recipes.Add (new Recipe ());
			recipe_slots.Add (Instantiate (itemSlot));
			recipe_slots [i].transform.SetParent(itemSlotPanel.transform);
		}

		/*for (int i = 0; i < 30; i++) {
			recipe_count = i + 51;

			item_count [i] = PlayerPrefs.GetInt("recipe"+recipe_count);
			for (int j = 1; j <= item_count [i]; j++) {
				AddRecipe(recipe_count);
			}
		}*/
		AddRecipe (51);
		AddRecipe (60);
	}

	public void AddRecipe(int id)
	{
		Recipe recipeToAdd = recipe_database.FetchRecipeById (id);
		if (recipeToAdd.Stackable && CheckIfRecipeIsInInventory (recipeToAdd)) {
			for (int i = 0; i < recipes.Count; i++) {
				if (recipes [i].ID == id) {
					EquipmentData data = slots [i].transform.GetChild(0).GetComponent<EquipmentData> ();
					if (data.amount == 0) {
						data.amount = 1;
					}
					data.amount++;
					data.transform.GetChild(0).GetComponent<Text> ().text = data.amount.ToString ();

					break;
				}
			}
		} 
		else {
			for (int i = 0; i < recipes.Count; i++) {
				if (recipes [i].ID == -1) {
					recipes [i] = recipeToAdd;
					GameObject recipeObj = Instantiate (item);
					recipeObj.GetComponent<EquipmentData>().recipe = recipeToAdd;
					recipeObj.transform.SetParent (recipe_slots [i].transform);
					recipeObj.GetComponent<Image> ().sprite = recipeToAdd.Sprite;
					//itemObj.transform.position = Vector2.zero;
					recipeObj.name = recipeToAdd.Title;
					break;
				}
			}
		}

	}

	bool CheckIfRecipeIsInInventory(Recipe recipe)
	{
		for (int i = 0; i < recipes.Count; i++)
			if (recipes [i].ID == recipe.ID) {
				return true;
			}
		return false;
	}


	public void openButton(){
		Craft ();
	}

	public void ItemPanelOpen()
	{
		EquipPanel = GameObject.Find ("Background Panel Hro");

		PlayerPrefs.SetInt ("Equip", 0);	

		EquipPanel.transform.Find ("Equip Panel").gameObject.SetActive (true);

		openInventory ();
	}

	public void ItemPanelClose()
	{
		recipes.Clear ();
		recipe_slots.Clear ();


		int numE = itemSlotPanel.transform.childCount;

		for (int j = 1; j <= numE; j++) {
			Destroy (itemSlotPanel.transform.GetChild (numE - j).gameObject);
		}
	}

	public void closeButton(){
		heros.Clear ();
		slots.Clear ();
        hW.Clear();
        hD.Clear();
        texture.Clear();


		int numC = slotPanel.transform.childCount;
		for (int i = 1; i <= numC; i++) {
			Destroy (slotPanel.transform.GetChild (numC - i).gameObject);
		}	
	}
		
}
