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

        // если мы не определяем корректно глубину, для нуля действительно актуальной будет позиция камеры,
        // так как она соответвует camera frustrum в этой позиции, обсудим на паре.
        // Чтобы это исправить достаточно использовать глубину камеры для z
        screenMousePosition.z = _camera.depth * 5;
        Vector3 worldMousePosition = _camera.ScreenToWorldPoint(screenMousePosition);
        //Debug.Log($"screenMousePosition - {screenMousePosition}, worldMousePosition - {worldMousePosition}");
        
        transform.LookAt(-worldMousePosition);
    }
}
