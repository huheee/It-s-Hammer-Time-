using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ItemData : MonoBehaviour,IPointerDownHandler,IPointerExitHandler{
	public Item item;
	public int amount;
	private ItemTooltip tooltip;
	private Inventory inv;

	// Use this for initialization
	void Start () {
		inv = GameObject.Find ("Inventory").GetComponent<Inventory> ();
		tooltip = inv.GetComponent<ItemTooltip> ();
	}
	
	// Update is called once per frame
	void Update () {		
	}

	public void OnPointerDown(PointerEventData eventData)
	{	
		tooltip.Activate(item);
	}
	/*public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.Activate(item);
	}*/
	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.Deactivate ();
	}
}
