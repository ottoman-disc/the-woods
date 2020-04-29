using Photon.Pun;
using UnityEngine;
using UnityEngine.U2D;

public class Tree : PhotonSharedObject, IInteractable
{
    public void Interact(GameObject interactor)
    {
        GetComponent<SpriteShapeRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        if (interactor.GetComponent<PhotonView>().IsMine) Take(new PhotonView());
    }
}
