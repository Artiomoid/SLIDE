using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public float cubeSize = 0.2f;
    public int cubesInRow = 5;

    bool hasExploded = false;
    float cubesPivotDistance;
    Vector3 cubesPivot;
    public Rigidbody rb;

    public float explosionForce = 20f;
    public float explosionRadius = 20f;
    public float explosionUpward = 1f;
    public PlayerMovement movement;
    public GroundGenerator groundGenerator;
    public BackGroundCubeGenerator backgroundGenerator;
    public CameraShake cam;
    public FollowPlayer camera;
    public float currentFOV;
    public PlayerManager playerManager;
    

    void Start()
    {
        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    //    movement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
      //  trail = GetComponentsInChildren<TrailRenderer>();
      currentFOV = 60;
    
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
      
       camera.ReverseCam(currentFOV);
       currentFOV = 60.0f;
       

        Physics.gravity = new Vector3(0, -20, 0);
        // player hit an obstacle
        
        if (collisionInfo.collider.tag == "Obstacle")
        {
         
           

            if (!hasExploded)
            {
                  
                  StartCoroutine(playerManager.PlayerDied((int)movement.score));   
                  Explode();                     
                
                  hasExploded = true;
                  
               
            }
        }

    }

    private void OnTriggerEnter(Collider other) {


        
         if (other.gameObject.tag == "JumpPad")
         {
            cam.CamSmallShake();
           camera.JumpCam(currentFOV);
           currentFOV = 76.0f;

        movement.jump();
         }   
        if(other.gameObject.tag == "SmallJumpPad")
        { 
        movement.SmallJump();
        }
        if(other.gameObject.tag == "MiddleJump")
        {
        movement.MiddleJump();
        }
        if(other.gameObject.tag == "TriggerLine")
          {
            groundGenerator.Generate();
            backgroundGenerator.GenerateCube();
          }
          if(other.gameObject.tag == "Goal")
          {
            
            UpdateScore(movement.score, movement.score += 100f, 0.5f);
          }

    }

    IEnumerator UpdateScore(float v_start, float v_end, float duration )
   {
     float elapsed = 0.0f;
     while (elapsed < duration )
     {
      movement.score = Mathf.Lerp( v_start, v_end, elapsed / duration );
       elapsed += Time.deltaTime;
       yield return null;
     }
    
   }

    
    public void Explode()
    {

        cam.CamBigShake();

        GameObject allPieces = new GameObject();

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    GameObject newPiece = CreatePiece(x, y, z);
                    newPiece.transform.parent = allPieces.transform;

                }
            }
        }

        //position the little cubes in the same position of the cube
        allPieces.transform.position = gameObject.transform.position;
        allPieces.transform.rotation = gameObject.transform.rotation;

        //make object disappear
         Renderer test= GetComponent<MeshRenderer>();
        test.enabled= false;
        movement.forwardSpeed = 0;

        // give the momentum of the cube to the little cubes
        GameObject[] pieces = GameObject.FindGameObjectsWithTag("piece");
        foreach (GameObject piece in pieces)
        {
            piece.GetComponent<Rigidbody>().AddForce(gameObject.GetComponent<Rigidbody>().velocity / 2, ForceMode.VelocityChange);
            piece.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
        }
        
          
    
        
    }

    GameObject CreatePiece(int x, int y, int z)
    {
        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        piece.tag = "piece";

        //set piece position and scale
        piece.transform.position = new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        // set piece color
        piece.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        
        return piece;
    }

}