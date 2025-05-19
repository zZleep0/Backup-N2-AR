﻿/*
 * Copyright 2021 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PacotesSpawner : MonoBehaviour
{
    public DrivingSurfaceManager DrivingSurfaceManager;
    public PackageBehaviour Package;
    public List<GameObject> PackagePrefab;
    public PackageBehaviour obs;
    public GameObject obstaculo;


    public static Vector3 RandomInTriangle(Vector3 v1, Vector3 v2)
    {
        float u = Random.Range(0.0f, 1.0f);
        float v = Random.Range(0.0f, 1.0f);
        if (v + u > 1)
        {
            v = 1 - v;
            u = 1 - u;
        }

        return (v1 * u) + (v2 * v);
    }

    public static Vector3 FindRandomLocation(ARPlane plane)
    {
        // Select random triangle in Mesh
        var mesh = plane.GetComponent<ARPlaneMeshVisualizer>().mesh;
        var triangles = mesh.triangles;

        //Metodo antigo que nao funciona corretamente:
        //var triangle = triangles[(int)Random.Range(0, triangles.Length - 1)] / 3 * 3;
        //var randomInTriangle = RandomInTriangle(vertices[triangle], vertices[triangle + 1]);

        var triangleIndex = Random.Range(0, triangles.Length / 3);
        var firstVertexIndex = triangleIndex * 3;
        var vertices = mesh.vertices;

        //Get the 3 vertices of the selected triangle
        var v1 = vertices[triangles[firstVertexIndex]];
        var v2 = vertices[triangles[firstVertexIndex + 1]];
        var v3 = vertices[triangles[firstVertexIndex + 2]];

        //Get a random point inside the triangle
        var randomInTriangle = RandomInTriangle(v1, v2);
        randomInTriangle = RandomInTriangle(randomInTriangle, v3);

        //Convert the random point to world space
        var randomPoint = plane.transform.TransformPoint(randomInTriangle);

        

        return randomPoint;
    }

    public void SpawnPackage(ARPlane plane)
    {
        var packageClone = GameObject.Instantiate(PackagePrefab[Random.Range(0, PackagePrefab.Count)]);
        packageClone.transform.position = FindRandomLocation(plane);

        Package = packageClone.GetComponent<PackageBehaviour>();

        
    }

    public void SpawnObstaculo(ARPlane plane)
    {
        //PARA O FAKE
        var obsPackage = GameObject.Instantiate(obstaculo);
        obsPackage.transform.position = FindRandomLocation(plane);
        obs = obsPackage.GetComponent<PackageBehaviour>();
    }

    private void Update()
    {
        var lockedPlane = DrivingSurfaceManager.LockedPlane;
        if (lockedPlane != null)
        {
            if (Package == null || obs == null) 
            {
                SpawnPackage(lockedPlane);
                SpawnObstaculo(lockedPlane);
            }

            var packagePosition = Package.gameObject.transform.position;
            packagePosition.Set(packagePosition.x, lockedPlane.center.y, packagePosition.z);

            
            var obsPosition = obs.gameObject.transform.position;
            obsPosition.Set(obsPosition.x, lockedPlane.center.y, obsPosition.z);
        }
    }
}
