﻿namespace ExtEvents
{
    using System;
    using System.Runtime.CompilerServices;
    using UnityEngine;
    using UnityEngine.Scripting;

    /// <summary>
    /// A class that allows to serialize any object through UnityEngine.JsonUtility.
    /// Without this class, Vector2 or int passed to JsonUtility won't be serialized properly.
    /// Also, by exposing 'object Value' it is possible to deserialize the object without knowing its type.
    /// </summary>
    public abstract class ArgumentHolder
    {
        [Preserve]
        public abstract unsafe void* ValuePointer { get; }

        [Preserve]
        public abstract unsafe object Value { get; }
    }

    [Serializable]
    public class ArgumentHolder<T> : ArgumentHolder
    {
        [SerializeField] private T _value;

        [Preserve]
        public override unsafe void* ValuePointer => Unsafe.AsPointer(ref _value);

        [Preserve]
        public override object Value => _value;

        public ArgumentHolder() { }

        public ArgumentHolder(T value)
        {
            _value = value;
        }
    }
}