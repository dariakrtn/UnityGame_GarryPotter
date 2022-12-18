using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PathVisualiser : MonoBehaviour
{
    public GameObject Brush;
    public float BrushSize = 1f;

    [SerializeField] private string filePath = "diffindo.txt";

    public void Start()
    {
        ReadPathFile();
    }

    [ContextMenu("ReadPathFile")]
    public void ReadPathFile()
    {
        string file = File.ReadAllText(filePath);
        var path = JsonUtility.FromJson<Path>(file);

        Debug.Log(path);

        //List < Vector3 > points = new List < Vector3 >();
        //List<Vector3> newPoints = new List<Vector3>();
        //for (int i = 0; i < path.waypoints.Length; i++)
        //{
        //    var wayPoint = path.waypoints[i];
        //    points.Add(wayPoint);
        //}

        //newPoints = DistancePoint(points);
        for (int i = 0; i < path.waypoints.Length; i++)
        {
            var wayPoint = path.waypoints[i];
            var go = Instantiate(Brush, wayPoint, Quaternion.identity, transform);
            go.transform.localScale = Vector3.one * BrushSize;
        }
        
        
    }


    [Serializable]
    public class Path
    {
        public Vector3[] waypoints;
    }
}