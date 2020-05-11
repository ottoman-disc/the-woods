using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OttomanDisc.AI
{
    public class BatBrain : MonoBehaviour
    {
        private Vector3 startingPosition;

        private Transform currentTarget;

        private IMotorAIController moveIntention;

        private void Awake()
        {
            startingPosition = this.transform.position;
            moveIntention = GetComponent<IMotorAIController>();
        }

        // Trigger Callbacks
        private void OnTriggerEnter(Collider other)
        {
            if (currentTarget != null) return; // If already has a target, ignore

            if (other.GetComponent<Player>() != null)
            {
                SetTarget(other.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform == currentTarget) GoHome();
        }

        // Behaviour
        private void SetTarget(Transform target)
        {
            currentTarget = target;
            moveIntention.SetTarget(target);
        }

        private void GoHome()
        {
            currentTarget = null;
            moveIntention.SetTargetPosition(startingPosition);
        }
    }

}
