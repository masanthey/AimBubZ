using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private new Camera camera;
    public float FOV;
    [SerializeField] private float maxZoomFOV = 15;
    [Range(0, 1)]
    [SerializeField] private float currentZoom;
    [SerializeField] private float sensitivity = 1;

    void Awake()
    {
        camera = GetComponent<Camera>();
        if (camera)
        {
            FOV = camera.fieldOfView;
        }
    }

    void Update()
    {
        currentZoom += Input.mouseScrollDelta.y * sensitivity * .05f;
        currentZoom = Mathf.Clamp01(currentZoom);
        camera.fieldOfView = Mathf.Lerp(FOV, maxZoomFOV, currentZoom);
    }

    public void SetFOV(float value)
    {
        FOV = value;
    }
}
