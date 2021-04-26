// -----------------------------------------------------------------------
// <copyright file="IBuilderOnProperyChanged.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    using Anori.Common;

    /// <summary>
    ///     The I Property Value Observer Builder With Notify Propery Changed interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderOnNotifyProperyChanged{TResult}}" />
    /// <seealso
    ///     cref="IPropertyObserverScheduler{TTarget}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderOnNotifyProperyChanged{TResult}}" />
    /// <seealso cref="IBuilderOnNotifyProperyChanged{TResult}" />
    public interface IBuilder<TResult> : IObserverBuilderBase<IBuilder<TResult>>,
                                                         IPropertyObserverScheduler<
                                                             IBuilderWithScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Value Observer On Notify Propery Changed.</returns>
        IPropertyObserver<TResult> Build();
    }
}