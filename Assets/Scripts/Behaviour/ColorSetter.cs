using UnityEngine;
using UnityEngine.U2D;

namespace OttomanDisc
{
    public class ColorSetter : MonoBehaviour
    {
        public delegate void SetColorAction(Color color);
        public event SetColorAction OnSetColor;

        public void SetColor(Color color)
        {
            this.GetComponent<SpriteShapeRenderer>().material.color = color;
            OnSetColor(color);
        }
    }
}
