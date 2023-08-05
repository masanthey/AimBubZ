using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettingsData : MonoBehaviour
{
    private CameraController _cameraController;
    private CameraZoom _cameraZoom;

    private void Start()
    {
        _cameraController = GetComponent<CameraController>();
        _cameraZoom = GetComponent<CameraZoom>();

        if (PlayerPrefs.HasKey("Sensitivity"))
            GetData();
        else
            ResetData();
    }

    private void GetData() 
    {
        _cameraController.Sensitivity = PlayerPrefs.GetFloat("Sensitivity");
        _cameraController.Smoothing = PlayerPrefs.GetFloat("Smoothing");
        _cameraZoom.FOV = PlayerPrefs.GetFloat("FOV");
    }
    public void SetData() 
    {
        PlayerPrefs.SetFloat("Sensitivity", _cameraController.Sensitivity);
        PlayerPrefs.SetFloat("Smoothing", _cameraController.Smoothing);
        PlayerPrefs.SetFloat("FOV", _cameraZoom.FOV);
    }
    public void ResetData() 
    {
        DefaultCameraData Defaultdata = new();
        _cameraController.Sensitivity = Defaultdata.Sensitivity;
        _cameraController.Smoothing = Defaultdata.Smoothing;
        _cameraZoom.FOV = Defaultdata.FOV;
        PlayerPrefs.SetFloat("Sensitivity", Defaultdata.Sensitivity);
        PlayerPrefs.SetFloat("Smoothing", Defaultdata.Smoothing);
        PlayerPrefs.SetFloat("FOV", Defaultdata.FOV);
    }
}

public class DefaultCameraData
{
    public float Smoothing = 1f;
    public float Sensitivity = 2f;
    public float FOV = 60f;
}
