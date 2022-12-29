using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset1;
    public Vector3 offset2;
    public Vector3 offset3;
    public Vector3 previous;
    public int previouspers = 1;

    public int Firstperspect = 1;
    public CameraShake camShake;
    public Camera camera;

Vector3 cam1 ;
Vector3 cam2 ;
Vector3 cam3 ;
Vector3 cameraPosition;

void Start(){
  camera = GetComponentInChildren<Camera>();
camShake = camera.GetComponent<CameraShake>();
//player = GameObject.Find("player").GetComponent<Transform>();

}

    void Update() {
        cam1 = player.position + offset1;
         cam2 = player.position + offset2;
         cam3 = player.position + offset3;



   if(Firstperspect == 1)
 transform.position = cam1;

    if(Firstperspect == 2)
transform.position = cam2;


if (Input.GetKeyDown("f")){

           camShake.CamBigShake();    
            if(Firstperspect == 1){
            Firstperspect = 2;
            previous =  cam1 ;
            previouspers = 1;   
            }
            else if(Firstperspect == 2){
            Firstperspect = 1;
            previous = cam2;
            previouspers = 2;
            
            }

            
}

    }


    public void JumpCam(float current){
      if(current != 76f)
         StartCoroutine( ChangeFOV( current, 76.0f, 0.5f ) );
    }

    public void ReverseCam(float current){
      if(current != 60f)
          StartCoroutine( ChangeFOV( current, 60.0f, 0.5f ) );
    } 
    
     IEnumerator ChangeFOV( float v_start, float v_end, float duration )
   {
     float elapsed = 0.0f;
     while (elapsed < duration )
     {
        camera.fieldOfView = Mathf.Lerp( v_start, v_end, elapsed / duration );
       elapsed += Time.deltaTime;
       yield return null;
     }
      camera.fieldOfView = v_end;
   }
        


}
