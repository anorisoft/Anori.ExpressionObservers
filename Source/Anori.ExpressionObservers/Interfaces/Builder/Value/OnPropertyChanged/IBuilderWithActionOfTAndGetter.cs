// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionOfTAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The I Property Value Observer Builder With Action Of T Result And Getter interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTAndGetter{TResult}}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverScheduler{Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTAndScheduler{TResult}}" />
    public interface IBuilderWithActionOfTAndGetter<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndGetter<TResult>>,
        IPropertyObserverScheduler<
            IBuilderWithActionOfTAndGetterAndScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallback<TResult> WithFallback(TResult fallback);
    }
}