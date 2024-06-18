using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public GameObject lightningOne;
    public GameObject lightningTwo;
    public GameObject lightingThree;


    public GameObject audioOne;

    private void Start()
    {
        lightningOne.SetActive(false);
        lightningTwo.SetActive(false);
        lightingThree.SetActive(false);

        audioOne.SetActive(false);

        Invoke("CallLightning", 1.75f);
    }

    void CallLightning()
    {
        int r = Random.Range(0, 3);
        if (r == 0)
        {
            lightningOne.SetActive(true);
            Invoke("EndLightning", .125f); 
            Invoke("CallThunder", .395f);
        }
        else if (r == 1)
        {
            lightningTwo.SetActive(true);
            Invoke("EndLightning", .105f);
            Invoke("CallThunder", .105f);
        }
        else
        {
            lightingThree.SetActive(true);
            Invoke("EndLightning", .75f);
            CallThunder();
        }
       
    }

    void EndLightning()
    {
        lightningOne.SetActive(false);
        lightningTwo.SetActive(false);
        lightingThree.SetActive(false);

        float rand = Random.Range(3.5f, 7.7f);
        Invoke("CallLightning", rand);
    }

    void CallThunder()
    {
        audioOne.SetActive(true);
        Invoke("EndThunder", 12f);
    }

    void EndThunder()
    {
        audioOne.SetActive(false);
    }
}
