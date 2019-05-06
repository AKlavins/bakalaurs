using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleARCore;

public class MenuScene : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float fadeInSpeed = 0.33f;

    private void Start()
    {
        //grab the only CanvasGroup in the scene
        fadeGroup = FindObjectOfType<CanvasGroup>();

        //Start with a white screen
        fadeGroup.alpha = 1;
    }

    private void Update()
    {
        //Fade-in
        fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;
    }

    //method to turn on/off plane visualization 
    public void VisualizePlanes(bool showPlanes)
    {
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag("Plane"))
        {
            Renderer r = plane.GetComponent<Renderer>();
            GridVisualizer t = plane.GetComponent<GridVisualizer>();
            r.enabled = showPlanes;
            t.enabled = showPlanes;
        }
    }

    //Button
    public void OnPlayClick()
    {
        SceneManager.LoadScene("PortalScene");
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void OnVisualizeOff()
    {
        VisualizePlanes(false);
    }

    public void OnVisualizeOn()
    {
        VisualizePlanes(true);
    }

}
