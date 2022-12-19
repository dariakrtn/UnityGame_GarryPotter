using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

using System.Threading;
using System.Drawing;
using UnityEngine.UIElements;
using System.Reflection;

public class CreatePath : MonoBehaviour
{
    private Camera _camera;

    public GameObject Brush;
    public float BrushSize = 1f;

    [SerializeField] private List<Vector3> wayPoints ;


    void Start()
    {
        _camera = Camera.main;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screenMousePosition = Input.mousePosition;
            screenMousePosition.z = _camera.depth * -90;
            Vector3 worldMousePosition = _camera.ScreenToWorldPoint(screenMousePosition);

            wayPoints.Add(worldMousePosition);

            
            var go = Instantiate(Brush, worldMousePosition, Quaternion.identity, transform);
            go.transform.localScale = Vector3.one * BrushSize;
        }

        var path = new Path
        {
            waypoints = wayPoints.ToArray()
        };

        var file = JsonUtility.ToJson(path, true);
        File.WriteAllText($"incendio.txt", file);


    }

    [Serializable]
    public class Path
    {
        public Vector3[] waypoints;
    }
}
