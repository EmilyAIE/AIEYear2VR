using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LemmingSetup : MonoBehaviour
{

    [SerializeField]
    List<string> m_lemmingNames;

    [SerializeField]
    TextMeshProUGUI m_nameText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        int index = Random.Range(0, m_lemmingNames.Count());
        m_nameText.text = m_lemmingNames[index].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
