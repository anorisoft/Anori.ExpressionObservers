// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserver{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    /// The I Getter Value Property Observer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyObserverBase{Anori.ExpressionObservers.Interfaces.IGetterValuePropertyObserver{TResult}}" />
    public interface IGetterValuePropertyObserver<TResult> : 
        IPropertyObserverBase<IGetterValuePropertyObserver<TResult>>
        where TResult : struct
    {

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>The Value.</returns>
        TResult? GetValue();
    }
}