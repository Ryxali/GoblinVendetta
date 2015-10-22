using UnityEngine;
using System.Collections;

public class Toggler : MonoBehaviour {

    public GameObject on;
    public GameObject off;
    public AudioListener listener;
    private bool value = true;
    public void onToggle()
    {
        value = !value;
        on.SetActive(value);
        off.SetActive(!value);
        AudioListener.volume = (value ? 1.0f : 0.0f);
        //listener.enabled = value;
        
    }
}
