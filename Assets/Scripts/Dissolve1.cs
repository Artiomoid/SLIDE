using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve1: MonoBehaviour
{
    public Material playerMaterial;
    public string PropertyName;

    public float minDissolve = -1;
    public float maxDissolve = 1.5f;

    private float dissolveSpeed = 0.02f;

    private float MixValue = 1.5f;


    // Start is called before the first frame update
    void Start()
    {   
         playerMaterial.SetFloat(PropertyName, MixValue);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        if(MixValue > minDissolve)
{
   MixValue -= dissolveSpeed;
    playerMaterial.SetFloat(PropertyName, MixValue);
    Debug.Log(MixValue);
}

    }
}
