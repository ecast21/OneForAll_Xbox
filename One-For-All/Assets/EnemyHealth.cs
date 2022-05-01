using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth = 0;
    public float maxHealth = 15;

    public GameObject healthBarUI;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        slider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();

        if(currentHealth < maxHealth) {
            healthBarUI.SetActive(true);
        }
    }

    float CalculateHealth() {
        return currentHealth / maxHealth;
    }
}
