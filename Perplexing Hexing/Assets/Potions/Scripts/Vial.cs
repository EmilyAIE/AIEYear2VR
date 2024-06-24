using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vial : MonoBehaviour
{
    private GameObject m_gameObject;
    public GameObject m_directionObject;
    private Vector3 m_directionVector;
    public bool CorrectPotion = false;
    public string Colour;

    private void Start()
    {
        m_gameObject = gameObject;
    }
    public bool CheckOrientation()
    {
        m_directionVector = m_directionObject.transform.position - m_gameObject.transform.position;
        m_directionVector.Normalize();
        if(m_directionVector.y > -1)
        {
            
            return true;
        }
        return false;
    }

    
}
