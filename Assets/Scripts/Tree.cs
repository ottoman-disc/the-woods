using UnityEngine;
using UnityEngine.U2D;

public class Tree : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Material mat = GetComponent<SpriteShapeRenderer>().material;
        if (mat != null) mat.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
