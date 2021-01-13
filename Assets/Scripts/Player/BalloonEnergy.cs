using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonEnergy : MonoBehaviour
{
    public float maxEnergy;
    public float currentEnergy;

    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = maxEnergy;
        GUIManager.instance.SetMaxEnergy(maxEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        EnergyConsuming();
        if (currentEnergy <= 0f)
        {
            if(!GameManager.instance.isGameOver)
            GameManager.instance.GameOver();
            //EndDay();
        }
    }

    void EnergyConsuming()
    {
        if (currentEnergy > 0f)
        {
            currentEnergy -= 0.05f;
            GUIManager.instance.SetEnergyUI(currentEnergy);
        }
    }

    public void IncreaseEnergy()
    {
        if (!GameManager.instance.isGameOver)
        {
            currentEnergy = maxEnergy;
            GUIManager.instance.SetEnergyUI(currentEnergy);
        }
    }
}
