using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Unit
{
    public class Base : MonoBehaviour
    {
        private Dictionary<Type, UnitBehaviour> behaviours = new Dictionary<Type, UnitBehaviour>();
        
        public UnitBehaviour AddBehaviour<T>() where T : UnitBehaviour, new()
        {
            var behaviour = new T();
            behaviours.Add(typeof(T), behaviour);
            behaviour.Unit = this;
            return behaviour;
        }
        
        public UnitBehaviour GetBehaviour<T>() where T : UnitBehaviour
        {
            return behaviours[typeof(T)];
        }

        protected virtual void OnEnable()
        {
            foreach (var behaviour in behaviours.Values)
            {
                behaviour.Awake();
            }
        }

        protected virtual void Start()
        {
            foreach (var behaviour in behaviours.Values)
            {
                behaviour.Start();
            }
        }
        
        protected virtual void Update()
        {
            foreach (var behaviour in behaviours.Values)
            {
                behaviour.Update();
            }
        }

        protected virtual void OnDisable()
        {
            foreach (var behaviour in behaviours.Values)
            {
                behaviour.Destroy();
            }
        }
    }
    
    public interface UnitBehaviour
    {
        public Base Unit { get; set; }
        public void Awake();
        public void Start();
        public void Update();
        public void Destroy();
    }

    public class PlayerBehaviour : UnitBehaviour
    {
        public Base Unit { get; set; }
        public PlayerBase Player => Unit as PlayerBase;
        public virtual void Awake() {}

        public virtual void Start() {}

        public virtual void Update() {}

        public virtual void Destroy() {}
    }

    [Flags]
    public enum PlayerState
    {
        None = 0,
        Pitch = 1 << 0,
        Swing = 1 << 1,
    }
}