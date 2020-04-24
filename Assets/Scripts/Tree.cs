using UnityEngine;

public class Tree : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log(this.name + ": You interacted with me! Saucy");
    }
}
