using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPotion : MonoBehaviour
{
    GameManager m_gM;
    Vial m_currentVial;
    //Renderer m_rend;
    Color m_defaultColor;

    GameObject m_vialInBox;
    [SerializeField]
    Transform m_potionAttatchPoint;

    bool m_canPutPotionIn = true;

    private void Start()
    {
        m_gM = GetComponentInParent<GameManager>();
        //m_rend = GetComponent<Renderer>();
        //m_defaultColor = m_rend.material.color;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Vial") && m_canPutPotionIn)
        {
            m_currentVial = other.GetComponentInParent<Vial>();
            m_vialInBox = Instantiate(other.GetComponentInParent<Vial>().gameObject, m_potionAttatchPoint.transform.position, Quaternion.identity, m_potionAttatchPoint);
            m_vialInBox.GetComponentInChildren<SphereCollider>().enabled = false;
            m_vialInBox.GetComponent<Vial>().enabled = false;
            m_canPutPotionIn = false;
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
        //m_rend.material.color = Color.green;
        m_gM.RemoveCurrentRecipe(vial.Colour);
        m_currentVial.DestroyVial();
        Invoke("ResetColour", 1.5f);
    }

    public void Fail(Vial vial)
    {
        //m_rend.material.color = Color.red;
        m_currentVial.DestroyVial();
        Invoke("ResetColour", 1.5f);
    }
    
    public void ResetColour()
    {
        //m_rend.material.color = m_defaultColor;
        Destroy(m_vialInBox);
        m_canPutPotionIn = true;
    }
}
