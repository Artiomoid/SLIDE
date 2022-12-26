using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
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
      
         playerMaterial.SetFloat("Vector1_b3c4e15c8ef445bd90c09ad6e9482121", MixValue);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        if(MixValue > minDissolve)
{
   MixValue -= dissolveSpeed;
    playerMaterial.SetFloat("Vector1_b3c4e15c8ef445bd90c09ad6e9482121", MixValue);
    Debug.Log(MixValue);
}

    }
}
