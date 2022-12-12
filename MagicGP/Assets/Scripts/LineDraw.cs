using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    public GameObject Brush;
    public float BrushSize = 0.1f;
    public RenderTexture RTexture;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //cast a ray to the plane
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(Ray, out hit))
            {
                //instanciate a brush
                var go = Instantiate(Brush, hit.point, Quaternion.identity, transform);
                go.transform.localScale = Vector3.one * BrushSize;
            }

        }
    }
}
