using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 10;
    private int directionRight;
    private int directionTurning;
    private int startrotation;
    // Start is called before the first frame update
    void Start()
    {
        directionRight = Random.Range(0,2);
        startrotation = Random.Range(0,361);
        if(directionRight == 0)
        directionTurning = -1;
        else if(directionRight == 1)
        directionTurning = 1;
        transform.rotation = Quaternion.Euler(0,0,startrotation);
        InvokeRepeating("Speed",5,5);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,rotationSpeed * directionTurning) * Time.deltaTime);
        
    }

    void Speed(){
        if(rotationSpeed <= 65)
        rotationSpeed += 3;
        

    }
}
