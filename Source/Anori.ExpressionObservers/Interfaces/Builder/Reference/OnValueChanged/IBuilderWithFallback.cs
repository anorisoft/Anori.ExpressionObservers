// -----------------------------------------------------------------------
// <copyright file="IBuilderWithFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    /// <summary>
    ///     The I property value observer builder With Value Changed interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithFallback<out TResult> : IObserverBuilderBase<IBuilderWithFallback<TResult>>,
                                                         ISchedulerBase<IBuilderWithFallback<TResult>>,
                                                         IDeferBase<IBuilderWithFallbackAndDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Value Observer On Notify Property Changed.</returns>
        INotifyPropertyObserver<TResult> Build();
    }
}