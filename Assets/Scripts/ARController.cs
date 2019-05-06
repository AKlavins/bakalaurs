using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

#if UNITY_EDITOR
    // Set up touch input propagation while using Instant Preview in the editor.
    using Input = GoogleARCore.InstantPreviewInput;
#endif

public class ARController : MonoBehaviour
{

    //list filled with the planes that ARCore detected in current frame
    private List<DetectedPlane> m_NewPlanes = new List<DetectedPlane>();

    public GameObject GridPrefab;

    public GameObject Portal;

    public GameObject ARCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Exit the app when the 'back' button is pressed.
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

         // Check that motion tracking is tracking.
        if (Session.Status != SessionStatus.Tracking)
        {
            const int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;

            return;
        }

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //plane detection and after this plane prefabs are instantiated
        Session.GetTrackables<DetectedPlane>(m_NewPlanes, TrackableQueryFilter.New);
        
        // Vector3 camPositionInPortalSpace = transform.InverseTransformPoint(ARCamera.transform.position);


        // if(camPositionInPortalSpace.y > 0.0f)
        // {
        //instantiate a grid for each tracked plane in m_NewPlanes
        for(int i = 0; i < m_NewPlanes.Count; ++i)
        {
            GameObject grid = Instantiate(GridPrefab, Vector3.zero, Quaternion.identity, transform);

            //set the position of the grid and odify the vertices of the attached mesh
            grid.GetComponent<GridVisualizer>().Initialize(m_NewPlanes[i]);
        }
        
        // }

        //check if user touches the screen
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        //check if user touched any of the trcked planes
        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
                TrackableHitFlags.FeaturePointWithSurfaceNormal;

        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {

            //place the portal on top of the trcked plane that user touched

            //enable the portal
            Portal.SetActive(true);

            //create a new anchor
            Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);

            //set the position of the portal to be the same as the hit position
            Portal.transform.position = hit.Pose.position;
            Portal.transform.rotation = hit.Pose.rotation;

            //set portal to face the camera
            Vector3 cameraPosition = ARCamera.transform.position;

            //the portal should only rotate around the Y axis
            cameraPosition.y = hit.Pose.position.y;

            //rotate the portal to face the camera
            Portal.transform.LookAt(cameraPosition, Portal.transform.up);

            //ARCore will update the anchors accordingly to the world
            //attaching portal to the anchor
            Portal.transform.parent = anchor.transform;

        }

    }

}
