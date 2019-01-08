using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridObserver : MonoBehaviour
{
	public bool[,] gridBoolArray = new bool[8, 8];
	public GameObject[,] gridColourArray = new GameObject[8, 8];
	
	// Use this for initialization
	void Start ()
	{
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
				Debug.Log("rowCount: " + rowCount);
				Debug.Log("colCount: " + colCount);
				gridColourArray[rowCount, colCount] = childTransform.gameObject;
				Debug.Log("childImage name: " + childTransform.gameObject.name);
				colCount++;
			}
			colCount = 0;
			rowCount++;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}