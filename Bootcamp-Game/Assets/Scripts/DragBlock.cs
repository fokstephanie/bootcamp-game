using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragBlock : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private bool dragging = false;
	private Vector3 newPosition;
	private float distance;
	private Vector3 originalPosition;

	public void OnPointerDown(PointerEventData eventData)
	{
		// newPosition = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		dragging = false;
		transform.localPosition = originalPosition;
	}

	// Update is called once per frame
	void Update()
	{
		if (dragging) {
			transform.position = Input.mousePosition;
		} 
	}

	// Use this for initialization
	void Start () {
		originalPosition = transform.localPosition;
	}

}
