using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    GameObject m_mainScreen, m_controls, m_tutorial;

    [SerializeField]
    GameObject[] m_tutPages;

    [SerializeField]
    GameObject m_nextButton, m_prevButton, m_beginButton;

    [SerializeField]
    TextMeshProUGUI m_titleText;

    int m_pageNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_mainScreen.SetActive(true);
        m_controls.SetActive(false);
        m_tutorial.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBrewing()
    {
        m_beginButton.SetActive(false);
        m_titleText.text = "Brewing has Begun";
        m_titleText.alignment = TextAlignmentOptions.Top;
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
        m_mainScreen.SetActive(false);
        m_tutorial.SetActive(true);
        m_pageNum = 0;
        m_nextButton.SetActive(true);
        m_prevButton.SetActive(false);
        for (int i = 0; i < m_tutPages.Length; i++)
        {
            if (i == m_pageNum)
            {
                m_tutPages[i].SetActive(true);
            }
            else
            {
                m_tutPages[i].SetActive(false);
            }
        }
    }

    public void ExitTutorialScreen()
    {
        m_mainScreen.SetActive(true);
        m_tutorial.SetActive(false);
    }

    public void NextPage()
    {
        m_pageNum++;
        if (m_pageNum > m_tutPages.Length - 1)
        {
            m_pageNum = m_tutPages.Length - 1;
        }

        for (int i = 0; i < m_tutPages.Length; i++)
        {
            if (i == m_pageNum)
            {
                m_tutPages[i].SetActive(true);
            }
            else
            {
                m_tutPages[i].SetActive(false);
            }
        }

        if (m_pageNum == m_tutPages.Length - 1)
        {
            m_nextButton.SetActive(false);
            m_prevButton.SetActive(true);
        }
        else
        {
            m_nextButton.SetActive(true);
            m_prevButton.SetActive(true);
        }
    }

    public void PrevPage()
    {
        m_pageNum--;
        if (m_pageNum < 0)
        {
            m_pageNum = 0;
        }

        for (int i = 0; i < m_tutPages.Length; i++)
        {
            if (i == m_pageNum)
            {
                m_tutPages[i].SetActive(true);
            }
            else
            {
                m_tutPages[i].SetActive(false);
            }
        }

        if (m_pageNum == 0)
        {
            m_prevButton.SetActive(false);
            m_nextButton.SetActive(true);
        }
        else
        {
            m_nextButton.SetActive(true);
            m_prevButton.SetActive(true);
        }
    }
}
