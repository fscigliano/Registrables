namespace com.fscigliano.Registrables
{
    /// <summary>
    /// Creation Date:   28/02/2020 15:46:31
    /// Product Name:    Registrables
    /// Developers:      Franco Scigliano
    /// Description:     
    /// </summary>
    public interface IRegistrable<TRegistrableID>:IRegistrableBase where TRegistrableID : IRegistrableID
    {
        #region Public API
        TRegistrableID referenceID { get; }
        #endregion
    }
}