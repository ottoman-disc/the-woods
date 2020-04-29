using UnityEngine;
using UnityEngine.U2D;

public class Tree : PhotonSharedObject, IInteractable
{
    public void Interact()
    {
        GetComponent<SpriteShapeRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
