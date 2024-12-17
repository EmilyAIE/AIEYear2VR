using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLOBALPOSITION : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Global?: " + transform.position);
        Debug.Log("Local?: " + transform.localPosition);
    }

    // Update is called once per frame
    
}
