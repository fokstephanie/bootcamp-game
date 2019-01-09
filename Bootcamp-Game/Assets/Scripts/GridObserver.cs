using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridObserver : MonoBehaviour
{
	public static bool[,] gridBoolArray = new bool[8, 8];
	public static GameObject[,] gridColourArray = new GameObject[8, 8];
	public static float squareSize;
	public static Vector4 gridBoundriesExtended;
	public static Vector4 gridBoundriesActual;
	public GameObject grid;
	public Camera mainCam;

	public enum BlockTypes
	{
		zBlock, oBlock, bigOBlock
	}

	public bool[,] zBlockArray = new bool[3, 2]
	{
		{true, false},
		{true, true},
		{false, true}
	};
	
	// Use this for initialization
	void Start ()
	{
		float x = mainCam.WorldToScreenPoint(grid.transform.position).x;
		float y = mainCam.WorldToScreenPoint(grid.transform.position).y;
		Debug.Log("GRID POSITION x: " + x);
		Debug.Log("GRID POSITION y: " + y);
		int rowCount = 0;
		int colCount = 0;
		// Populate gridBoolArray
		for (int i = 0; i < 8; i++) 
		{
			for (int j = 0; j < 0; j++)
			{
				gridBoolArray[i, j] = false;
			}
		} 
		
		// Populate gridColourArray
		foreach (Transform child in transform)
		{
			foreach (Transform childTransform in child)
			{
				gridColourArray[rowCount, colCount] = childTransform.gameObject;
				colCount++;
			}
			colCount = 0;
			rowCount++;
		}

		// squareSize = gridColourArray[0, 0].GetComponent<RectTransform>().rect.width;
		squareSize = 37;
		
		// (left, right, top, bottom)
		gridBoundriesExtended = new Vector4(0, 339, 571, 231);
		gridBoundriesActual = new Vector4(38, 339, 534, 231);

	}

	public static Vector3 getTopLeftBlockCoordinate(Vector3 mousePosition, BlockTypes blockType)
	{
		Vector3 topLeftCoordinate;
		topLeftCoordinate = Vector3.one;
		switch (blockType)
		{
			case BlockTypes.zBlock:
				topLeftCoordinate.x = mousePosition.x - squareSize;
				topLeftCoordinate.y = mousePosition.y + (squareSize * 1.5f);
				topLeftCoordinate.z = mousePosition.z;
				break;
		}
		return topLeftCoordinate;
	}

	public static void BlockSet(BlockTypes blockType, Vector2 topLeftSquareIndex)
	{
		int col = (int)topLeftSquareIndex.x;
		int row = (int)topLeftSquareIndex.y;
		
		switch (blockType)
		{
			case BlockTypes.zBlock:
				gridBoolArray[row, col] = true; 
				gridBoolArray[row + 1, col] = true; 
				gridBoolArray[row + 1, col + 1] = true; 
				gridBoolArray[row + 2, col + 1] = true; 
				
				gridColourArray[row, col].GetComponent<Image>().color = Color.magenta;
				gridColourArray[row + 1, col].GetComponent<Image>().color = Color.magenta;
				gridColourArray[row + 1, col + 1].GetComponent<Image>().color = Color.magenta; 
				gridColourArray[row + 2, col + 1].GetComponent<Image>().color = Color.magenta;
				
				break;
		}
		
		// Check lines that are in rows/cols that the placed block lies in
		CheckLines();
	}

	public static void CheckLines()
	{
		// Checks if a line should be cleared
		int consecutiveHorizontal = 0;
		int consecutiveVertical = 0;

		for (int col = 0; col < 8; col++)
		{
			for (int row = 0; row < 8; row++)
			{
				
			}
		}
	}

	public static bool canBlockFit(Vector2 topLeftSquareIndex, BlockTypes blockType)
	{
		int col = (int)topLeftSquareIndex.x;
		int row = (int)topLeftSquareIndex.y;
		
		switch (blockType)
		{
			case BlockTypes.zBlock:
				return ((col + 1 < 8) && (row + 2 < 8) &&
				        !gridBoolArray[row, col] &&
				        !gridBoolArray[row + 1, col] &&
				        !gridBoolArray[row + 1, col + 1] &&
				        !gridBoolArray[row + 2, col + 1]);
		}

		return false;
	}

	public static bool canDropBlock(Vector3 mousePosition, BlockTypes blockType)
	{
		Vector3 topLeftCoordinate = getTopLeftBlockCoordinate(mousePosition, blockType);
		// Debug.Log("topLeftCoordinate.x: " + topLeftCoordinate.x);
		// Debug.Log("topLeftCoordinate.y: " + topLeftCoordinate.y);
		
		// Check if topLeftCoordinate is within gridBoundriesExtended
		if ((topLeftCoordinate.x >= gridBoundriesExtended.x) && (topLeftCoordinate.x <= gridBoundriesExtended.y) &&
		    (topLeftCoordinate.y <= gridBoundriesExtended.z) && (topLeftCoordinate.y >= gridBoundriesExtended.w))
		{
			Debug.Log("1");
			float xDifference = (topLeftCoordinate.x - gridBoundriesActual.x) / squareSize;
			float yDifference = (gridBoundriesActual.z - topLeftCoordinate.y) / squareSize;
				
			// Find the square its most closely associated with 
			int col = Mathf.FloorToInt(xDifference);
			int row = Mathf.FloorToInt(yDifference);
			Debug.Log("topLeftCoordinate.x: " + topLeftCoordinate.x);
			Debug.Log("topLeftCoordinate.y: " + topLeftCoordinate.y);
			Debug.Log("gridBoundriesActual.x: " + gridBoundriesActual.x);
			Debug.Log("squareSize: " + squareSize);
			Debug.Log("xDifference: " + xDifference);
			Debug.Log("yDifference: " + yDifference);
			Debug.Log("col: " + col);
			Debug.Log("row: " + row);
			
			// Check which quadrant of the square mousePosition is in
			/* 	1	2
				3	4	*/
			float quadrantXDifference = xDifference - col;
			float quadrantYDifference = yDifference - row;
			Vector2 topLeftSquareIndex;

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
			}

			bool canDrop = canBlockFit(topLeftSquareIndex, blockType);

			if (canDrop)
			{
				BlockSet(blockType, topLeftSquareIndex);
			}
			
			
			return canDrop;
		}
		else
		{
			return false; // Not within boundries
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}