using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OttomanDisc.AI
{
    public class SearchingState : EntityState
    {
        [SerializeField] private GameObject scanZone;

        public override void Enter()
        {
            base.Enter();

            print("Activating Search Zone");

            scanZone.SetActive(true);
        }

        public override void Exit()
        {
            base.Exit();

            scanZone.SetActive(false);
        }
    }
}
