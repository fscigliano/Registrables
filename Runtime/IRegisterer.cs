namespace com.fscigliano.Registrables
{
    /// <summary>
    /// Creation Date:   28/02/2020 15:47:10
    /// Product Name:    Registrables
    /// Developers:      Franco Scigliano
    /// Description:     
    /// </summary>
    public interface IRegisterer<TRegistrable, TRegistrableID>:IRegistererBase where TRegistrable : IRegistrable<TRegistrableID>
        where TRegistrableID : IRegistrableID
    {
        #region Public API
        bool Register(TRegistrable registeredItem);
        bool Unregister(TRegistrable registeredItem);
        #endregion
    }
}