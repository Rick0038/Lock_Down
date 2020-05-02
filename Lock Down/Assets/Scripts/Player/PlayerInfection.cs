using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfection : MonoBehaviour
{

	public float minInfection=0 ;
	public float maxInfection=100 ;
	public float currentInfection=1;
	public float rate=5 ;
	public float infectiondamage;

	public InfectionBar infectionbar;
	public PlayerHealth playerHealth;

    void Start()
    {
		currentInfection = minInfection;
		infectionbar.SetMinInfection(minInfection);
    }
    void Update()
    {
		
		currentInfection += rate * Time.deltaTime;
		infectionbar.SetInfection(currentInfection);
		
		if (Input.GetKeyDown(KeyCode.N))
		{
			RecoverDamage(5);
		}
		
		if (currentInfection>maxInfection)
		{
			playerHealth.TakeDamage(infectiondamage);
			currentInfection=101;
			infectionbar.SetInfection(currentInfection);
			
		}
		if (currentInfection<0)
		{
			playerHealth.RecoverDamage(5);
			currentInfection=0;
		}
		
    }	
	void RecoverDamage(float damage)
	{
		currentInfection -=damage;
		infectionbar.SetInfection(currentInfection);
	}
}

