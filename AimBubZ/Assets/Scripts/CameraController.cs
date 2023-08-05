using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Char;
    public float Sensitivity = 2f;
    public float Smoothing = 1.5f;

    Vector2 velocity;
    Vector2 frameVelocity;

    [SerializeField] private MenuControl MC;

    void Update()
    {
        if (MC.Paused)
        {
            Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * Sensitivity);
            frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / Smoothing);
            velocity += frameVelocity;
            velocity.y = Mathf.Clamp(velocity.y, -90, 90);

            transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            Char.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
        }
    }

    public void SetSensitivity(float value) 
    {
        Sensitivity = value;
    }
    public void SetSmoothing(float value)
    {
        Smoothing = value;
    }


}