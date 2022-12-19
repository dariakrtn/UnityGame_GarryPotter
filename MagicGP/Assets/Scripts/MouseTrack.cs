using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

//Script for tracking the magic wand behind the mouse
public class MouseTrack : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
      _camera= Camera.main;  
    }

    
    private void Update()
    {
        Vector3 screenMousePosition = Input.mousePosition;

        screenMousePosition.z = _camera.depth * 5;
        Vector3 worldMousePosition = _camera.ScreenToWorldPoint(screenMousePosition);
        
        transform.LookAt(-worldMousePosition);
    }
}
