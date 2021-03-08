using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camcontrol : MonoBehaviour
    
{
    //camera follow variable
    public Transform playerTransform;
    private Vector3 _camoffset;
    [Range(0.01f, 1.0f)]
    public float smoothness = 0.5f;

    //zoom camera variable
    private Camera cam;
    private float targetZoom;
    private float zoomFactor = 3f;
    [SerializeField] private float zoomLerpSpeed = 10;


    // Start is called before the first frame update
    void Start()
    {
        _camoffset = transform.position - playerTransform.position;
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }
    private void LateUpdate()
    {
        Vector3 newPositio = playerTransform.position + _camoffset;
        transform.position = Vector3.Slerp(transform.position, newPositio, smoothness);
    }
    private void Update()
    {
        useWheel();
    }
    public void useWheel()
    {
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");
        targetZoom -= scrollData * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, 2f, 8f);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);
    }
}
