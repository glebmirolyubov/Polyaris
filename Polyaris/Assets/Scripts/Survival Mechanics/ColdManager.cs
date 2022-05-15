using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opsive.UltimateCharacterController.Traits;

public class ColdManager : MonoBehaviour
{
    [Tooltip("The character that has the health component.")]
    [SerializeField] private GameObject m_Character;

    public float timeRemaining = 5;

    public bool startTimer = false;
    public bool damagePlayer = false;

    private void Update()
    {
        if (startTimer)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                startTimer = false;
                if (damagePlayer)
                {
                    InvokeRepeating("DamagePlayer", 0f, 0.5f);
                }
                else
                {
                    InvokeRepeating("RegenerateHealth", 0f, 0.5f);
                }
            }
        }
    }

    public void ResetTimer()
    {
        timeRemaining = 5;
        CancelInvoke();
    }

    public void StartTimer()
    {
        ResetTimer();
        startTimer = true;
    }

    public void RegenerateHealth()
    {
        var health = m_Character.GetComponent<Health>();

        health.Heal(2f);

        if (health.Value >= 100)
        {
            ResetTimer();
            startTimer = false;
            damagePlayer = false;
        }
    }

    public void DamagePlayer()
    {
        var health = m_Character.GetComponent<Health>();

        health.Damage(1f);
    }
}
