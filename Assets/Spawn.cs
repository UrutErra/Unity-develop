using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject objectPrefab;
    public TrackableType type;

    ARRaycastManager raycastManager;
    List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(raycastManager.Raycast(Input.GetTouch(0).position,hitResults, TrackableType.All))
            {
                Instantiate(objectPrefab, hitResults[0].pose.position, Quaternion.identity);
            }
        }
    }
}
