// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfT.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged
{
    using Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged;

    /// <summary>
    ///     The I Builder With Action Of T interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfT<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfT<TResult>>,
    IObserverBuilderSchedulerBase<IBuilderWithActionOfT<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        IBuilderWithActionOfTAndFallback<TResult> WithFallback(TResult fallback);

        IBuilderWithActionOfTAndDeferrer<TResult> Deferred();

    }
}