using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    
    public float speed = 70f;
    public float limit = 40f;
    public float currentSpeedx = 0f;
    private bool directionIsLeft = true;

    

	// Move the obstacle left and right

	void FixedUpdate () {

        
        if(currentSpeedx >= limit)
         directionIsLeft = false;
        else if(currentSpeedx <= -limit)
         directionIsLeft = true;

        if(directionIsLeft) {
            Vector3 move = new Vector3(speed * Time.deltaTime,0,0);
            transform.Translate(move);
            currentSpeedx += 1;
        }
        else if(!directionIsLeft) {
             Vector3 move = new Vector3(-speed * Time.deltaTime,0,0);
            transform.Translate(move);
            currentSpeedx -= 1;
        }
        
	}


}
