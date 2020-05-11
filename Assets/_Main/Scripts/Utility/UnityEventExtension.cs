﻿using System;
using UnityEngine;
using UnityEngine.Events;

namespace OttomanDisc.Utility
{
    [Serializable]
    public class Vector3Event : UnityEvent<Vector3> { }

    [Serializable]
    public class TransformEvent : UnityEvent<Transform> { }
}
