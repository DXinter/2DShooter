using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public abstract class Dependency : MonoBehaviour, IDependency
    {
        public event Action OnInit;

        private readonly List<IDependency> _dependencies = new List<IDependency>();

        public bool IsInitializing { get; private set; }

        public bool IsInitialized { get; private set; }

        private bool _dependenciesPrepared;

        private void OnEnable()
        {
            if (!_dependenciesPrepared)
            {
                PrepareDependencies();
                _dependenciesPrepared = true;
            }

            InternalOnEnable();
            Subscribe();
            Init();
        }

        private void OnDisable()
        {
            Unsubscribe();
            InternalOnDisable();
        }

        private void Subscribe()
        {
            foreach (var item in _dependencies)
            {
                item.OnInit += Init;
            }
        }

        private void Unsubscribe()
        {
            foreach (var item in _dependencies)
            {
                item.OnInit -= Init;
            }
        }

        protected virtual void PrepareDependencies()
        {
        }

        protected virtual void InternalOnEnable()
        {
        }

        protected virtual void InternalOnDisable()
        {
        }

        protected virtual void Init()
        {
            if (!DependenciesResolved())
            {
                return;
            }

            if (IsInitialized || IsInitializing)
            {
                return;
            }

            IsInitializing = true;

            InternalInit();
        }

        protected virtual void InternalInit()
        {
            InitializationDone();
        }

        protected void InitializationDone()
        {
            IsInitializing = false;
            IsInitialized = true;
            OnInit?.Invoke();
        }

        protected float Progress => _dependencies.Count(x => x.IsInitialized) / (float)_dependencies.Count;

        protected void AddDependency(IDependency dependency)
        {
            if (_dependencies.Contains(dependency)) return;

            _dependencies.Add(dependency);
        }

        protected bool DependenciesResolved()
        {
            foreach (var item in _dependencies)
            {
                if (!item.IsInitialized)
                {
                    return false;
                }
            }

            return true;
        }
    }
}