using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfectionBar : MonoBehaviour
{

	public Slider slider;												// to select the slider component
	public Gradient gradient;											// to select grediant colour if present
	public Image fill;													// to fill the inside

	public void SetMinInfection(float infection)								// set the mamimum value of the bar
	{
		slider.minValue = infection;										// set max value
		slider.value = infection;											// set current slider value = max

		fill.color = gradient.Evaluate(1f);								// change gradiant colour if present
	}

    public void SetInfection(float infection)									// increse or decrese health
	{
		slider.value = infection;											// set the current health value

		fill.color = gradient.Evaluate(slider.normalizedValue);			//normalise the heqalth bar gradient if present
	}

}
