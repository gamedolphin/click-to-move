using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [HideInInspector]
    public System.Action<Vector2> OnPlayerClick;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var position = Input.mousePosition;
            var worldPosition = cam.ScreenToWorldPoint(position);

            OnPlayerClick?.Invoke(new Vector2(worldPosition.x, worldPosition.y));
        }
    }
}
