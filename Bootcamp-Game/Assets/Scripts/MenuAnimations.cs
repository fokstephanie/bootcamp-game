using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.UIElements;
using Button = UnityEngine.UI.Button;

public class MenuAnimations : MonoBehaviour
{

	public GameObject left8;
	public GameObject right8;
	public GameObject blackScreen;
	public GameObject playButton;
	public GameObject playSymbol;

	// Use this for initialization
	void Start () {
		float titleDelay = 0.5f;
		float titleAnimationTime = 1.4f;
		float new8XPosition = 69.5f;
		float fadeTime = 1.1f;
		float buttonFinalPosition = 102;
	
		blackScreen.SetActive((false));
		//playButton.GetComponent<Button>().interactable = false;
		
		// Set initial values
		LeanTween.alpha(left8.GetComponent<RectTransform>(), 0, 0);
		LeanTween.alpha(right8.GetComponent<RectTransform>(), 0, 0);
		LeanTween.alpha(playButton.GetComponent<RectTransform>(), 0, 0);
		LeanTween.alpha(playSymbol.GetComponent<RectTransform>(), 0, 0);
		LeanTween.moveLocalX(left8, 0, 0);
		LeanTween.moveLocalX(right8, 0, 0);
		LeanTween.moveY(playButton, buttonFinalPosition - 80, 0);
		LeanTween.moveLocalY(playSymbol, 170, 0);
		
		// Animate 8's
		// Fade in
		LeanTween.alpha(left8.GetComponent<RectTransform>(), 1, fadeTime).setEaseInQuint();
		LeanTween.alpha(right8.GetComponent<RectTransform>(), 1, fadeTime).setEaseInQuint();
		// Separate
		LeanTween.moveLocalX(left8, -new8XPosition, titleAnimationTime).setDelay(titleDelay + (fadeTime * 0.35f)).setEaseOutQuad();
		LeanTween.moveLocalX(right8, new8XPosition, titleAnimationTime).setDelay(titleDelay + (fadeTime * 0.35f)).setEaseOutQuad();
		
		// Animate-in playButton
		// Fade in
		LeanTween.alpha(playButton.GetComponent<RectTransform>(), 1, 0.8f).setDelay(titleDelay + 0.3f + (fadeTime * 0.35f)).setEaseOutQuad();
		LeanTween.alpha(playSymbol.GetComponent<RectTransform>(), 1, 0.8f).setDelay(titleDelay + 0.3f + (fadeTime * 0.35f)).setEaseOutQuad();
		// Move up
		LeanTween.moveY(playButton, buttonFinalPosition, 0.8f).setDelay(titleDelay + (fadeTime * 0.35f)).setEaseOutQuad();
		LeanTween.moveLocalY(playSymbol, 200, 0.8f).setDelay(titleDelay + (fadeTime * 0.35f)).setEaseOutQuad();
			//.setOnComplete(() => playButton.GetComponent<Button>().interactable = true);
	}
	
	public void Play()
	{
		blackScreen.SetActive((true));
		LeanTween.alpha(blackScreen.GetComponent<RectTransform>(), 0, 0);
		
		// Animate blackScreen fade, switch scenes
		LeanTween.alpha(blackScreen.GetComponent<RectTransform>(), 1, 0.8f).setEaseInCubic()
			.setOnComplete(() => LoadScene("Main"));
		
	}

	private void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
