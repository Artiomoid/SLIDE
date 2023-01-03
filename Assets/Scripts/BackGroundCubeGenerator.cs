using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCubeGenerator : MonoBehaviour
{


    [SerializeField]public Transform Rotate;

    public int SpaceDistance = 200;
    public GroundGenerator Ground;


        void start (){

          

      GenerateCube();


        }
    
        
    

   
   public void GenerateCube(){

    Instantiate(Rotate,new Vector3(0,0, (300*Ground.i)+300+(Ground.i*100) + SpaceDistance),Quaternion.identity);
    SpaceDistance += 200;
    
   }
}
