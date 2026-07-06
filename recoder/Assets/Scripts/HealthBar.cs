using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Slider slider;
    public Text healthCounter;

    public GameObject playerState;

    private float currentHelth, maxHealth;



    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHelth = playerState.GetComponent<PlayerState>().currentHelth;
        maxHealth = playerState.GetComponent<PlayerState>().maxHealth;

        float fillValue = currentHelth / maxHealth;
        slider.value = fillValue;

        healthCounter.text = currentHelth + "/" + maxHealth;

    }
}
