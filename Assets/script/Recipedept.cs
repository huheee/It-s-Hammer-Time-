using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class Recipedept : MonoBehaviour {
	private List<Recipe> database = new List<Recipe>();

	private JsonData itemData;
	// Use this for initialization
	IEnumerator Start () 
	{
        WWW www = new WWW(Application.streamingAssetsPath + "/Items.json");
        yield return www;
		itemData = JsonMapper.ToObject(www.text);

 		//itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json")); 
		ConstructRecipeDatabase ();
	}

	public Recipe FetchRecipeById(int id)
	{
		for (int i = 0; i < database.Count; i++) {	
			if(database[i].ID == id)
				return database[i];
		}
		return null;
	}

	void ConstructRecipeDatabase()
	{
		for (int i = 0; i < itemData["recipe"].Count; i++) 
		{
			database.Add (new Recipe ((int)itemData ["recipe"][i]["id"], itemData["recipe"][i]["title"].ToString(), (int)itemData["recipe"][i]["value"]
				,itemData["recipe"][i]["slug"].ToString(),(int)itemData["recipe"][i]["stats"]["power"],(int)itemData["recipe"][i]["stats"]["defence"]
                ,itemData["recipe"][i]["description"].ToString(),(bool)itemData["recipe"][i]["stackable"]
			));
		}
	}

	// Update is called once per frame
	void Update () 
	{

	}
}
public class Recipe
{
	public int ID { get; set; }
	public string Title { get; set; }
	public int Value { get; set; }
	public int Power { get; set; }
	public int Defence { get; set; }
	public int Vitallity{ get; set; }
	public string HumanDescription{ get; set; }
	public bool Stackable{ get; set;}
	public int Rartiy{ get; set; }
	public string Slug{ get; set; }
	public Sprite Sprite { get; set;}

	public Recipe(int id, string title, int value,string slug,int power,int defence, string description,bool stackable)
	{
		this.ID = id;
		this.Title = title;
		this.Value = value;
		this.Stackable = stackable;
		this.HumanDescription = description;
        this.Power = power;
        this.Defence = defence;
		this.Sprite = Resources.Load<Sprite> ("Recipe/" + slug); //path = 'jar:file://' + Application.dataPath + "!/assets/" + 파일경로;
	}

	public Recipe()
	{
		this.ID = -1;
	}
}
