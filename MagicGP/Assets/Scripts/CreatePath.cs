using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreatePath : MonoBehaviour
{
    private Camera _camera;

    public GameObject Brush;
    public float BrushSize = 1f;
    public RenderTexture RTexture;

    [SerializeField] private List<Vector3> wayPoints;

    void Start()
    {
        _camera = Camera.main;
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 screenMousePosition = Input.mousePosition;
            screenMousePosition.z = _camera.depth * -90;
            Vector3 worldMousePosition = _camera.ScreenToWorldPoint(screenMousePosition);

            var go = Instantiate(Brush, worldMousePosition, Quaternion.identity, transform);
            go.transform.localScale = Vector3.one * BrushSize;

            
            wayPoints.Add(worldMousePosition);

            var path = new Path
            {
                waypoints = wayPoints.ToArray()
            };

            var file = JsonUtility.ToJson(path, true);
            File.WriteAllText($"diffindo.txt", file);

        }
    }

    [Serializable]
    public class Path
    {
        public Vector3[] waypoints;
    }
}
