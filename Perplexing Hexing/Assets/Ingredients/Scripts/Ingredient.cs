using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    // Dan's Dodgy Code

    public string Name;
    private Collider m_collider;

    private void Start()
    {
        m_collider = GetComponent<Collider>();
    }

    public void DisableCollider()
    {
        m_collider.enabled = false;
    }


}
