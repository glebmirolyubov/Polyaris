using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opsive.UltimateCharacterController.Traits;


public class OceanDeath : MonoBehaviour
{
    [Tooltip("The character that has the health component.")]
    [SerializeField] protected GameObject m_Character;
    /// <summary>
    /// Damages and heals the character.
    /// </summary>
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var health = m_Character.GetComponent<Health>();

            health.ImmediateDeath();

            GetComponent<AudioSource>().Play();
        }
    }
}
