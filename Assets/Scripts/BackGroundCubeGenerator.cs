using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCubeGenerator : MonoBehaviour
{


    [SerializeField]public Transform CubeRight;
    [SerializeField]public Transform CubeLeft;
    [SerializeField]public Transform CubeUp;
    public int SpaceDistance = 1520;
    public GroundGenerator Ground;

        void start (){

      GenerateCube();


        }
    
        
    

   
   public void GenerateCube(){

    Instantiate(CubeRight,new Vector3(50,0, (100*Ground.i)+100+(Ground.i*60) + SpaceDistance),Quaternion.identity);
    Instantiate(CubeLeft,new Vector3(-50,0, (100*Ground.i)+100+(Ground.i*60) + SpaceDistance),Quaternion.identity);
    Instantiate(CubeUp,new Vector3(0,50, (100*Ground.i)+100+(Ground.i*60) + SpaceDistance),Quaternion.identity);
    SpaceDistance += 200;
    
   }
}
