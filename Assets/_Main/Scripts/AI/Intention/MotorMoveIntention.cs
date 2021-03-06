﻿using UnityEngine;

namespace OttomanDisc.AI
{
    public class MotorMoveIntention : MonoBehaviour, IMoveIntention
    {
        [SerializeField] Motor motor;

        public void Move(Vector3 direction)
        {
            motor.Move(direction);
        }

        public void Stop()
        {
            motor.Stop();
        }
    }
}
