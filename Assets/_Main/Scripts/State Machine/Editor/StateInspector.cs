using UnityEditor;
using UnityEngine;

namespace OttomanDisc.StateMachine
{
    [CustomEditor(typeof(State), true)]
    public class StateInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (!EditorApplication.isPlaying) return;

            State inspectedState = (State)target;

            if (inspectedState.enabled == true) return;

            if (GUILayout.Button("Set State"))
            {
                StateManager stateManager = inspectedState.GetComponent<StateManager>();

                stateManager.SetState(inspectedState);
            }
        }
    }
}
