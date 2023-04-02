using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ColorblindSystem : MonoBehaviour
{
    // Change in Viewport
    public float volumeWeight;
    public Volume colorblindVolume;
    public VolumeProfile[] colorblindProfiles;

    private static ColorblindSystem instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {        
        if (this.gameObject.GetComponent<Volume>())
        {
            colorblindVolume = this.gameObject.GetComponent<Volume>();
        }
        else
        {
            this.gameObject.AddComponent<Volume>();
            colorblindVolume = this.gameObject.GetComponent<Volume>();
        }
        
        colorblindVolume.profile = colorblindProfiles[1];
        colorblindVolume.isGlobal = true;
        colorblindVolume.priority = 20;
    }

    public void ChangeVolumeWeight(float value)
    {
        volumeWeight = value;
        colorblindVolume.weight = volumeWeight;
        if (value == 0)
        {
            colorblindVolume.enabled = false;
        }
        else
        {
            colorblindVolume.enabled = true;
        }
    }

    public void ChangeProfileDropdown(int which)
    {
        colorblindVolume.profile = colorblindProfiles[which];        
    }   
    
    public void ChangeProfileByMethod(int which)
    {
        colorblindVolume.profile = colorblindProfiles[which];
    }
}
