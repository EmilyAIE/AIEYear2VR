using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    Vector3 m_cameraDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_cameraDir = Camera.main.transform.forward;
        m_cameraDir.y = 0;

        transform.rotation = Quaternion.LookRotation(m_cameraDir);
    }
}
