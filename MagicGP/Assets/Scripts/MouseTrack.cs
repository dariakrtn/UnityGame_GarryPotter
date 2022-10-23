using System.Collections;
using System.Collections.Generic;
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
        Vector3 pos = new Vector3 (0f, 260f, 15f);
        Debug.Log(screenMousePosition);
        //Vector3 worldMousePosition = _camera.ScreenToWorldPoint(screenMousePosition);
        
        transform.LookAt(-screenMousePosition + pos);
    }
}
