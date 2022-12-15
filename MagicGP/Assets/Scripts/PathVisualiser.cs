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
    public RenderTexture RTexture;

    private List<Vector3> wayPoints;
    [SerializeField] private string filePath = "diffindo.txt";
    

    [ContextMenu("ReadPathFile")]
    public void ReadPathFile()
    {
        string file = File.ReadAllText(filePath);
        var path = JsonUtility.FromJson<Path>(file);

        //var wayPoints = JsonConvert.DeserializeObject<List<_>>(file);
        



        for (int i = 0; i < path.waypoints.Length; i++)
        {
            var wayPoint = wayPoints[i];
            var go = Instantiate(Brush, wayPoint, Quaternion.identity, transform);
            go.transform.localScale = Vector3.one * BrushSize;
        }
        Debug.Log("Done");
        
    }

    [Serializable]
    public class Path
    {
        public Vector3[] waypoints;
    }
}