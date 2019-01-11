using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColourSliderHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public Slider slider;
	public Image background;
	public Image solidBlackBackground;
	public Image gameBackground;
	public Image displayBarBackground;
	public GameObject settingsTitle;
	public GameObject backgroundColourLabel;
	private float sliderValue;
	private Color32 transparent = new Color32(0, 0, 0, 0);
	private Color32 moreTransparentBlack = new Color32(0, 0, 0, 114);
	private Color32 lessTransparentBlack = new Color32(0, 0, 0, 176);
	private Color32 darkBlue = new Color32(26, 47, 58, 255);
	private Color32 greyBlue = new Color32(77, 98, 109, 255);
	private float darkBlueH;
	private float darkBlueS;
	private float darkBlueV;
	private float greyBlueH;
	private float greyBlueS;
	private float greyBlueV;

	// Use this for initialization
	void Start () {
		float H1, S1, V1;
		Color.RGBToHSV(darkBlue, out H1, out S1, out V1);
		darkBlueH = H1;
		darkBlueS = S1;
		darkBlueV = V1;
		
		float H2, S2, V2;
		Color.RGBToHSV(greyBlue, out H2, out S2, out V2);
		greyBlueH = H2;
		greyBlueS = S2;
		greyBlueV = V2;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	public void OnPointerDown(PointerEventData eventData)
	{
		if (gameObject.name != "Settings")
		{
			background.color = transparent;
			solidBlackBackground.color = transparent;
			settingsTitle.SetActive((false));
			backgroundColourLabel.SetActive((false));
		}
	}
	
	public void OnPointerUp(PointerEventData eventData)
	{
		background.color = moreTransparentBlack;
		solidBlackBackground.color = lessTransparentBlack;
		settingsTitle.SetActive((true));
		backgroundColourLabel.SetActive((true));
	}

	public void SettingsColourSlider()
	{
		background.color = transparent;
		solidBlackBackground.color = transparent;
		settingsTitle.SetActive((false));
		backgroundColourLabel.SetActive((false));
		sliderValue = slider.value;
		if (darkBlueH != null)
		{
			gameBackground.color = Color.HSVToRGB((darkBlueH + sliderValue) % 1, darkBlueS, darkBlueV);
			displayBarBackground.color = Color.HSVToRGB((greyBlueH + sliderValue) % 1, greyBlueS, greyBlueV);
		}
	}
}
