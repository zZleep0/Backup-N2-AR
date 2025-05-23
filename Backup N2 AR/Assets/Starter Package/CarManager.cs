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

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;

/**
 * Spawns a <see cref="CarBehaviour"/> when a plane is tapped.
 */
public class CarManager : MonoBehaviour
{
    public GameObject CarPrefab;
    public ReticleBehaviour Reticle;
    public DrivingSurfaceManager DrivingSurfaceManager;

    public CarBehaviour Car;

    public ChoosePlane choosePlane;

    private void Start()
    {
        choosePlane = GameObject.Find("ChoosePlane").GetComponent<ChoosePlane>();
    }

    private void Update()
    {
        if (Car == null && WasTapped() && Reticle.CurrentPlane != null && choosePlane.canStart)
        {
            if (choosePlane != null)
                CarPrefab = choosePlane.plane;

            // Spawn our car at the reticle location.
            var obj = GameObject.Instantiate(CarPrefab);
            Car = obj.GetComponent<CarBehaviour>();
            Car.Reticle = Reticle;
            Car.transform.position = new Vector3(Reticle.transform.position.x, Car.transform.position.y, Reticle.transform.position.z);
            DrivingSurfaceManager.LockPlane(Reticle.CurrentPlane);
        }
    }

    private bool WasTapped()
    {
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            return true;

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            return true;

        return false;
    }
}
