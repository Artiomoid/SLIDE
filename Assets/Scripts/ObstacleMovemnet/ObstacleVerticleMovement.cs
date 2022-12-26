using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleVerticleMovement : MonoBehaviour {

    
    public float speed = 70f;
    public float limit = 10f;
    public float currentSpeedx = 0f;
    private bool forwardDir = true;

    

	// Move the obstacle left and right

	void FixedUpdate () {

        
        if(currentSpeedx >= limit)
         forwardDir = false;
        else if(currentSpeedx <= -limit)
         forwardDir = true;

        if(forwardDir) {
            Vector3 move = new Vector3(0,0,speed * Time.deltaTime);
            transform.Translate(move);
            currentSpeedx += 1;
        }
        else if(!forwardDir) {
             Vector3 move = new Vector3(0,0,-speed * Time.deltaTime);
            transform.Translate(move);
            currentSpeedx -= 1;
        }
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        // the player hit the moving obstacle

        if (collision.collider.name == "Player")
        {
            Debug.Log("Boom");
           
        }
    }

}
