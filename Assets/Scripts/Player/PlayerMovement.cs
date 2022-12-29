using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour {

     public Rigidbody rb;
    public float forwardSpeed = 3000f;
    public float sidewaySpeed = 0.85f;
    private bool moveLeft = false;
    private bool moveRight = false;
    public float spaceAdjustment = 0;
    public GroundGenerator groundGenerator;
    public int sideforce = 87;
    public PlayerCollision colli;
    public TrailRenderer trail;
    public CameraShake cam;
    public FollowPlayer follow;
    public PlayerManager playerManager;
    public SpeedLight speedD;
    public bool active = false;

    void Start() {
  colli = GetComponent<PlayerCollision>();
  Invoke("Active",2);
   
    }

    void Active(){
        active = true;
    }
    
 

    // Update for physics

    void FixedUpdate()
    {

       if(!active)
       return;

       rb.AddForce(0, 0, forwardSpeed * Time.deltaTime);

        if (moveLeft)
        {
              rb.AddForce(-sideforce * sidewaySpeed, 0, 0);
            
        }

        if (moveRight)
        {
            rb.AddForce(sideforce * sidewaySpeed,0,0);
        }


    }
 void Update()
    {

          if(!active)
       return;
     
       
        
         //}
        if(Input.GetKeyDown("q"))
        { 
            Debug.Log("Quitt");
            Application.Quit();
        }
     
        // check if player has fallen from ground

        if (rb.position.y < 0)
        {
            StartCoroutine(playerManager.PlayerDied((int)transform.position.z));
        }
      


        // ----------- Computer Controls ----------- //

        if (!FindObjectOfType<GameManager>().paused)
        {

            // LEFT RIGHT

            if (Input.GetKeyDown("left") ||Input.GetKeyDown("a"))
            {
                
                moveLeft = true;
            }

            if (Input.GetKeyUp("left") || Input.GetKeyUp("a"))
            {
                moveLeft = false;
            }

            if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
            {
                moveRight = true;
            }

            if (Input.GetKeyUp("right") || Input.GetKeyUp("d"))
            {
                moveRight = false;
            }          
        }
        




        // ----------- Phone Controls ----------- //

        if (Application.platform == RuntimePlatform.IPhonePlayer) {

            if (Input.touchCount > 0)
            {

                // LEFT RIGHT

                if (Input.GetTouch(0).phase == TouchPhase.Stationary)
                {
                    if (Input.GetTouch(0).position.x < Screen.width / 2)
                    {   // User touched left side of phone
                        moveLeft = true;
                    }
                    else
                    {   // User touched right side of phone
                        moveRight = true;
                    }
                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    if (Input.GetTouch(0).position.x < Screen.width / 2)
                    {   // User released left side of phone
                        moveLeft = false;
                    }
                    else
                    {   // User released right side of phone
                        moveRight = false;
                    }
                }
            }




        }


    }

    public void jump(){
      
   
     rb.AddForce(new Vector3(0, 1350* Time.deltaTime ,30-spaceAdjustment),ForceMode.Impulse);
      
      if(forwardSpeed <= 3360){

      forwardSpeed += 80;
      spaceAdjustment +=  forwardSpeed * 0.0015f;
      }else{
      Debug.Log("You had Reached to the maxium of speed.");
      }
      speedD.LightEffect();

    
      
    }

    public void SmallJump(){
    
      rb.AddForce(new Vector3(0, 550* Time.deltaTime, 15),ForceMode.Impulse);
  
      }
      

      public void MiddleJump()
      {
        rb.AddForce(new Vector3(0, 1050* Time.deltaTime,10),ForceMode.Impulse);
    
      }
   


}