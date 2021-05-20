// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfNullT.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    /// <summary>
    ///     The Builder With Action Of Null T interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfNullT<out TResult> : IObserverBuilderBase<IBuilderWithActionOfNullT<TResult>>,
                                                              ISchedulerBase<IBuilderWithActionOfNullT<TResult>>,
                                                              IDeferBase<IBuilderWithActionOfNullTAndDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The property observer.
        /// </returns>
        IGetterReferencePropertyObserver<TResult> Build();

        /// <summary>
        ///     Builder with getter.
        /// </summary>
        /// <returns>
        ///     The property value observer builder.
        /// </returns>
        IBuilderWithActionOfNullTAndGetter<TResult> WithGetter();
    }
}