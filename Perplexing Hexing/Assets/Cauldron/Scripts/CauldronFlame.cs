using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronFlame : MonoBehaviour
{
    Cauldron m_cauldron;

    private void Start()
    {
        m_cauldron = GetComponentInParent<Cauldron>();
    }

    public void StartCooking()
    {
        m_cauldron.StartCooking();
    }
}
