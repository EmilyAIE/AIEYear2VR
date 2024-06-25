using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class Disolve : MonoBehaviour
{
    public AnimationCurve disolveInTween, disolveOutTween;

    private Material mat;
    private ParticleSystem particles;
    private Vector2 DisolveRange = new(0, 1.5f);
    private float disolveDuration = 2f;

    private void OnEnable()
    {
        mat = GetComponent<Renderer>().material;
        particles = GetComponent<ParticleSystem>();
        DisolveIn();
    }

    public void DisolveIn()
    {
        Tween.ShaderFloat(mat, "_Cutoff_Height", DisolveRange.y, disolveDuration, 0, disolveInTween);
        particles.Play();
    }

    public void DisolveOut()
    {
        Tween.ShaderFloat(mat, "_Cutoff_Height", DisolveRange.x, disolveDuration, 0, disolveOutTween);
        particles.Play();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DisolveOut();
        }

        if (Input.GetMouseButtonDown(1))
        {
            DisolveIn();
        }
    }


}
