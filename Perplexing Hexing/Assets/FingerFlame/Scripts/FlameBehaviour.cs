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
        CauldronFlame flame = other.GetComponent<CauldronFlame>();
        if (flame)
        {
            flame.StartCooking();
        }
    }
}
