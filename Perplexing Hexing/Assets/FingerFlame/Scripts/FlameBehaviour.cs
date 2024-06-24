using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBehaviour : MonoBehaviour
{
    [SerializeField]
    Cauldron m_cauldron;

    private void Awake()
    {
        m_cauldron = FindAnyObjectByType<Cauldron>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Cauldron>())
        {
            Debug.Log("COOKCOOKCOOKCOOKCOOK");
            m_cauldron.StartCooking();
        }
    }
}
