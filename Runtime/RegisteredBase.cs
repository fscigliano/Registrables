using UnityEngine;

namespace com.fscigliano.Registrables
{
    /// <summary>
    /// Creation Date:   09/02/2020 17:39:47
    /// Product Name:    Registrables
    /// Developers:      Franco Scigliano
    /// Description:     
    /// </summary>
    public abstract class RegisteredBase<TRegistrableId> : MonoBehaviour where TRegistrableId : IRegistrableID
    {
         #region Inspector Fields
         [SerializeField] protected TRegistrableId _referenceID;
         #endregion

         #region Properties, Consts and Statics
         protected virtual bool CanRegister => true;
         protected virtual bool CanUnregister => true;

         public TRegistrableId referenceID => _referenceID;

         protected virtual bool RegisterOnEnable => true;
         #endregion

         #region Methods
         protected virtual void HandleOnDisable()
         {
         }
         protected void Awake()
         {
             if (!RegisterOnEnable && CanRegister)
             {
                 Register();
             }
             HandleAwake();
         }

         protected virtual void HandleAwake()
         {
             
         }
         protected virtual void HandleOnDestroy()
         {
             
         }
         protected void OnDestroy()
         {
             HandleOnDestroy();
             if (!RegisterOnEnable && CanUnregister)
             {
                 Unregister();
             }
         }

         protected void OnEnable()
         {
             if (RegisterOnEnable && CanRegister)
             {
                 Register();
             }
             HandleOnEnable();
         }

         protected virtual void HandleOnEnable()
         {
         }

         protected void OnDisable()
         {
             HandleOnDisable();
             if (RegisterOnEnable && CanUnregister)
             {
                 Unregister();
             }
         }
         protected abstract void Register();
         protected abstract void Unregister();
         protected virtual void OnRegisteredSuccess()
         {
            
         }
         protected virtual void OnRegisteredFailed()
         {
            
         }
         protected virtual void OnUnregisteredSuccess()
         {
            
         }
         protected virtual void OnUnregisteredFailed()
         {
            
         }
         #endregion
    }
}