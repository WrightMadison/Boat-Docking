﻿using UnityEngine;
 using System.Collections;
 
 public class WaveGen : MonoBehaviour
 {
     float scale = 0.5f;
     float speed = 3.0f;
     float noiseStrength = 1f;
     float noiseWalk = 1f;
 
     private Vector3[] baseHeight;
  
     void Update () {
         Mesh mesh = GetComponent<MeshFilter>().mesh;
   
         if (baseHeight == null)
             baseHeight = mesh.vertices;
   
         Vector3[] vertices = new Vector3[baseHeight.Length];
         for (int i=0;i<vertices.Length;i++)
         {
             Vector3 vertex = baseHeight[i];
             vertex.y += Mathf.Sin(Time.time * speed+ baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale;
             vertex.y += Mathf.PerlinNoise(baseHeight[i].x + noiseWalk, baseHeight[i].y + Mathf.Sin(Time.time * 0.1f)    ) * noiseStrength;
             vertices[i] = vertex;
         }
         mesh.vertices = vertices;
         mesh.RecalculateNormals();
     }
 }
