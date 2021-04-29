// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderOnValueChanged.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    using Anori.Common;

    /// <summary>
    ///     The I Property Value2 Observer Builder With Value2 Changed interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderOnValueChanged{TResult}}" />
    /// <seealso
    ///     cref="IPropertyObserverScheduler{TTarget}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderOnValueChanged{TResult}}" />
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderOnValueChanged{TParameter1, TResult}}" />
    /// <seealso
    ///     cref="IPropertyObserverScheduler{TTarget}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderOnValueChanged{TParameter1, TResult}}" />
    public interface IBuilderWithFallback<TResult> :
        IObserverBuilderBase<IBuilderWithFallback<TResult>>,
        IPropertyObserverScheduler<IBuilderWithFallbackAndScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Value2 Observer On Notify Propery Changed.</returns>
        INotifyPropertyObserver<TResult> Build();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>The Property Value2 Observer Builder.</returns>
        IBuilderWithFallback<TResult> Cached(LazyThreadSafetyMode safetyMode);

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Value2 Observer Builder.
        /// </returns>
        IBuilderWithFallback<TResult> Cached();

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>
        ///     The Property Value2 Observer Builder.
        /// </returns>
        IBuilderWithFallbackAndDeferrer<TResult> Deferred();
    }
}