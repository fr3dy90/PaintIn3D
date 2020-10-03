using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
   private Vector3 mPrevPos = Vector3.zero;
   private Vector3 mPosDelta = Vector3.zero;
   private Vector3 posCam;
   public float speed;

   private void Update()
   {
      if (Input.GetMouseButton(1))
      {
         posCam = Camera.main.transform.position;
         mPosDelta = Input.mousePosition - mPrevPos;
         transform.Rotate(transform.up, (Vector3.Dot(mPosDelta, Camera.main.transform.right)*speed)*Time.deltaTime, Space.World);
         float ammoun = Vector3.Dot(mPosDelta, Camera.main.transform.up);
         ammoun = (ammoun * speed)*Time.deltaTime;
         if (Camera.main.transform.position.y > -.4f && ammoun > 0)
         {
            Camera.main.transform.RotateAround(transform.position, Vector3.right, ammoun);
         }
         else if(Camera.main.transform.position.y < 3.2f && ammoun < 0)
         {
            Camera.main.transform.RotateAround(transform.position, Vector3.right, ammoun);
         }
      }

      mPrevPos = Input.mousePosition;
   }
}
