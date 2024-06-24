using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPotion : MonoBehaviour
{
    GameManager m_gM;
    Vial m_currentVial;

    private void Start()
    {
        m_gM = GetComponentInParent<GameManager>();   
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
        m_gM.RemoveCurrentRecipe(vial.Colour);
        Invoke("DestroyVial", 3);
    }

    public void Fail(Vial vial)
    {
        m_gM.RemoveCurrentRecipe(vial.Colour);
        Invoke("DestroyVial", 3);
    }

    public void DestroyVial()
    {
        Destroy(m_currentVial.gameObject);
    }
}
