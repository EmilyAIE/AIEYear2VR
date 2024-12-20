using System.Collections;
using UnityEngine;

public class RegenIngredient : MonoBehaviour
{
    [SerializeField]
    GameObject m_ingredient; //Ingredient to regenerate

    public GameObject WaitingObject, InactiveObjects, ActiveObjects;

    [SerializeField]
    int m_ingredientCount;

    [SerializeField]
    float m_regenTime; //Regen time in seconds
    bool m_startSpawn = false;

    private void Start()
    {
        Instantiate(m_ingredient, WaitingObject.transform);
        for (int i = 0; i < m_ingredientCount - 1; i++)
        {
            GameObject ingredient = Instantiate(m_ingredient, InactiveObjects.transform);
            ingredient.SetActive(false);            
        }
    }

    private void Update()
    {
        if (WaitingObject.transform.childCount == 0 && !m_startSpawn)
        {
            m_startSpawn = true;
            StartCoroutine(RegenerateIngredient(m_regenTime));
        }
    }

    public void MoveToActive(Transform trans)
    {
        trans.parent = ActiveObjects.transform;
    }

    /// <summary>
    /// Waits for a desired amount of time before spawning in a new ingredient at the ingredient spot
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator RegenerateIngredient(float time)
    {
        yield return new WaitForSeconds(time);
        if(InactiveObjects.transform.childCount > 0)
        {
            GameObject newObject = InactiveObjects.transform.GetChild(0).gameObject;
            Rigidbody  rigidBody = newObject.GetComponent<Rigidbody>();
            rigidBody.velocity = Vector3.zero;

            newObject.transform.parent = WaitingObject.transform;
            newObject.transform.rotation = WaitingObject.transform.rotation;
            newObject.SetActive(true);
        }
        m_startSpawn = false;
    }

    public void SetInactive(GameObject activeObject)
    {
        activeObject.SetActive(false);
        Rigidbody rb = activeObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        activeObject.transform.parent = InactiveObjects.transform;
        activeObject.transform.position = InactiveObjects.transform.position;
    }
}
