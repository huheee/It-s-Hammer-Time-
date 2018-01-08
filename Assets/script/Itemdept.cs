using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class Itemdept : MonoBehaviour {
	private List<Item> database = new List<Item>();

	private JsonData itemData;
	// Use this for initialization

	IEnumerator Start () 
	{
        WWW www = new WWW(Application.streamingAssetsPath + "/Items.json");
        yield return www;
		itemData = JsonMapper.ToObject(www.text);
		Debug.Log (itemData["material"].Count );
		//itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json")); 

        
		ConstructItemDatabase ();
	}

	public Item FetchItemById(int id)
	{
		for (int i = 0; i < database.Count; i++) {	
			if(database[i].ID == id)
				return database[i];
		}
		return null;
	}

	void ConstructItemDatabase()
	{
		Debug.Log ("db con");
		for (int i = 0; i < itemData["material"].Count; i++) 
		{
			database.Add (new Item ((int)itemData ["material"][i]["id"], itemData["material"][i]["title"].ToString(),itemData["material"][i]["slug"].ToString(),(bool)itemData["material"][i]["stackable"]));
			Debug.Log ("db id :"+database[i].Title+"     cnt :  "+i+"   datacount     "+itemData["material"].Count);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
public class Item
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

	public Item(int id, string title,string slug,bool stackable)
	{
		this.ID = id;
		this.Title = title;

		this.Stackable = stackable;
		this.Sprite = Resources.Load<Sprite> ("Item/" + slug); //path = 'jar:file://' + Application.dataPath + "!/assets/" + 파일경로;
    }

	public Item()
	{
		this.ID = -1;
	}
}
