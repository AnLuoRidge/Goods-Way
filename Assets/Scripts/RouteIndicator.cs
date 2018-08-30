using UnityEngine;
using Vuforia;
using System.Collections.Generic;
using DigitalRuby.AnimatedLineRenderer;
using System;
using System.Linq;

public class RouteIndicator : MonoBehaviour
{

    public PhasorScript phasorScript;
    private string[] markers = {"marsbox_top", "marsbox_left"};

    void Start()
    {
        phasorScript = GetComponent<PhasorScript>();
    }
    // Update is called once per frame
    void Update()
    {

        StateManager sm = TrackerManager.Instance.GetStateManager();
        // This gets all the trackable currently tracked
        // so if you are looking at 3 and 5 it will contain both
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

        Debug.Log(activeTrackables);
        TrackableBehaviour[] activeTrackableArray = activeTrackables.ToArray();
        
        if (activeTrackables.Count() > 1)
        {
            // foreach (TrackableBehaviour tb in activeTrackables) {
            // As you iterate, you compare with current game object name
            // if you have 3 and 5 and target object is 5 then you get a match.
            // if( tb.TrackableName == currentObject.name) { }

            var markerIndexOne = Array.IndexOf(markers, activeTrackableArray[0].name);
            var markerIndexTwo = Array.IndexOf(markers, activeTrackableArray[1].name);
            GameObject des;
            GameObject src;
            if (markerIndexOne > markerIndexTwo)
            {
                des = activeTrackableArray[0].gameObject;
                src = activeTrackableArray[1].gameObject;
            }
            else
            {
                src = activeTrackableArray[1].gameObject;
                des = activeTrackableArray[0].gameObject;
            }
			// get child from image target
			phasorScript.Source = src;//mTrackableBehaviour.transform.GetChild[0].gameObject;
            phasorScript.Fire(des.transform.position);
        }
    }
}