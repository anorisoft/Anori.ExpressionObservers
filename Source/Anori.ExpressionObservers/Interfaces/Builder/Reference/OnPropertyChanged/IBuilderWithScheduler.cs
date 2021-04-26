// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    using Anori.Common;

    /// <summary>
    /// The I Property Value Observer Builder With Notify Propery Changed And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithScheduler{TResult}}" />
    public interface IBuilderWithScheduler<TResult> :
        IObserverBuilderBase<IBuilderWithScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        /// Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderOnProperyChanged<TResult> Cached(LazyThreadSafetyMode safetyMode);

        /// <summary>
        /// Cacheds this instance.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderOnProperyChanged<TResult> Cached();

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>Property Value Observer On Notify Propery Changed.</returns>
        IGetterReferencePropertyObserver<TResult> Build();
    }
}