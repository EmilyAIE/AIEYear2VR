using UnityEngine;

public class FlameStartUp : MonoBehaviour
{
    [SerializeField]
    GameObject m_flame;

    ControllerReference m_controllerRef;

    // Start is called before the first frame update
    void Start()
    {
        m_controllerRef = GameObject.FindAnyObjectByType<ControllerReference>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_controllerRef.rightController.activateAction.action.WasPressedThisFrame())
        {
            StartFlame();
        }
        else if (m_controllerRef.rightController.activateAction.action.WasReleasedThisFrame())
        {
            EndFlame();
        }
    }

    public void StartFlame()
    {
        m_flame.SetActive(true);
    }

    public void EndFlame()
    {
        m_flame.SetActive(false);
    }
}
