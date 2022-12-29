using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCubeGenerator : MonoBehaviour
{


    [SerializeField]public Transform Rotate;

    public int SpaceDistance = 1520;
    public GroundGenerator Ground;


        void start (){

          

      GenerateCube();


        }
    
        
    

   
   public void GenerateCube(){

    Instantiate(Rotate,new Vector3(0,0, (100*Ground.i)+100+(Ground.i*60) + SpaceDistance),Quaternion.identity);
    SpaceDistance += 200;
    
   }
}
