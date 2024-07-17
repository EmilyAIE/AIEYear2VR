using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string Name;
    IngredientSpawnDetatch m_spawnDetatch;
    [SerializeField]
    float m_deleteTime;
    float m_disolveTime = 2f;

    public void Start()
    {
        m_spawnDetatch = GetComponent<IngredientSpawnDetatch>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BadSurface")
        {
            Invoke("StartDestroyIngredient", m_deleteTime);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "BadSurface")
        {
            CancelInvoke("StartDestroyIngredient");
        }
    }

    public void DestroyIngredient()
    {
        m_spawnDetatch.Deactivate();
    }

    void StartDestroyIngredient()
    {
        Disolve disolve = GetComponent<Disolve>();
        disolve.DisolveOut();

        Invoke("DestroyIngredient", m_disolveTime);
    }
}
