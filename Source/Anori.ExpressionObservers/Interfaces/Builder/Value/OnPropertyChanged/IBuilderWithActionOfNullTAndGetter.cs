// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfNullTAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The I Property Reference Observer Builder With Action Of T Result interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfNullTAndGetter<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfNullTAndGetter<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterValuePropertyObserver<TResult> Build();

        /// <summary>
        /// Deferreds this instance.
        /// </summary>
        /// <returns></returns>
        IBuilderWithActionOfNullTAndGetterAndDeferrer<TResult> Deferred();

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithActionOfNullTAndGetter<TResult> WithGetter();

    }
}