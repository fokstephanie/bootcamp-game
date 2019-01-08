﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragBlock : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private bool dragging = false;
	private Vector3 newPosition;
	public Vector3 originalPosition;

	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log("OnPointerDown");
		// newPosition = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		Debug.Log("OnPointerUp");
		dragging = false;
		transform.localPosition = originalPosition;
	}

	public void OnDrag() {
	
	}

	// Update is called once per frame
	void Update()
	{
		if (dragging) {
			// Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			// Vector3 rayPoint = ray.GetPoint (distance);
			// transform.position = rayPoint;
			transform.localPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		} 
	}

	// Use this for initialization
	void Start () {
		Debug.Log("Start");
		originalPosition = transform.localPosition;
		Debug.Log("originalPosition = " + originalPosition);
	}

}
