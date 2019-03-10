using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;


public class ARController : MonoBehaviour
{

    //list filled with the planes that ARCore detected in current frame
    private List<DetectedPlane> m_NewPlanes = new List<DetectedPlane>();

    public GameObject GridPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

         // Check that motion tracking is tracking.
        if (Session.Status != SessionStatus.Tracking)
        {
            const int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;

            return;
        }

        //plane detection and after this plane prefabs are instantiated
        Session.GetTrackables<DetectedPlane>(m_NewPlanes, TrackableQueryFilter.New);
        
        for(int i = 0; i < m_NewPlanes.Count; ++i)
        {
            GameObject grid = Instantiate(GridPrefab, Vector3.zero, Quaternion.identity, transform);

            grid.GetComponent<GridVisualizer>().Initialize(m_NewPlanes[i]);
        }

    }
}
