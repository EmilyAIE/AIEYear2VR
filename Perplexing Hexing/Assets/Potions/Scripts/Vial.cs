using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vial : MonoBehaviour
{
    private GameObject m_gameObject;
    public GameObject m_directionObject;
    private Vector3 m_directionVector;
    [SerializeField]
    private GameObject m_liquid;
    public bool CorrectPotion = false;
    public string Colour;
    [SerializeField]
    private RegenIngredient m_regen;
    [SerializeField]
    float m_deleteTime;

    public Material AmberDefault;
    public Material AmberLight;
    public Material AmberMedium;
    public Material AmberWellDone;
    public Material GreenDefault;
    public Material GreenLight;
    public Material GreenMedium;
    public Material GreenWellDone;
    public Material PurpleDefault;
    public Material PurpleLight;
    public Material PurpleMedium;
    public Material PurpleWellDone;
    
    private CookState m_cookState;
    public VialType VialType;

    private void Start()
    {
        m_gameObject = gameObject;
        m_regen = GetComponentInParent<RegenIngredient>();
    }
    public bool CheckOrientation()
    {
        m_directionVector = m_directionObject.transform.position - m_gameObject.transform.position;
        m_directionVector.Normalize();
        if(m_directionVector.y > 0)
        {            
            return true;
        }
        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BadSurface")
        {
            Invoke("DestroyVial", m_deleteTime);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "BadSurface")
        {
            CancelInvoke("DestroyVial");
        }
    }

    public void SetLiquid(CookState cookState)
    {
        m_liquid.SetActive(true);
        m_cookState = cookState;
        Renderer liquidRend = m_liquid.GetComponent<Renderer>();
        switch(Colour)
        {
            default:
                break;
            case "Green":
                switch (m_cookState)
                {
                    default:
                        break;
                    case CookState.UnderCooked:
                        liquidRend.material = GreenDefault;
                        break;
                    case CookState.LightlyCooked:
                        liquidRend.material = GreenLight;
                        break;
                    case CookState.MediumDone:
                        liquidRend.material = GreenMedium;
                        break;
                    case CookState.WellDone:
                        liquidRend.material = GreenWellDone;
                        break;
                }
                break;
            case "Amber":
                switch (m_cookState)
                {
                    default:
                        break;
                    case CookState.UnderCooked:
                        liquidRend.material = AmberDefault;
                        break;
                    case CookState.LightlyCooked:
                        liquidRend.material = AmberLight;
                        break;
                    case CookState.MediumDone:
                        liquidRend.material = AmberMedium;
                        break;
                    case CookState.WellDone:
                        liquidRend.material = AmberWellDone;
                        break;
                }
                break;
            case "Purple":
                switch (m_cookState)
                {
                    default:
                        break;
                    case CookState.UnderCooked:
                        liquidRend.material = PurpleDefault;
                        break;
                    case CookState.LightlyCooked:
                        liquidRend.material = PurpleLight;
                        break;
                    case CookState.MediumDone:
                        liquidRend.material = PurpleMedium;
                        break;
                    case CookState.WellDone:
                        liquidRend.material = PurpleWellDone;
                        break;
                }
                break;
        }
    }

    public void DestroyVial()
    {
        m_liquid.SetActive(false);
        m_regen.SetInactive(gameObject);
    }

    
}
