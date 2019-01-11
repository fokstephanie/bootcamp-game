using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridObserver : MonoBehaviour
{
	public  bool[,] gridBoolArray = new bool[8, 8];
	public  GameObject[,] gridColourArray = new GameObject[8, 8];
	public  float squareSize;
	public GameObject grid;
	public GameObject settingsPrompt;
	public GameObject backToHomePrompt;
	public GameObject carousel;
	private Transform carouselPanel1;
	private Transform carouselPanel2;
	private Transform carouselPanel3;
	public Object zBlock;
	public Object sBlock;
	public Object lBlock;
	public Object reverseLBlock;
	public Object tBlock;
	public Object iBlock;
	public Object flatIBlock;
	public Object smallOBlock;
	public Object oBlock;
	public Object bigOBlock;
	public float raycastSize = 20f;
	private Color32 darkBlue = new Color32(26, 47, 58, 255);
	private float blocksPlaced = 0;

	private Object[] arrayOfBlocks = new Object[10];

	public enum BlockTypes
	{
		zBlock,
		sBlock,
		lBlock,
		reverseLBlock,
		tBlock,
		iBlock,
		flatIBlock,
		smallOBlock,
		oBlock, 
		bigOBlock
	}
	
	private static Hashtable colours = new Hashtable
	{
		{BlockTypes.zBlock, 		new Color32(255, 214, 214, 255)}, // Pink
		{BlockTypes.sBlock, 		new Color32(255, 148, 148, 255)}, // Red
		{BlockTypes.lBlock, 		new Color32(255, 215, 165, 255)}, // Orange
		{BlockTypes.reverseLBlock, 	new Color32(171, 199, 255, 255)}, // Blue
		{BlockTypes.tBlock, 		new Color32(224, 189, 255, 255)}, // Purple
		{BlockTypes.iBlock,			new Color32(171, 236, 255, 255)}, // LightBlue
		{BlockTypes.flatIBlock, 	new Color32(165, 227, 116, 255)}, // Green
		{BlockTypes.smallOBlock, 	new Color32(0, 195, 177, 255)},   // Teal
		{BlockTypes.oBlock, 		new Color32(255, 255, 133, 255)}, // Yellow
		{BlockTypes.bigOBlock,		new Color32(208, 238, 168, 255)}, // LimeGreen
	};

	private Color32 getColour(BlockTypes block)
	{
		return (Color32)colours[block];
	}
	
	/* BLOCK BOOLEAN ARRAYS */
	public bool[,] zBlockArray = new bool[3, 2]
	{
		{true, false},
		{true, true},
		{false, true}
	};

	public bool[,] sBlockArray = new bool[3, 2]
	{
		{ false, true},
		{ true, true },
		{ true, false }
	};

	public bool[,] lBlockArray = new bool[3, 2]
	{
		{true, false},
		{true, false},
		{true, true}
	};

	public bool[,] reverseLBlockArray = new bool[3, 2]
	{
		{true, true},
		{false, true},
		{false, true}
	};

	public bool[,] tBlockArray = new bool[2, 3]
	{
		{true, true, true},
		{false, true, false}
	};

	public bool[,] iBlockArray = new bool[4, 1]
	{
		{true},
		{true},
		{true},
		{true}
	};

	public bool[,] flatIBlockArray = new bool[1, 4]
	{
		{true, true, true, true}
	};

	public bool[,] smallOBlockArray = new bool[1, 1]
	{
		{true}
	};

	public bool[,] oBlockArray = new bool[2, 2]
	{
		{true, true},
		{true, true}
	};

	public bool[,] bigOBlockArray = new bool[3, 3]
	{
		{true, true, true},
		{true, true, true},
		{true, true, true}
	};
	
	// Use this for initialization
	void Start ()
	{
		// Initialize arrayOfBlocks 
		arrayOfBlocks[0] = zBlock;
		arrayOfBlocks[1] = sBlock;
		arrayOfBlocks[2] = lBlock;
		arrayOfBlocks[3] = reverseLBlock;
		arrayOfBlocks[4] = tBlock;
		arrayOfBlocks[5] = iBlock;
		arrayOfBlocks[6] = flatIBlock;
		arrayOfBlocks[7] = smallOBlock;
		arrayOfBlocks[8] = oBlock;
		arrayOfBlocks[9] = bigOBlock;
			
		backToHomePrompt.SetActive(false);
		settingsPrompt.SetActive(false);
		int rowCount = 0;
		int colCount = 0;
		// Populate gridBoolArray
		for (int i = 0; i < 8; i++) 
		{
			for (int j = 0; j < 8; j++)
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
		// gridBoundriesExtended = new Vector4(0, 339, 571, 231);
		// gridBoundriesActual = new Vector4(38, 339, 534, 231);

	}

	public Vector3 getTopLeftBlockCoordinate(Vector3 mousePosition, BlockTypes blockType)
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
			case BlockTypes.sBlock:
				topLeftCoordinate.x = mousePosition.x - squareSize;
				topLeftCoordinate.y = mousePosition.y + (squareSize * 1.5f);
				topLeftCoordinate.z = mousePosition.z;
				break;
			case BlockTypes.lBlock:
				topLeftCoordinate.x = mousePosition.x - squareSize;
				topLeftCoordinate.y = mousePosition.y + (squareSize * 1.5f);
				topLeftCoordinate.z = mousePosition.z;
				break;
			case BlockTypes.reverseLBlock:
				topLeftCoordinate.x = mousePosition.x - squareSize;
				topLeftCoordinate.y = mousePosition.y + (squareSize * 1.5f);
				topLeftCoordinate.z = mousePosition.z;
				break;
			case BlockTypes.tBlock:
				topLeftCoordinate.x = mousePosition.x - (squareSize * 1.5f);
				topLeftCoordinate.y = mousePosition.y + squareSize;
				topLeftCoordinate.z = mousePosition.z;
				break;
			case BlockTypes.iBlock:
				topLeftCoordinate.x = mousePosition.x - (squareSize / 2);
				topLeftCoordinate.y = mousePosition.y + (squareSize * 2);
				topLeftCoordinate.z = mousePosition.z;
				break;
			case BlockTypes.flatIBlock:
				topLeftCoordinate.x = mousePosition.x - (squareSize * 2);
				topLeftCoordinate.y = mousePosition.y + (squareSize / 2);
				topLeftCoordinate.z = mousePosition.z;
				break;
			case BlockTypes.smallOBlock:
				topLeftCoordinate.x = mousePosition.x - (squareSize / 2);
				topLeftCoordinate.y = mousePosition.y + (squareSize / 2);
				topLeftCoordinate.z = mousePosition.z;
				break;
			case BlockTypes.oBlock:
				topLeftCoordinate.x = mousePosition.x - squareSize;
				topLeftCoordinate.y = mousePosition.y + squareSize;
				topLeftCoordinate.z = mousePosition.z;
				break;
			case BlockTypes.bigOBlock:
				topLeftCoordinate.x = mousePosition.x - (squareSize * 1.5f);
				topLeftCoordinate.y = mousePosition.y + (squareSize * 1.5f);
				topLeftCoordinate.z = mousePosition.z;
				break;
			default:
				topLeftCoordinate.x = 0;
				topLeftCoordinate.y = 0;
				topLeftCoordinate.z = 0;
				Debug.LogError("INVALID BLOCKTYPE PASSED TO FUNCTION getTopLeftBlockCoordinate");
				break;
		}
		return topLeftCoordinate;
	}

	private bool[,] findBlockArray(BlockTypes blockType)
	{
		bool[,] blockArray;
		
		switch (blockType)
		{
			case BlockTypes.zBlock:
				blockArray = zBlockArray;
				break;
			case BlockTypes.sBlock:
				blockArray = sBlockArray;
				break;
			case BlockTypes.lBlock:
				blockArray = lBlockArray;
				break;
			case BlockTypes.reverseLBlock:
				blockArray = reverseLBlockArray;
				break;
			case BlockTypes.tBlock:
				blockArray = tBlockArray;
				break;
			case BlockTypes.iBlock:
				blockArray = iBlockArray;
				break;
			case BlockTypes.flatIBlock:
				blockArray = flatIBlockArray;
				break;
			case BlockTypes.smallOBlock:
				blockArray = smallOBlockArray;
				break;
			case BlockTypes.oBlock:
				blockArray = oBlockArray;
				break;
			case BlockTypes.bigOBlock:
				blockArray = bigOBlockArray;
				break;
			default:
				blockArray = null;
				Debug.LogError("NULL BLOCK ARRAY");
				break;
		}

		return blockArray;
	}

	private void GenerateNewBlocks()
	{
		int random1 = Random.Range(0, 10);
		int random2 = Random.Range(0, 10);
		int random3 = Random.Range(0, 10);
		
		Transform[] carouselAllChildren;
		carouselAllChildren = carousel.GetComponentsInChildren<Transform>();
		Transform[] carouselFirstChildren = new Transform[carousel.transform.childCount];
		int index = 0;
		foreach (Transform child in carouselAllChildren)
		{
			if (child.parent == carousel.transform)
			{
				carouselFirstChildren[index] = child;
				index++;
			}
		}
		carouselPanel1 = carouselFirstChildren[0];
		carouselPanel2 = carouselFirstChildren[1];
		carouselPanel3 = carouselFirstChildren[2];
		
		// Get blocks associated with random numbers
		Object randomObj1 = arrayOfBlocks[random1];
		Object randomObj2 = arrayOfBlocks[random2];
		Object randomObj3 = arrayOfBlocks[random3];
		
		// Animate-in carousel 
		Vector3 carouselFinalPosition = carousel.GetComponent<RectTransform>().localPosition;
		LeanTween.moveLocalX(carousel, carouselFinalPosition.x + 650, 0);
		LeanTween.moveLocalX(carousel, carouselFinalPosition.x, 1.4f).setEaseOutQuint().setDelay(0.2f);
		
		Instantiate(randomObj1, carouselPanel1, false);
		Instantiate(randomObj2, carouselPanel2, false);
		Instantiate(randomObj3, carouselPanel3, false);
	}

	private void BlockSet(BlockTypes blockType, Vector2 topLeftSquareIndex)
	{
		int col = (int)topLeftSquareIndex.x;
		int row = (int)topLeftSquareIndex.y;
		Color32 blockColour = getColour(blockType);
		bool[,] blockArray = findBlockArray(blockType);
		
		int arrayRows = blockArray.GetLength(0);
		int arrayCols = blockArray.GetLength(1);
		for (int i = 0; i < arrayRows; i++)
		{
			for (int j = 0; j < arrayCols; j++)
			{
				if (blockArray[i, j])
				{
					gridBoolArray[row + i, col + j] = true;
					gridColourArray[row + i, col + j].GetComponent<Image>().color = blockColour;
				}
			}
		}
		
		// Check lines that are in rows/cols that the placed block lies in
		CheckLines(arrayRows, arrayCols, topLeftSquareIndex);
		blocksPlaced++;
		if (blocksPlaced == 3)
		{
			blocksPlaced = 0;
			GenerateNewBlocks();
		}
	}

	private void SetColours(int row, int col, Color val)
	{
		gridColourArray[row, col].GetComponent<Image>().color = val;
	}

	private void ClearRow(int row)
	{
		for (int i = 0; i < 8; i++)
		{
			gridBoolArray[row, i] = false;
			gridColourArray[row, i].GetComponent<Image>().color = darkBlue;
			LeanTween.value(gridColourArray[row, i], darkBlue, Color.white, 0.9f).setOnUpdateParam(i).setEaseOutQuad()
				.setOnUpdateColor((Color val, object col) => SetColours(row, (int)col, val));
		}
	} 

	private void ClearCol(int col)
	{
		for (int i = 0; i < 8; i++)
		{
			gridBoolArray[i, col] = false;
			gridColourArray[i, col].GetComponent<Image>().color = darkBlue;
			LeanTween.value(gridColourArray[i, col], darkBlue, Color.white, 0.9f).setOnUpdateParam(i).setEaseOutQuad()
				.setOnUpdateColor((Color val, object row) => SetColours((int)row, col, val));
		}
	}

	public  void CheckLines(int numOfRows, int numOfCols, Vector2 topLeftSquareIndex)
	{
		// Checks if a line should be cleared
		int consecutive = 0;

		int startCol = (int)topLeftSquareIndex.x;
		int endCol = startCol + numOfCols;

		int startRow = (int)topLeftSquareIndex.y;
		int endRow = startRow + numOfRows;
	
		// Check rows
		for (int row = startRow; row < endRow; row++)
		{
			for (int col = 0; col < 8; col++)
			{
				if (gridBoolArray[row, col])
				{
					consecutive++;
				}
			}

			if (consecutive == 8)
			{
				ClearRow(row);
			}

			consecutive = 0;
		}
		
		// Check columns
		for (int col = startCol; col < endCol; col++)
		{
			for (int row = 0; row < 8; row++)
			{
				if (gridBoolArray[row, col])
				{
					consecutive++;
				}
			}

			if (consecutive == 8)
			{
				ClearCol(col);
			}

			consecutive = 0;
		}
	}

	public  bool canBlockFit(Vector2 topLeftSquareIndex, BlockTypes blockType)
	{
		int col = (int)topLeftSquareIndex.x;
		int row = (int)topLeftSquareIndex.y;
		bool[,] blockArray = findBlockArray(blockType);
		
		// Check respective blocks on grid to see if they are available
		int arrayRows = blockArray.GetLength(0);
		int arrayCols = blockArray.GetLength(1);
		for (int i = 0; i < arrayRows; i++)
		{
			for (int j = 0; j < arrayCols; j++)
			{
				if (blockArray[i, j])
				{
					if ((row + i >= 8) || (col + j >= 8) || gridBoolArray[row + i, col + j])
					{
						return false;
					}
				}
			}
		}

		return true;
	}

	public  bool canDropBlock(Vector3 mousePosition, BlockTypes blockType)
	{
		Vector3 topLeftCoordinate = getTopLeftBlockCoordinate(mousePosition, blockType);
		
		Vector2 topLeftCoordinatev2 = new Vector2(topLeftCoordinate.x, topLeftCoordinate.y);
		Vector2 topLeftSquareIndex = new Vector2();
		
		var raycastHit = Physics2D.BoxCast(topLeftCoordinatev2, Vector2.one * raycastSize, 0, Vector2.one);
		if (raycastHit.collider != null)
		{
			GameObject selectedCell = raycastHit.collider.gameObject;
			
			// Find index of selectedCell
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (gridColourArray[i, j] == selectedCell)
					{
						topLeftSquareIndex.x = j;
						topLeftSquareIndex.y = i;
						break;
					}
				}
			}

			//int quadrant = (selectedCell.GetComponent<GridCell>().getQuadrant(topLeftCoordinatev2));
			
			bool canDrop = canBlockFit(topLeftSquareIndex, blockType);
	
			
			
			if (canDrop)
			{
				BlockSet(blockType, topLeftSquareIndex);
			}
				
			return canDrop;
		}
		
		/*
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
			
			// Check which quadrant of the square mousePosition is in
				1	2
				3	4	
			float quadrantXDifference = xDifference - col;
			float quadrantYDifference = yDifference - row;
			Vector2 topLeftSquareIndex;

			topLeftSquareIndex = new Vector2((float)col, (float)row);
			
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
			}

			bool canDrop = canBlockFit(topLeftSquareIndex, blockType);

			if (canDrop)
			{
				BlockSet(blockType, topLeftSquareIndex);
			}
			
			
			return canDrop;
		}  */
		else
		{
			return false; // Not within boundries
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}