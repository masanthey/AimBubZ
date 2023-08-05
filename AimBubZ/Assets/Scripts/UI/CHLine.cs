using UnityEngine;
using UnityEngine.UI;
public class CHLine : MonoBehaviour
{
    public enum Direction
    {
        right,
        left,
        up,
        down,
    };
    public Direction LineDir;
    public bool IsVertical;
    private RectTransform lineRect;
    private Image lineImage;

    private void Start()
    {
        lineImage = GetComponent<Image>();
        lineRect = GetComponent<RectTransform>();
    }
    public void LineInitialize(float gap, float _long, float thickness, Color _color) 
    {
        Vector3 _LocalScale = new();
        Vector3 Position = new();

        lineImage.color = _color;
        
        if (LineDir == Direction.right) 
        {
            Position.x = gap;
            Position.z = 0;
            Position.y = 0;

            _LocalScale.y = thickness;
            _LocalScale.x = _long;
            _LocalScale.z = 1;

        }
        else if (LineDir == Direction.left)
        {
            Position.x = -gap;
            Position.z = 0;
            Position.y = 0;

            _LocalScale.y = thickness;
            _LocalScale.x = _long;
            _LocalScale.z = 1;
        }
        else if (LineDir == Direction.up)
        {
            Position.x = 0;
            Position.z = 0;
            Position.y = gap;

            _LocalScale.x = thickness;
            _LocalScale.y = _long;
            _LocalScale.z = 1;
        }
        else if (LineDir == Direction.down)
        {
            Position.x = 0;
            Position.z = 0;
            Position.y = -gap;

            _LocalScale.x = thickness;
            _LocalScale.y = _long;
            _LocalScale.z = 1;
        }

        lineRect.localScale = _LocalScale;
        lineRect.localPosition = Position;
    }

}
