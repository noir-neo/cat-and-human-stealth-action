using UnityEngine;
using UniRx;
using System;

namespace Characters
{
    public class CharacterParameters : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        public float MoveSpeed => _moveSpeed;
    }
}
