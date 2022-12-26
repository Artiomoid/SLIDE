using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class CameraShake : MonoBehaviour
{
  public Animator camAnim;

  public void CamBigShake(){
    camAnim.SetTrigger("shake");
    
     Debug.Log("Obstacle");
  }

  public void CamSmallShake(){
    camAnim.SetTrigger("SmallShake");

  }
}