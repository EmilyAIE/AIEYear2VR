using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    GameObject m_mainScreen, m_controls, m_tutorial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBrewing()
    {
        
    }

    public void EnterControlsScreen()
    {
        m_mainScreen.SetActive(false);
        m_controls.SetActive(true);    }

    public void ExitControlScreen()
    {
        m_mainScreen.SetActive(true);
        m_controls.SetActive(false);
    }

    public void EnterTutorialScreen()
    {

    }

    public void ExitTutorialScreen()
    {

    }
}
