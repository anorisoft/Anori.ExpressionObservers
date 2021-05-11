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
                                                              IObserverBuilderSchedulerBase<
                                                                  IBuilderWithActionOfNullT<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterReferencePropertyObserver<TResult> Build();

        /// <summary>
        ///     Deferreds this instance.
        /// </summary>
        /// <returns></returns>
        IBuilderWithActionOfNullTAndDeferrer<TResult> Deferred();

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithActionOfNullTAndGetter<TResult> WithGetter();
    }
}