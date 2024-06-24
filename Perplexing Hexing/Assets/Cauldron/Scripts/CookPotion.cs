using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Filtering;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

public class CookPotion : MonoBehaviour
{
    //Emily wrote this and will change this to be infinitely better than ever
    public enum CookTime
    {
        UNDER,
        GOOD,
        BAD,
        RUINED,
    }

    [SerializeField]
    private CookTime m_cookTime;

    [SerializeField]
    private Cauldron m_cauldron;

    [SerializeField]
    private TestPotion m_testPotion;

    //private PlayerInput m_playerInput;
    //private InputAction m_cookAction;
    
    public XRDeviceSimulator m_device;

    bool m_canCook = true;

    Coroutine m_canCookCoroutine;


    ControllerReference m_playerControllers;

    [SerializeField]
    TextMeshProUGUI m_cookText;


    // Start is called before the first frame update
    void Start()
    {
        m_cauldron = GetComponent<Cauldron>();
        //m_playerInput = GetComponent<PlayerInput>();
        m_playerControllers = GameObject.FindAnyObjectByType<ControllerReference>();
    }

    private void OnEnable()
    {
    }

    // Update is called once per frame
    void Update()
    {
        m_cookText.text = m_cookTime.ToString();

        if (m_playerControllers.rightController.activateAction.action.WasPressedThisFrame() && !m_canCook)
        {
            Debug.Log("Finish Cooking");
            //StopCoroutine(CookingAction(m_cookTime));
            StopAllCoroutines();
            if (m_cookTime == CookTime.GOOD)
            {
                //m_cauldron.Potion = 1;
            }         
            //m_cauldron.currentIngredients.Clear();
            m_canCook = true;
        }

        if (m_playerControllers.rightController.activateAction.action.WasPressedThisFrame() && m_canCook)
        {
            Debug.Log("START COOKING");
            Cooking(m_cauldron, m_cookTime);
        }

        //if (m_device.gripAction.ToInputAction().WasPressedThisFrame() && m_canCook && m_cauldron.currentIngredients.SequenceEqual(m_testPotion.Recipe))
        //{
        //    Debug.Log("START COOKING");
        //    Cooking(m_cauldron, m_cookTime);
        //}

    }

    public void Cooking(Cauldron cauldron, CookTime time)
    {
        m_canCook = false;
        StartCoroutine(CookingAction(time));
    }

    public IEnumerator CookingAction(CookTime cookTime)
    {       
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    Debug.Log("Under cooked");
                    yield return new WaitForSeconds(20);
                    m_cookTime = (CookTime)i + 1;
                    break;
                case 1:
                    Debug.Log("Cooked Well");
                    yield return new WaitForSeconds(10);
                    m_cookTime = (CookTime)i + 1;
                    break;
                case 2:
                    Debug.Log("Bad");
                    yield return new WaitForSeconds(15);
                    m_cookTime = (CookTime)i + 1;
                    break;
                case 3:
                    Debug.Log("Ruined");
                    m_cookTime = (CookTime)i + 1;
                    break;
            }
        }        
    }
}