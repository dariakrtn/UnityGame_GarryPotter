using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


// Script for visualizing spells behind a wand (mouse)
public class Spalls : MonoBehaviour
{
    private Camera _camera;

    public GameObject Brush;
    public float BrushSize =1f;

    private void Start()
    {
        _camera = Camera.main;
    }

    
    private void Update()
    {

        Vector3 screenMousePosition = Input.mousePosition;
        screenMousePosition.z = _camera.depth * -90;
        Vector3 worldMousePosition = _camera.ScreenToWorldPoint(screenMousePosition);

        if (Input.GetMouseButton(0))
        {
            var go = Instantiate(Brush, worldMousePosition, Quaternion.identity, transform);
            go.transform.localScale = Vector3.one * BrushSize;

        }
    }
}
