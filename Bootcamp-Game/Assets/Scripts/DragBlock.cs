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
	private Vector3 largeSize = new Vector3(1.6f, 1.6f, 1.6f);
	private Vector3 normalSize = Vector3.one;
	[SerializeField]
	private GridObserver observer; /* drag and drop for each */
	public bool spaceFound = false;
	public GridObserver.BlockTypes blockType;

	public void OnPointerDown(PointerEventData eventData)
	{
		// newPosition = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
		transform.localScale = largeSize;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		dragging = false;
		
		// Check where the mouse currently is
		spaceFound = this.observer.canDropBlock(Input.mousePosition, blockType);
		
		if (spaceFound) {
			DestroyObject(gameObject);
		}
		else {
			transform.localPosition = originalPosition;
			transform.localScale = normalSize;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (dragging) {
			transform.position = Input.mousePosition;
			newPosition = transform.position;
		} 
	}

	// Use this for initialization
	void Start () {
		originalPosition = transform.localPosition;
	}

}
