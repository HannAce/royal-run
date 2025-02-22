using System;
using UnityEngine;

public class BlackHoleAttractor : MonoBehaviour
{
    public static BlackHoleAttractor instance;
    [SerializeField] private float pullForce = 5f;
    public float PullForce => pullForce;
    
    private void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
