using Pixelplacement;
using UnityEngine;

public class CheckPotion : MonoBehaviour
{
    GameManager m_gM;
    Vial m_currentVial;    
    Color m_defaultColor;

    public Spline ExitSpline;

    GameObject m_vialInBox;
    [SerializeField]
    Transform m_potionAttatchPoint;

    bool m_canPutPotionIn = true;

    Animator m_animator;

    public Disolve DisolveOne;
    public Disolve DisolveTwo;
    public Disolve DisolveThree;

    Vector3 startPos;
    Quaternion startRotation;

    private void Start()
    {
        m_gM = GetComponentInParent<GameManager>();
        startPos = transform.position;
        startRotation = transform.rotation;
        m_animator = GetComponent<Animator>();        
        FadeIn();
        m_animator.SetTrigger("OpenBox");
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
        Debug.Log("Potion was a Success");        
        m_gM.RemoveCurrentRecipe(vial.Colour);
        m_currentVial.DestroyVial();
        vial.CanFill = true;
        m_animator.SetTrigger("CloseBox");
        Invoke("FlyOut", 1);
        Invoke("FadeOut", 3);
        Invoke("ResetColour", 1.5f);
    }

    public void Fail(Vial vial)
    {
        //m_rend.material.color = Color.red;
        Debug.Log("Potion was a Success");
        vial.CanFill = true;
        m_currentVial.DestroyVial();
        Invoke("ResetColour", 1.5f);
    }
    
    public void ResetColour()
    {
        //m_rend.material.color = m_defaultColor;
        Destroy(m_vialInBox);
        m_canPutPotionIn = true;
    }

    public void FadeOut()
    {
        DisolveOne.DisolveOut();
        DisolveTwo.DisolveOut();
        DisolveThree.DisolveOut();
        Invoke("ResetPosition", 3);
    }

    public void ResetPosition()
    {
        transform.rotation = startRotation;
        transform.position = startPos;
        FadeIn();
    }

    public void FadeIn()
    {
        m_animator.SetTrigger("OpenBox");
        DisolveOne.DisolveIn();
        DisolveTwo.DisolveIn();
        DisolveThree.DisolveIn();
    }

    public void FlyOut()
    {
        Tween.Spline(ExitSpline, transform, 0, 1, true, 3, 0);
    }
}
