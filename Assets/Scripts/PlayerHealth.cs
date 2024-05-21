using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 1;

    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    private float _maxValue;

    private void Start()
    {
        _maxValue = value;
    }

    public void DealDamage(float damage)
    {

        value -= damage;
        if (value <= 0)
        {
            PlayerIsDead();
        }

    }

    private void PlayerIsDead()
    {
        Time.timeScale = 0f;
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
    }

}