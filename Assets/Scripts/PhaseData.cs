using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PhaseData : ScriptableObject
{
    public float TimeTreshold;

    public float[] probabilities;
    public float[] multipliers;
    public GameObject[] bullets;
}
