using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class DungeonChoice : MonoBehaviour {
	public GameObject DWindow;
	public GameObject closeBtn;
	public static int Dnum = 0;
	public GameObject DungeonDes;
	public GameObject DungeonMonster;
	public GameObject DungeonDropItem;
	public GameObject MonsterImg;
	public GameObject Title;

	private GameObject DungeonPanel;
	private List<Dungeon> database = new List<Dungeon>();

	private JsonData DungeonData;


	// Use this for initialization
	IEnumerator Start () {
		

		WWW www = new WWW(Application.streamingAssetsPath + "/Dungeon.json");
		yield return www;
		DungeonData = JsonMapper.ToObject(www.text);




		ConstructDungeonDatabase ();


		DungeonPanel = GameObject.Find ("DContent Panel");
		Debug.Log ("DC complete");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void dungeonOpen1(){
		WindowOpen ();
		Dungeon Ddata = FetchDungeonById (1000);
		Dnum = 1000;
		Debug.Log ("click1");
		DungeonSet (Ddata);

	}

	public void dungeonOpen2(){
		WindowOpen ();
		Dungeon Ddata = FetchDungeonById (1001);
		Dnum = 1001;
		DungeonSet (Ddata);
	}

	public void dungeonOpen3(){
		WindowOpen ();
		Dungeon Ddata = FetchDungeonById (1002);
		Dnum = 1002;
		DungeonSet (Ddata);
	}

	public void dungeonOpen4(){
		WindowOpen ();
		Dungeon Ddata = FetchDungeonById (1003);
		Dnum = 1003;
		DungeonSet (Ddata);
	}

	public void dungeonOpen5(){
		WindowOpen ();
		Dungeon Ddata = FetchDungeonById (1004);
		Dnum = 1004;
		DungeonSet (Ddata);
	}

	public void WindowOpen(){
		DWindow.active = true;
		closeBtn.SetActive (true);
	
	}


	void ConstructDungeonDatabase()
	{
		for (int i = 0; i < DungeonData.Count; i++) 
		{
			
			database.Add (new Dungeon ((int)DungeonData [i]["id"], DungeonData[i]["title"].ToString(), DungeonData[i]["description"].ToString(),
				DungeonData[i]["dropitem"].ToString(),DungeonData[i]["monster"].ToString(), DungeonData[i]["monslug"].ToString()
			));
		}
	}


	public Dungeon FetchDungeonById(int id)
	{
		for (int i = 0; i < database.Count; i++) {	
			if (database [i].ID == id) {
				
				return database [i];
			}
		}
		return null;
	}


	public void DungeonSet(Dungeon data){
		
		Text g = DungeonDes.GetComponent<Text> ();
		Text d = DungeonDropItem.GetComponent<Text> ();
		Text m = DungeonMonster.GetComponent<Text> ();
		Text t = Title.GetComponent<Text> ();



		MonsterImg.GetComponent<Image> ().sprite = data.Sprite;
		g.text = data.description;
		d.text = "획득 가능 아이템 : "+data.dropitem;
		m.text = "출현 몬스터 :  "+data.monster;
		t.text = data.Title;
		
	}



}



public class Dungeon
{
	public int ID { get; set; }
	public string Title { get; set; }
	public string description{ get; set; }
	public string dropitem{ get; set; }
	public string monster{ get; set; }
	public string slug{ get; set; }
	public Sprite Sprite { get; set;}


	public Dungeon(int id, string title, string description,string dropitem,string monster, string monslug)
	{
		this.ID = id;
		this.Title = title;
		this.description = description;
		this.dropitem = dropitem;
		this.monster = monster;
		this.Sprite = Resources.Load<Sprite>("Monster/" + monslug);
	}
		
}