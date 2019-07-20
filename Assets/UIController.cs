using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public ReferenceController rc;

    public Slider pitchSlider;
    public Slider yawSlider;
    public Slider powerSlider;

    public void Start()
    {
        //Adds a listener to the sliders and invokes a method when the value changes.
        pitchSlider.onValueChanged.AddListener(delegate { PitchSliderChanged(); });
        yawSlider.onValueChanged.AddListener(delegate { YawSliderChanged(); });
        powerSlider.onValueChanged.AddListener(delegate { PowerSliderChanged(); });
    }

    // Invoked when the value of the slider changes.
    public void PitchSliderChanged()
    {
        //rc.cannon.transform.rotation = Quaternion.Euler(pitchSlider.value, rc.cannon.transform.rotation.y, rc.cannon.transform.rotation.z);
        rc.cannon.SliderChanged(new Vector3(pitchSlider.value, rc.cannon.currentRot.y, rc.cannon.currentRot.z));
    }
    // Invoked when the value of the slider changes.
    public void YawSliderChanged()
    {
        //rc.cannon.transform.rotation = Quaternion.Euler(rc.cannon.transform.rotation.x, rc.cannon.transform.rotation.y, yawSlider.value);
        rc.cannon.SliderChanged(new Vector3(rc.cannon.currentRot.x, rc.cannon.currentRot.y, yawSlider.value));
    }
    // Invoked when the value of the slider changes.
    public void PowerSliderChanged()
    {
        rc.cannon.power = powerSlider.value;
    }

    public float GetPower()
    {
        return powerSlider.value;
    }
    public float GetPitch()
    {
        return pitchSlider.value;
    }
    public float GetYaw()
    {
        return yawSlider.value;
    }

    public void SetPower(float val)
    {
        powerSlider.value = val;
    }
    public void SetPitch(float val)
    {
        pitchSlider.value = val;
    }
    public void SetYaw(float val)
    {
        yawSlider.value = val;
    }


}
