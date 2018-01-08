using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class RecipeData : MonoBehaviour,IPointerDownHandler, IPointerUpHandler{
	public Recipe recipe;
	public int amount;
	private RecipeTooltip tooltip;
	private RecipeInventory Rinv;

	// Use this for initialization
	void Start () {
		Rinv = GameObject.Find ("Recipe").GetComponent<RecipeInventory> ();
		tooltip = Rinv.GetComponent<RecipeTooltip> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnPointerDown(PointerEventData eventData)
	{	
		tooltip.Activate(recipe);
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		tooltip.Deactivate ();
	}
}