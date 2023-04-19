using UnityEngine;

public class HueShift
{
    private float hueValue = 0.0f;
    private float satValue = 0.0f;
    private float brightValue = 0.0f;

    public void Initialize(Color col)
    {
        Color.RGBToHSV(col,out hueValue, out satValue, out brightValue);
    }

    public Color NextColor(float speed)
    {
        hueValue = hueValue + speed*Time.deltaTime;
        if (hueValue > 1) {
            hueValue = 0.0f;
        }

        if (hueValue < 0.0f) {
            hueValue = 1.0f;
        }

        return Color.HSVToRGB(hueValue,satValue,brightValue);
    }
}
