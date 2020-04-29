using UnityEngine;

namespace OttomanDisc
{
    [RequireComponent(typeof(Player))]
    public class PhotonTaker : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Collider2D col = collision.collider;

            PhotonSharedObject photonSharedObject = col.GetComponent<PhotonSharedObject>();
            if (photonSharedObject != null) photonSharedObject.Take(this.gameObject);
        }
    }
}
