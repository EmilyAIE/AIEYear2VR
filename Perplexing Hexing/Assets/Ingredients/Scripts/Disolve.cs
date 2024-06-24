using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class Disolve : MonoBehaviour
{
    private Material mat;
    public AnimationCurve DisolveTween;
    public Vector2 DisolveRange;

    // Start is called before the first frame update
    private void OnEnable()
    {
        mat = GetComponent<Renderer>().material;
        DisolveIn();
    }

    public void DisolveIn()
    {
        Tween.ShaderFloat(mat, "_Cutoff_Height", DisolveRange.y, 1, 0, DisolveTween);
    }

    public void DisolveOut()
    {
        Tween.ShaderFloat(mat, "_Cutoff_Height", DisolveRange.x, 1, 0, DisolveTween);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DisolveOut();
        }
    }


}
