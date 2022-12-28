using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using static ControllSpalls;


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

    public float Distance_to_line(Vector3 p1, Vector3 p2, Vector3 m)
    {
        Vector3 p1p2 = p2 - p1;
        Vector3 p1m = m - p1;
        Vector3 p1p2_cross_p1m = Vector3.Cross(p1p2, p1m); 
        return (float)Math.Sqrt( Vector3.Dot(p1p2_cross_p1m, p1p2_cross_p1m) / Vector3.Dot(p1p2, p1p2));

    }

    public float Distance_two_point(Vector3 p1, Vector3 p2)
    {
        return (float)Math.Sqrt(Math.Pow(p2[0] - p1[0], 2) + Math.Pow(p2[1] - p1[1], 2) + Math.Pow(p2[2] - p1[2], 2));

    }

    void ConSpall(List<Vector3> path, List<Vector3> mouse)
    {
        int fail = 0;
        int good = 0;
        
        for (int i = 1; i < path.Count; i++)
        {
            for (int k = 0; k < mouse.Count; k += 50)
            {
                float first_point = Distance_two_point(path[0], mouse[0]);
                if (first_point <= 3f )
                {
                    float distance = Distance_to_line(path[i - 1], path[i], mouse[k]);
                    if (distance >= 15f) 
                    { 
                        fail++; 
                    }
                    else 
                    { 
                        good++; 
                    }
                    if (good > fail)
                    {
                        float last_point = Distance_two_point(path[path.Count - 1], mouse[mouse.Count - 1]);
                        if (last_point <= 3f)
                        {
                            Spell.SetActive(false);
                            SpellNext.SetActive(true);
                        }
                        else  { mouse.Clear(); }
                    }
                    else  {  mouse.Clear(); }
                }
                else { mouse.Clear(); }
            }
        } 
    }

[Serializable]
    public class Path
    {
        public Vector3[] waypoints;
    }
}

