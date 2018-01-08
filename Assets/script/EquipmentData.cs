using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class EquipmentData : MonoBehaviour,IPointerDownHandler, IPointerExitHandler{
	public Recipe recipe;
	public int amount;
	private Equipment tooltip;
	private HeroInventory Rinv;

	// Use this for initialization
	void Start () {
		Rinv = GameObject.Find ("Explore").GetComponent<HeroInventory> ();
		tooltip = Rinv.GetComponent<Equipment> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnPointerDown(PointerEventData eventData)
	{	
		tooltip.Activate(recipe);
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.Deactivate ();
	}
}