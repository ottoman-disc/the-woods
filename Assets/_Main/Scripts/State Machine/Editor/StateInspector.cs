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

            State inspectedState = (State)target;

            if (!EditorApplication.isPlaying)
            {
                if (inspectedState.enabled == true)
                {
                    Debug.LogWarning("State must begin disabled", this);
                    inspectedState.enabled = false;
                }
                return;
            }

            if (inspectedState.enabled == true) return;

            GUILayout.Space(10);

            if (GUILayout.Button("Set State"))
            {
                StateManager stateManager = inspectedState.GetComponent<StateManager>();

                stateManager.SetState(inspectedState);
            }
        }
    }
}
