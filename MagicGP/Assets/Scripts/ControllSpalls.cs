using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class ControllSpalls : MonoBehaviour
{

    private Camera _camera;

    public List<Vector3> pathPoints;
    public List<Vector3> mousePoints;
    [SerializeField] private string filePath = "diffindo.txt";


    void Start()
    {
        _camera = Camera.main;
        pathPoints = ReadPathPoints();
    }


    //[ContextMenu("ReadPathFile")]
    public List<Vector3> ReadPathPoints()
    {
        string file = File.ReadAllText(filePath);
        var path = JsonUtility.FromJson<Path>(file);

       
        for (int i = 0; i < path.waypoints.Length; i++)
        {
           pathPoints.Add( path.waypoints[i]);
        }

        return pathPoints;

    }


    void Update()
    {
        Vector3 screenMousePosition = Input.mousePosition;
        screenMousePosition.z = _camera.depth * -90;
        Vector3 worldMousePosition = _camera.ScreenToWorldPoint(screenMousePosition);

        if (Input.GetMouseButton(0))
        {
            mousePoints.Add(worldMousePosition);
        }
        else
        {
            ConSpall(pathPoints, mousePoints);
        }

    }



// Расстояние от p до прямой ab
public float Distance_to_line(Vector3 a, Vector3 b, Vector3 p)
{
    Vector3 ab = b - a;
    Vector3 ap = p - a;
    Vector3 ab_cross_ap = Vector3.Cross(ab, ap); 
    return (float)Math.Sqrt( Vector3.Dot(ab_cross_ap, ab_cross_ap) / Vector3.Dot(ab, ab));

}

void ConSpall(List<Vector3> path, List<Vector3> mouse)
    {
        int f = 0;
        int g = 0;
        for(int i = 1; i<path.Count; i++)
        {
            for (int k = 0; k < mouse.Count; k++)
            {
                float distance = Distance_to_line(path[i-1], path[i], mouse[k]);

                if (distance >= 20f)
                {
                    f++;

                }
                else
                {
                    g++;
                }
            }
        }
        Debug.Log($"Fail {f}, Good - {g}");

    }

[Serializable]
    public class Path
    {
        public Vector3[] waypoints;
    }
}

