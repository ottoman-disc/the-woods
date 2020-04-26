﻿using UnityEngine;

public class Interactor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.GetComponent<IInteractable>().Interact();
    }
}
