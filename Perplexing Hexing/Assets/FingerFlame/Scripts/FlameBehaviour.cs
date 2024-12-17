using UnityEngine;

public class FlameBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");        
        CauldronFlame flame = other.GetComponent<CauldronFlame>();
        if (!flame.Flamin)
        {
            Debug.Log("START COOKING WAHOO GOGOGOGOGGO");
            flame.StartCooking();
        }
    }
}
