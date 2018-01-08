using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RecipeInventory : MonoBehaviour 
{
	GameObject inventoryPanel; //인벤토리패널
	GameObject slotPanel; //슬롯패널
	Recipedept database;
	public GameObject inventorySlot; //아이템슬롯 패널
	public GameObject inventoryItem; //아이템패널

	public List<Recipe> recipes = new List<Recipe>();
	public List<GameObject> slots = new List<GameObject> ();

	int slotAmount;
	int[] item_count = new int[15];
	int recipe_count;

	// Use this for initialization

	void Craft(){
		database = GetComponent<Recipedept> ();

		slotAmount = 30;
		inventoryPanel = GameObject.Find ("RContent Panal");//Inventory Panal
		slotPanel = inventoryPanel.transform.Find ("RSlot Panal").gameObject;

		for (int i = 0; i < slotAmount; i++) {
			recipes.Add (new Recipe ());
			slots.Add (Instantiate (inventorySlot));
			slots [i].transform.SetParent(slotPanel.transform);
		}

		for (int i = 0; i < 30; i++) {
			recipe_count = i + 51;
			item_count [i] = PlayerPrefs.GetInt("recipe"+recipe_count);
			for (int j = 1; j <= item_count [i]; j++) {
				AddRecipe (recipe_count);
			}
		}
	}

	void Start(){
	}



	// Update is called once per frame
	void Update () {
	}

	public void AddRecipe(int id)
	{
		Recipe recipeToAdd = database.FetchRecipeById (id);
		if (recipeToAdd.Stackable && CheckIfRecipeIsInInventory (recipeToAdd)) {
			for (int i = 0; i < recipes.Count; i++) {
				if (recipes [i].ID == id) {
					RecipeData data = slots [i].transform.GetChild(0).GetComponent<RecipeData> ();
					if (data.amount == 0) {
						data.amount = 1;
					}
					Debug.Log (data.amount);
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
					GameObject recipeObj = Instantiate (inventoryItem);
					recipeObj.GetComponent<RecipeData>().recipe = recipeToAdd;
					recipeObj.transform.SetParent (slots [i].transform);
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
	public void closeButton(){
		recipes.Clear ();
		slots.Clear ();

		int numC = slotPanel.transform.childCount;
		for (int i = 1; i <= numC; i++) {
			Destroy (slotPanel.transform.GetChild (numC - i).gameObject);
		}	
	}
}
