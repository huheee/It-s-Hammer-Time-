using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class CraftData : MonoBehaviour,IPointerClickHandler {
	public Item item;
	public Recipe recipe;
	public int amount;
	private CraftTootltip tooltip;
	private CIcraft inv;

	// Use this for initialization
	void Start () {
		inv = GameObject.Find ("Craft").GetComponent<CIcraft> ();
		tooltip = inv.GetComponent<CraftTootltip> ();
	}

	// Update is called once per frame
	void Update () {		
	}

	public void OnPointerClick(PointerEventData eventData)
	{	
		tooltip.Activate(item);
	}
	/*public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.Activate(item);
	}*/
}