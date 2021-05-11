// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfNullTAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    /// <summary>
    ///     The I Property Reference Observer Builder With Action Of T Result interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfNullTAndGetter<out TResult> :
        IObserverBuilderBase<IBuilderWithActionOfNullTAndGetter<TResult>>,
    IObserverBuilderSchedulerBase<IBuilderWithActionOfNullTAndGetter<TResult>>
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
        /// Deferreds this instance.
        /// </summary>
        /// <returns></returns>
        IBuilderWithActionOfNullTAndGetterAndDeferrer<TResult> Deferred();

        

    }
}