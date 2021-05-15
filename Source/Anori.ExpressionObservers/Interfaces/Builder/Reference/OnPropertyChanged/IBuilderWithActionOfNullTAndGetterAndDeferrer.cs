// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfNullTAndGetterAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    /// <summary>
    /// The Builder With Action Of Null T And Getter And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfNullTAndGetterAndDeferrer<out TResult> :
        IObserverBuilderBase<IBuilderWithActionOfNullTAndGetterAndDeferrer<TResult>>,
    ISchedulerBase<IBuilderWithActionOfNullTAndGetterAndDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterReferencePropertyObserverWithDeferrer<TResult> Build();
    }
}