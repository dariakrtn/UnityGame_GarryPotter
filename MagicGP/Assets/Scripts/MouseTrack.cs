using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

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
        //Vector3 pos = new Vector3 (0f, 260f, 15f);

        Vector3 worldMousePosition = _camera.ScreenToWorldPoint(screenMousePosition);
        Debug.Log(worldMousePosition);
        
        transform.LookAt(-screenMousePosition);
    }
}
