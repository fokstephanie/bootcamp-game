using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GridCell : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

	public Image cell;
	
	// Use this for initialization
	void Start () {
		
	}
	
	public void OnPointerUp(PointerEventData eventData)
	{
		this.cell.color = Color.blue;
	}
	
	public void OnPointerDown(PointerEventData eventData)
	{
		this.cell.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
