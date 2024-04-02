using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SugARTechnology.Scripts.Core 
{
    public abstract class Entity : MonoBehaviour
    {
        private float headOffset = 1.5f;
        public Vector3 HeadPosition => transform.position + Vector3.up * headOffset;
    }

}

