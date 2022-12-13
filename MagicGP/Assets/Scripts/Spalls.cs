using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spalls : MonoBehaviour
{
    private Camera _camera;

    public GameObject Brush;
    public float BrushSize = 0.1f;
    public RenderTexture RTexture;
    private void Start()
    {
        _camera = Camera.main;
    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 screenMousePosition = Input.mousePosition;
            screenMousePosition.z = _camera.depth * -90;
            Vector3 worldMousePosition = _camera.ScreenToWorldPoint(screenMousePosition);

            var go = Instantiate(Brush, worldMousePosition, Quaternion.identity, transform);
            go.transform.localScale = Vector3.one * BrushSize;

            Debug.Log($"screenMousePosition - {screenMousePosition}, worldMousePosition - {worldMousePosition}");
        }
    }
}
