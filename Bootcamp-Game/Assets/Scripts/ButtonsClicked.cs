﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsClicked : MonoBehaviour
{
	public GameObject blackScreen;
	public GameObject backToHomePrompt;
	public GameObject settingsPrompt;
	public GameObject changeThemeButton;
	public GameObject regularCanvas;
	public GameObject christmasCanvas;
	private Color32 darkBlue = new Color32(26, 47, 58, 255);

	// Use this for initialization
	void Start ()
	{
		
	}

	private void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void ClickHome()
	{
		backToHomePrompt.SetActive(true);
	}

	public void ClickYes()
	{
		blackScreen.SetActive((true));
		LeanTween.alpha(blackScreen.GetComponent<RectTransform>(), 0, 0);
		
		// Animate blackScreen fade, switch scenes
		LeanTween.alpha(blackScreen.GetComponent<RectTransform>(), 1, 0.8f).setEaseInCubic()
			.setOnComplete(() => LoadScene("Menu"));
	}

	public void ClickNo()
	{
		backToHomePrompt.SetActive(false);
	}

	public void ClickSettings()
	{
		settingsPrompt.SetActive(true);
	}

	public void ClickCloseSettings()
	{
		settingsPrompt.SetActive(false);
	}

	public void ClickChangeTheme()
	{
		blackScreen.SetActive((true));
		LeanTween.alpha(blackScreen.GetComponent<RectTransform>(), 0, 0);
		
		// Animate blackScreen fade, switch scenes
		LeanTween.alpha(blackScreen.GetComponent<RectTransform>(), 1, 0.8f).setEaseInCubic()
			.setOnComplete(SwitchCanvas);
	}

	public void ClickRestart()
	{
		blackScreen.SetActive((true));
		LeanTween.alpha(blackScreen.GetComponent<RectTransform>(), 0, 0);
		
		// Animate blackScreen fade, switch scenes
		LeanTween.alpha(blackScreen.GetComponent<RectTransform>(), 1, 0.8f).setEaseInCubic()
			.setOnComplete(() => LoadScene("Main"));
	}

	private void SwitchCanvas()
	{
		regularCanvas.SetActive(false);
		christmasCanvas.SetActive(true);
	}
}
