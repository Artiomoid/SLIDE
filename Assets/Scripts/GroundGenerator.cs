using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField]public List<Transform> levelList;
    public int groundSize = 250;
    public PlayerMovement movement;
   
    public int i = 0;
   
    
    private void Awake() {
    
        movement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        
    
        } 
         
    
    // Update is called once per frame
    public void Generate()
    {
        int randomIndex = Random.Range(0,levelList.Count);
        Vector3 spawnPostion = new Vector3(31,50,-100 + (groundSize*i)+(50*i)+75+(i*60));
        SpawnGround(spawnPostion, randomIndex);
        i++;
  
          
    }

    private void SpawnGround(Vector3 spawnPostion,int random){
   Instantiate(levelList[random],spawnPostion,Quaternion.identity);
    }
}
