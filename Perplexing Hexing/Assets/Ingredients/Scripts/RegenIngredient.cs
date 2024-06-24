using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenIngredient : MonoBehaviour
{
    [SerializeField]
    GameObject m_ingredient; //Ingredient to regenerate

    [SerializeField]
    float m_regenTime; //Regen time in seconds

    bool m_startSpawn = false;

    private void Update()
    {
        if (transform.childCount == 0 && !m_startSpawn)
        {
            m_startSpawn = true;
            StartCoroutine(RegenerateIngredient(m_regenTime));
        }
    }

    /// <summary>
    /// Waits for a desired amount of time before spawning in a new ingredient at the ingredient spot
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator RegenerateIngredient(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(m_ingredient).transform.SetParent(transform, false);
        m_startSpawn = false;
    }
}
