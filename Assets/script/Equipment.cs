using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Equipment : MonoBehaviour {

	private Recipe recipe;
	private string data;
	private GameObject tooltip;

	private Hero Wquip;
    private Hero Dquip;

	GameObject itemPanel;

	HeroInventory h;

	private Vector3 startPoint;

    int count1, count2;
    int MW = 0, WW = 0, MD = 0, WD = 0;
	// Use this for initialization
	void Start () {
		tooltip = GameObject.Find ("ETooltip");

		tooltip.SetActive(false);

	}

	// Update is called once per frame
	void Update () {
		Camera camera = GetComponent<Camera> ();

		if (tooltip.activeSelf) {
			startPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			startPoint.z = 0;
			tooltip.transform.localPosition = startPoint;
		}
	}

    public void WeaActivate(Hero hero)
    {
        this.Wquip = hero;
        count1 = 1;
    }

    public void DfenActivate(Hero hero)
    {
        this.Dquip = hero;
        count1 = 2;
    }


    public void Activate(Recipe recipe)
	{
		this.recipe = recipe;
		tooltip.SetActive (true);
		ConstructIDataString();

        if (count1 == 1)
        InsertWeapon();

        else if(count1 == 2)
        InsertDefen();
    }

   

    public void Deactivate()
	{
		itemPanel = GameObject.Find ("Background Panel Hro");

		tooltip.SetActive (false);
	
		HeroInventory equip = GameObject.Find ("Explore").GetComponent<HeroInventory> ();

		equip.ItemPanelClose ();

		itemPanel.transform.Find ("Equip Panel").gameObject.SetActive (false);

	}

	public void ConstructIDataString()
	{
		data = "<color=#0473f0>" +recipe.HumanDescription + "</color>\n\n";
		tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
		//equip.GetComponent<Image> ().sprite = recipe.Sprite;
	}

	public void InsertWeapon(){
		h = GameObject.Find ("Explore").GetComponent<HeroInventory> ();
        if (Wquip.Title == "Man")
        {
            h.hW[0].GetComponent<Image>().sprite = recipe.Sprite;
            PlayerPrefs.SetString("ManW", recipe.Title);

            if (MW == 0)
            {
                int power = PlayerPrefs.GetInt("ManPower");
                PlayerPrefs.SetInt("ManOPower", power);
                MW = 1;
            }
            PlayerPrefs.SetInt("ManPower", PlayerPrefs.GetInt("ManOPower") + recipe.Power);
            h.texture[0].transform.GetChild(1).GetComponent<Text>().text = "power : " + PlayerPrefs.GetInt("ManPower") + "\n" + "defence : " + PlayerPrefs.GetInt("ManDefen") + "\n";
        }
        else if (Wquip.Title == "Woman")
        {
            h.hW[1].GetComponent<Image>().sprite = recipe.Sprite;
            PlayerPrefs.SetString("WomW", recipe.Title);
            if (WW == 0)
            {
                int power = PlayerPrefs.GetInt("WomanPower");
                PlayerPrefs.SetInt("WomanOPower", power);
                WW = 1;
            }
            PlayerPrefs.SetInt("WomanPower", PlayerPrefs.GetInt("WomanOPower") + recipe.Power);
            h.texture[1].transform.GetChild(1).GetComponent<Text>().text = "power : " + PlayerPrefs.GetInt("WomanPower") + "\n" + "defence : " + PlayerPrefs.GetInt("WomanDefen") + "\n";
        }
	}

    public void InsertDefen()
    {
        h = GameObject.Find("Explore").GetComponent<HeroInventory>();
        if (Dquip.Title == "Man")
        {
            h.hD[0].GetComponent<Image>().sprite = recipe.Sprite;
            PlayerPrefs.SetString("ManD", recipe.Title);
            if (MD == 0)
            {
                int defence = PlayerPrefs.GetInt("ManDefen");
                PlayerPrefs.SetInt("ManODefen", defence);
                MD = 1;
            }
            PlayerPrefs.SetInt("ManDefen", PlayerPrefs.GetInt("ManODefen") + recipe.Power);
            h.texture[0].transform.GetChild(1).GetComponent<Text>().text = "power : " + PlayerPrefs.GetInt("ManPower") + "\n" + "defence : " + PlayerPrefs.GetInt("ManDefen") + "\n";
        }
        else if (Dquip.Title == "Woman")
        {
            h.hD[1].GetComponent<Image>().sprite = recipe.Sprite;
            PlayerPrefs.SetString("WomD", recipe.Title);
            if (WD == 0)
            {
                int defence = PlayerPrefs.GetInt("WomanDefen");
                PlayerPrefs.SetInt("WomanODefen", defence);
                WD = 1;
            }

            PlayerPrefs.SetInt("WomanDefen", PlayerPrefs.GetInt("WomanODefen") + recipe.Power);
            h.texture[1].transform.GetChild(1).GetComponent<Text>().text = "power : " + PlayerPrefs.GetInt("WomanPower") + "\n" + "defence : " + PlayerPrefs.GetInt("WomanDefen") + "\n";
        }
    }
}
