using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraColor : MonoBehaviour
{
    private Camera cam;
    private HueShift hueShift = new HueShift();

    [SerializeField]
    private float hueShiftSpeed = 0.5f;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        hueShift.Initialize(cam.backgroundColor);
        cam.backgroundColor = hueShift.Randomize();
    }

    private void LateUpdate()
    {
        cam.backgroundColor = hueShift.NextColor(hueShiftSpeed);
    }
}
