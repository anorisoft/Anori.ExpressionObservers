// -----------------------------------------------------------------------
// <copyright file="IBuilderWithFallbackAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    using Anori.Common;

    /// <summary>
    ///     The I Property Value Observer Builder With Value Changed And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderOnValueChangedAndScheduler{TResult}}" />
    public interface IBuilderWithFallbackAndScheduler<TResult> :
        IObserverBuilderBase<IBuilderWithFallbackAndScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Value Observer On Notify Propery Changed.</returns>
        INotifyPropertyObserver<TResult> Build();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>The Property Value Observer Builder.</returns>
        IBuilderWithFallbackAndScheduler<TResult> Cached(LazyThreadSafetyMode safetyMode);

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithFallbackAndScheduler<TResult> Cached();

        /// <summary>
        ///     Defers this instance.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithFallbackAndDeferrerAndScheduler<TResult> Deferred();
    }
}