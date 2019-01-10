using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour, IPointerClickHandler  {
	
	public GameObject blackScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("PLAY BUTTON HIT");
		blackScreen.SetActive((true));
		LeanTween.alpha(blackScreen.GetComponent<RectTransform>(), 0, 0);
		
		// Animate blackScreen fade, switch scenes
		LeanTween.alpha(blackScreen.GetComponent<RectTransform>(), 1, 0.8f).setEaseInCubic()
			.setOnComplete(LoadScene);
		
	}

	private void LoadScene()
	{
		blackScreen.SetActive(false);
		SceneManager.LoadScene("Main");
		
	}
}
