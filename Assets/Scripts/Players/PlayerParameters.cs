using UnityEngine;
using UniRx;
using System;

namespace Players
{
    public class PlayerParameters : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        public float MoveSpeed => _moveSpeed;
    }
}
