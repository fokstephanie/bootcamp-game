using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridAnimation : MonoBehaviour {
	
	public GameObject grid;
	public GameObject[,] gridArray = new GameObject[8, 8];
	public GameObject blackScreen;
	private float fadeTime = 0.8f;
	private float initialDelay = 0.5f;

	// Use this for initialization
	void Start ()
	{
		int rowCount = 0;
		int colCount = 0;
		
		blackScreen.SetActive(true);
		
		// Fade in blackScreen
		LeanTween.alpha(blackScreen.GetComponent<RectTransform>(), 0, fadeTime).setEaseInCubic()
			.setOnComplete(() => blackScreen.SetActive(false));
		
		// Populate gridColourArray
		foreach (Transform child in transform)
		{
			foreach (Transform childTransform in child)
			{
				gridArray[rowCount, colCount] = childTransform.gameObject;
				colCount++;
			}
			colCount = 0;
			rowCount++;
		}

		// Set default size of all squares to 0
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				LeanTween.scale(gridArray[i, j], Vector2.zero, 0);
			}
		}
		
		// Animate-in squares
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				LeanTween.scale(gridArray[i, j], Vector2.one, 0.6f).setDelay((0.08f * (i + j)) + fadeTime).setEaseOutCubic()
					.setOnComplete(EnableColliders);
			}
		}
	}

	private void EnableColliders()
	{
		foreach (GameObject obj in gridArray)
		{
			obj.GetComponent<BoxCollider2D>().enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
