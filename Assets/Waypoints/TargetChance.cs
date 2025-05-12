using UnityEngine;
using System;
using System.Collections.Generic;

public class TargetChance : MonoBehaviour
{
    
    public int chance;
    public bool sequence;
    public GameObject nextTargetA;
    public GameObject nextTargetB;
    
    
    void Start()
    {
        chance=100;
    }
}
