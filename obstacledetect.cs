using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacledetect : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance =3f;
      [SerializeField]
    private LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
      
    Ray ray = new Ray(cam.transform.position,cam.transform.forward);
    RaycastHit hit;
    Physics.Raycast(ray,out hit,distance,mask);
}  
    }

