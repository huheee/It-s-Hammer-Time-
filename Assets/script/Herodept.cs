using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class Herodept : MonoBehaviour {
	private List<Hero> database = new List<Hero>();

	private JsonData heroData;
	// Use this for initialization
	IEnumerator Start () 
	{
		WWW www = new WWW(Application.streamingAssetsPath + "/Heros.json");
		yield return www;
		heroData = JsonMapper.ToObject(www.text);
       
		//heroData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Heros.json"));
		ConstructHeroDatabase ();
	}

	public Hero FetchHeroById(int id)
	{
		for (int i = 0; i < database.Count; i++) {	
			if(database[i].ID == id)
				return database[i];
		}
		return null;
	}

	void ConstructHeroDatabase()
	{
		for (int i = 0; i < heroData.Count; i++) 
		{
			database.Add (new Hero ((int)heroData [i]["id"], heroData[i]["title"].ToString(), (int)heroData[i]["value"]
				,heroData[i]["slug"].ToString(),(int)heroData[i]["stats"]["power"],(int)heroData[i]["stats"]["defence"],(bool)heroData[i]["stackable"]
				,heroData[i]["description"].ToString()
			));
		}
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
public class Hero
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

	public Hero(int id, string title, int value,string slug,int power,int defence,bool stackable,string description)
	{
		this.ID = id;
		this.Title = title;
		this.Value = value;
		this.Power = power;
		this.Defence = defence;
		this.Stackable = stackable;
		this.HumanDescription = description;
        this.Sprite = Resources.Load<Sprite>("character/" + slug);
	}

	public Hero()
	{
		this.ID = -1;
	}
}