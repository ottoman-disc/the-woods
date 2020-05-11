using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OttomanDisc.AI
{
    public class TempTest : MonoBehaviour
    {
        IMoveIntention moveIntention;

        private void Start()
        {
            moveIntention = GetComponent<IMoveIntention>();
            Transform playerT = FindObjectOfType<Player>().transform;

      
                moveIntention.SetTarget(playerT);
        }
    }
}