using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

	public float maxHealth = 100;
	public float currentHealth;

	public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(20);
		}
		if (Input.GetKeyDown(KeyCode.B))
		{
			RecoverDamage(20);
		}
		if (currentHealth>100)
		{
			currentHealth=100;
		}
    }

	public void TakeDamage(float damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
		
	}
	
	public void RecoverDamage(float damage)
	{
		currentHealth += damage;

		healthBar.SetHealth(currentHealth);
	}
}
