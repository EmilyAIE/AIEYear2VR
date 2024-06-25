using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string Name;
    IngredientSpawnDetatch m_spawnDetatch;
    [SerializeField]
    float m_deleteTime;

    public void Start()
    {
        m_spawnDetatch = GetComponent<IngredientSpawnDetatch>();
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

    public void DestroyIngredient()
    {
        m_spawnDetatch.Deactivate();
    }
}
