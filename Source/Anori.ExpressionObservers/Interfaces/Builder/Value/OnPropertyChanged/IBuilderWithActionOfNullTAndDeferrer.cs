// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfNullTAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The Builder With Action Of Null T And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfNullTAndDeferrer<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>,
        ISchedulerBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IGetterValuePropertyObserverWithDeferrer<TResult> Build();
    }
}