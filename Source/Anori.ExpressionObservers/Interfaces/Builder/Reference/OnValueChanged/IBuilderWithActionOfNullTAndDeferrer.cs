// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfNullTAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    /// <summary>
    ///     The I Builder With Action Of Null T And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfNullTAndDeferrer<out TResult> :
        IObserverBuilderBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>,
        ISchedulerBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        INotifyReferencePropertyObserverWithDeferrer<TResult> Build();
    }
}