﻿using OttomanDisc.Utility;
using UnityEngine;
using UnityEngine.Events;

namespace OttomanDisc.AI
{
    public class UnityEventMoveIntention : MonoBehaviour, IMoveIntention
    {
        [SerializeField] private Vector3Event OnMove;
        [SerializeField] private UnityEvent OnStop;

        public void Move(Vector3 direction) => OnMove.Invoke(direction);

        public void Stop() => OnStop.Invoke();

        public void SetTarget(Transform transform)
        {
            throw new System.NotImplementedException();
        }

        public void SetTargetPosition(Vector3 position)
        {
            throw new System.NotImplementedException();
        }
    }
}
