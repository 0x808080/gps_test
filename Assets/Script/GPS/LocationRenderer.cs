using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationRenderer : MonoBehaviour {

    public GPSUpdater updater;
    public Text text;

    void Update()
    {
        if(updater == null)
        {
            return;
        }

        text.text = updater.Status.ToString()
                  + "\n" + "lat:" + updater.Location.latitude.ToString()
                  + "\n" + "lng:" + updater.Location.longitude.ToString();
    }
}
