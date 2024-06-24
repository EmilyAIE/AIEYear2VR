using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnIngredient : MonoBehaviour
{
    [SerializeField]
    float m_deleteTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BadSurface")
        {
            Invoke("DestroyIngredient", m_deleteTime);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "BadSurface")
        {
            CancelInvoke("DestroyIngredient");
        }
    }

    void DestroyIngredient()
    {
        Destroy(gameObject);
    }
}
