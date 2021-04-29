// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderOnProperyChangedWithScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    using Anori.Common;

    /// <summary>
    /// The I Property Value2 Observer Builder With Notify Propery Changed And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderOnProperyChangedWithScheduler{TResult}}" />
    public interface IBuilderWithScheduler<TResult> :
        IObserverBuilderBase<IBuilderWithScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        /// Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Value2 Property Observer Builder.
        /// </returns>
        IBuilderWithScheduler<TResult> Cached(LazyThreadSafetyMode safetyMode);

        /// <summary>
        /// Cacheds this instance.
        /// </summary>
        /// <returns>
        ///     The Value2 Property Observer Builder.
        /// </returns>
        IBuilderWithScheduler<TResult> Cached();

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>Property Value2 Observer On Notify Propery Changed.</returns>
        IGetterReferencePropertyObserver<TResult> Build();
    }
}