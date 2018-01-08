using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class HeroData : MonoBehaviour,IPointerDownHandler {
	public Hero Equip;

	public int amount;
	private HeroInventory Rinv;

	private Equipment tooltip;
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
		tooltip.WeaActivate (Equip);
	}
}
