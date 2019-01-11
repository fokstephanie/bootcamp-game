using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GridCell : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	public BoxCollider2D collider;
	public Image cell;
	public Transform startingPoint;
	
	// Use this for initialization
	void Start () {
		
	}
	
	public void OnPointerUp(PointerEventData eventData)
	{
		/*
		// this.cell.color = Color.blue;
		Vector2 newMousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		var raycastHit = Physics2D.BoxCast(newMousePosition, Vector2.one * 20, 0, Vector2.one);
		if (raycastHit.collider.transform == this.transform)
		{
			this.cell.color = Color.blue;
		}
		*/
	}

	public int getQuadrant(Vector2 position)
	{
		Debug.Log("getQuadrant");
		float squareSize = collider.size.x;
		float xDifference = (position.x - startingPoint.position.x) / squareSize;
		float yDifference = (startingPoint.position.y - position.y) / squareSize;
				
		// Find the square its most closely associated with 
		int col = Mathf.FloorToInt(xDifference);
		int row = Mathf.FloorToInt(yDifference);
			
		// Check which quadrant of the square mousePosition is in
		/*  1	2
			3	4	*/
		// float quadrantXDifference = xDifference - col;
		// float quadrantYDifference = yDifference - row;
		Vector2 topLeftSquareIndex;

		topLeftSquareIndex = new Vector2((float)col, (float)row);

		return -1;

		/*
		if (quadrantXDifference <= 0.5f)
		{
			Debug.Log("2");
			// Lies in left quadrant
			if (quadrantYDifference <= 0.5f)
			{
				// Lies in top left quadrant
				topLeftSquareIndex = new Vector2((float)col, (float)row);
			}
			else
			{
				// Lies in bottom left quadrant
				topLeftSquareIndex = new Vector2((float)col, (float)(row + 1));
			}
		}
		else
		{
			Debug.Log("3");
			// Lies in right quadrant
			if (quadrantYDifference <= 0.5f)
			{
				// Lies in top right quadrant
				topLeftSquareIndex = new Vector2((float)(col + 1), (float)row);
			}
			else
			{
				// Lies in bottom right quadrant
				topLeftSquareIndex = new Vector2((float)(col + 1), (float)(row + 1));
			}
		}*/
	}
		
	public void OnPointerDown(PointerEventData eventData)
	{
		// this.cell.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
