// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfNullTAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    public interface IBuilderWithActionOfNullTAndDeferrer<out TResult> : IObserverBuilderBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>,
                                                                          IObserverBuilderSchedulerBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>

        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterReferencePropertyObserverWithDeferrer<TResult> Build();

        /// <summary>
        /// Withes the getter.
        /// </summary>
        /// <returns></returns>
        IBuilderWithActionOfNullTAndGetterAndDeferrer<TResult> WithGetter();

    }
}