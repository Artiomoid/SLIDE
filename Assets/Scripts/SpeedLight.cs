using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLight : MonoBehaviour
{

    public float distance = 0.3f;
    // Start is called before the first frame update
   
   
    public void LightEffect(){
     
     if(distance < 1.1f){
        distance += 0.1f;
     }
     transform.localPosition = new Vector3(0.08f,0.2f,distance);
    }
}
