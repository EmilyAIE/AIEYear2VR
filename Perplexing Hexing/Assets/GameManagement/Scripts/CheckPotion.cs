using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPotion : MonoBehaviour
{
    GameManager m_gM;
    Vial m_currentVial;
    Renderer m_rend;

    private void Start()
    {
        m_gM = GetComponentInParent<GameManager>();
        m_rend = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Vial"))
        {
            m_currentVial = other.GetComponent<Vial>();
            if(m_currentVial.CorrectPotion)
            {
                Success(m_currentVial);
            }
            else
            {
                Fail(m_currentVial);
            }
        }
    }

    public void Success(Vial vial)
    {
        m_rend.material.color = Color.green;
        m_gM.RemoveCurrentRecipe(vial.Colour);
        m_currentVial.DestroyVial();        
    }

    public void Fail(Vial vial)
    {
        m_gM.RemoveCurrentRecipe(vial.Colour);
        m_rend.material.color = Color.red;
        m_currentVial.DestroyVial();
    }   
}
