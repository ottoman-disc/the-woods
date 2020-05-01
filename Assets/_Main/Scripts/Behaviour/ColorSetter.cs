using UnityEngine;
using UnityEngine.U2D;

namespace OttomanDisc
{
    [RequireComponent(typeof(SpriteShapeRenderer))]
    public class ColorSetter : MonoBehaviour
    {
        public delegate void SetColorAction(Color color);
        public event SetColorAction OnSetColor;

        public void SetColorAndBroadcast(Color color)
        {
            SetColor(color);
            OnSetColor?.Invoke(color);
        }

        public void SetColor(Color color)
        {
            this.GetComponent<SpriteShapeRenderer>().material.color = color;
        }
    }
}
