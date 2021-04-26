// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfT.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged
{
    /// <summary>
    /// The I Builder With Action Of T interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilder{TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverScheduler{Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged.IBuilderWithScheduler{TResult}}" />
    public interface IBuilderWithActionOfT<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfT<TResult>>,
        IPropertyObserverScheduler<
            IBuilderWithActionOfTAndScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        /// Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        IBuilderWithActionOfTAndFallback<TResult>
            WithFallback(TResult fallback);
    }
}
