// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    using Anori.Common;

    /// <summary>
    ///     The Property Value2 Observer Builder With Action And Getter interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndGetter{TResult}}" />
    /// <seealso
    ///     cref="IPropertyObserverScheduler{TTarget}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndScheduler{TResult}}" />
    public interface IBuilderWithActionAndGetter<TResult> :
        IObserverBuilderBase<IBuilderWithActionAndGetter<TResult>>,
        IPropertyObserverScheduler<IBuilderWithActionAndGetterAndScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Property Observer.</returns>
        IGetterValuePropertyObserver<TResult> Build();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value2 Property Observer Builder.
        /// </returns>
        IBuilderWithActionAndGetterAndFallback<TResult> WithFallback(TResult fallback);

        /// <summary>
        /// Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Value2 Property Observer Builder.
        /// 
        /// </returns>
        IBuilderWithActionAndGetterAndFallback<TResult> Cached(LazyThreadSafetyMode safetyMode);

        /// <summary>
        /// Cacheds this instance.
        /// </summary>
        /// <returns>
        ///     The Value2 Property Observer Builder.
        /// </returns>
        IBuilderWithActionAndGetterAndFallback<TResult> Cached();
    }
}