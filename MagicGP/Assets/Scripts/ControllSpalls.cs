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
    [SerializeField] private string filePath;

    public GameObject Spell;
    public GameObject SpellNext;


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



    // Расстояние от точки мыши до прямой паттерна
    public float Distance_to_line(Vector3 p1, Vector3 p2, Vector3 m)
    {
        Vector3 p1p2 = p2 - p1;
        Vector3 p1m = m - p1;
        Vector3 p1p2_cross_p1m = Vector3.Cross(p1p2, p1m); 
        return (float)Math.Sqrt( Vector3.Dot(p1p2_cross_p1m, p1p2_cross_p1m) / Vector3.Dot(p1p2, p1p2));

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

                   if (distance >= 50f)
                        {
                            f++;
                        }
                   else
                        {
                    g++;
                        }
              }
        }
        if ( g > f && g > 1500f)
        {

            Spell.SetActive(false);
            SpellNext.SetActive(true);
        }
        Debug.Log($"Fail {f}, Good - {g}");

    }

[Serializable]
    public class Path
    {
        public Vector3[] waypoints;
    }
}

