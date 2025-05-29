using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
   [SerializeField] private Transform target;
   [SerializeField] private float smoothing = 5f;

   private Vector3 offset;

   private void Start()
   {
      offset = transform.position - target.position;
   }

   private void Update()
   {
      Vector3 targetPos = target.position + offset;
      transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
   }
}
