using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RecipeTooltip : MonoBehaviour {

	private Recipe recipe;
	private string data;
	private GameObject tooltip;

	private Vector3 startPoint;
	// Use this for initialization
	void Start () {
		tooltip = GameObject.Find ("RTooltip");
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

	public void Activate(Recipe recipe)
	{
		this.recipe = recipe;
		tooltip.SetActive (true);
		ConstructIDataString();
	}


	public void Deactivate()
	{
		tooltip.SetActive (false);
	}

	public void ConstructIDataString()
	{
		data = "<color=#0473f0>" +recipe.HumanDescription + "</color>\n\n";
		tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
	}

}
