using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OttomanDisc.AI
{
    public class SearchingState : EntityState
    {
        [SerializeField] private GameObject scanZone;

        protected override void Start()
        {
            scanZone.SetActive(false);
        }

        public override void Enter()
        {
            base.Enter();

            scanZone.SetActive(true);
        }

        public override void Exit()
        {
            base.Exit();

            scanZone.SetActive(false);
        }
    }
}
