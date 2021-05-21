// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfNullTAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    /// <summary>
    ///     The I property reference observer builder With Action Of T Result interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfNullTAndGetter<out TResult> :
        IObserverBuilderBase<IBuilderWithActionOfNullTAndGetter<TResult>>,
        ISchedulerBase<IBuilderWithActionOfNullTAndGetter<TResult>>,
        IDeferrerBase<IBuilderWithActionOfNullTAndGetterAndDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IGetterReferencePropertyObserver<TResult> Build();
    }
}