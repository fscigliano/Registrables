using System.Collections.Generic;
using UnityEngine;

namespace com.fscigliano.Registrables
{
    /// <summary>
    /// Creation Date:   28/02/2020 15:42:21
    /// Product Name:    Registrables
    /// Developers:      Franco Scigliano
    /// Description:     
    /// </summary>
    public abstract class ScriptableObjectRegisterer<TRegistrable, TRegistrableID> : ScriptableObject,
        IRegisterer<TRegistrable, TRegistrableID> where TRegistrableID : IRegistrableID
        where TRegistrable : IRegistrable<TRegistrableID>
    {
        #region Properties, Consts and Statics
        public List<TRegistrable> Registered
        {
            get { return _registered; }
        }
        public int Count
        {
            get { return _count; }
        }
        public TRegistrable this[int idx] => (idx < _registered.Count) ? _registered[idx] : default;
        public TRegistrable this[TRegistrableID id] => (_registeredByID.ContainsKey(id)) ? _registeredByID[id] : default;
        #endregion
        
        #region Variables
        protected Dictionary<TRegistrableID, TRegistrable> _registeredByID =
            new Dictionary<TRegistrableID, TRegistrable>();
        protected List<TRegistrable> _registered = new List<TRegistrable>();
        protected int _count = 0;
        #endregion
        
        #region Public API
        public bool IsType<T>(TRegistrableID registeredID) where T : TRegistrable
        {
            return _registeredByID[registeredID] is T;
        }
        public T GetInstance<T>(TRegistrableID registeredID) where T : class, TRegistrable
        {
            return _registeredByID[registeredID] as T;
        }
        public bool ItemExists(TRegistrableID registeredID)
        {
            return _registeredByID.ContainsKey(registeredID);
        }
        public bool Register(TRegistrable registeredItem)
        {
            if (registeredItem.referenceID == null || _registeredByID.ContainsKey(registeredItem.referenceID)) return false;
            _registeredByID.Add(registeredItem.referenceID, registeredItem);
            _registered.Add(registeredItem);
            _count++;
            ReactToRegistration(registeredItem);
            return true;
        }
        public bool Unregister(TRegistrable registeredItem)
        {
            if (!_registeredByID.ContainsKey(registeredItem.referenceID)) return false;
            ReactToUnregistration(registeredItem);
            if (registeredItem.referenceID != null)
                _registeredByID.Remove(registeredItem.referenceID);
            _registered.Remove(registeredItem);
            _count--;
            return true;
        }

        public void ResetValues()
        {
            _registered.Clear();
            _registeredByID.Clear();
            _count = 0;
        }

        #endregion

        #region Methods
        protected virtual void ReactToRegistration(TRegistrable registeredItem) { }
        protected virtual void ReactToUnregistration(TRegistrable registeredItem) { }
        #endregion
    }
}