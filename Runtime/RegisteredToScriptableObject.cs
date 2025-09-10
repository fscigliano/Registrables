using UnityEngine;

namespace com.fscigliano.Registrables
{
    /// <summary>
    /// Creation Date:   09/02/2020 17:39:47
    /// Product Name:    Registrables
    /// Developers:      Franco Scigliano
    /// Description:     
    /// </summary>
    public abstract class RegisteredToScriptableObject<TRegisterer, 
        TRegistrable, TRegistrableId> : RegisteredBase<TRegistrableId>,
        IRegistrable<TRegistrableId>
        where TRegisterer : IRegisterer<TRegistrable, TRegistrableId>
        where TRegistrable : class, IRegistrable<TRegistrableId>
        where TRegistrableId : IRegistrableID
    {
        #region Inspector Fields
        [Header("Protected"), SerializeField] protected TRegisterer _registerList;
        #endregion
 
        #region Methods
        protected override void Unregister()
        {
            if (_registerList.Unregister(((Object) this) as TRegistrable))
            {
                OnRegisteredSuccess();
            }
            else
            {
                OnRegisteredFailed();
            }
        }

        protected override void Register()
        {
            if (_registerList.Register(((Object) this) as TRegistrable))
            {
                OnUnregisteredSuccess();
            }
            else
            {
                OnUnregisteredFailed();
            }
        }
        #endregion
    }
}