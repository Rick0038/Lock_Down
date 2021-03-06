using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public Slider slider;												// to select the slider component
	public Gradient gradient;											// to select grediant colour if present
	public Image fill;													// to fill the inside

	public void SetMaxHealth(float health)								// set the mamimum value of the bar
	{
		slider.maxValue = health;										// set max value
		slider.value = health;											// set current slider value = max

		fill.color = gradient.Evaluate(1f);								// change gradiant colour if present
	}

    public void SetHealth(float health)									// increse or decrese health
	{
		slider.value = health;											// set the current health value

		fill.color = gradient.Evaluate(slider.normalizedValue);			//normalise the heqalth bar gradient if present
	}

}
