// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfNullT.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    /// <summary>
    ///     The I property reference observer builder With Action Of T Result interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfNullT<out TResult> : IObserverBuilderBase<IBuilderWithActionOfNullT<TResult>>,
                                                              ISchedulerBase<IBuilderWithActionOfNullT<TResult>>,
                                                              IDeferrerBase<IBuilderWithActionOfNullTAndDeferrer<
                                                                  TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        INotifyReferencePropertyObserver<TResult> Build();
    }
}