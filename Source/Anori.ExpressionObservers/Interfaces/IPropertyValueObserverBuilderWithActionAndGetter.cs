// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using Anori.ExpressionObservers.Builder;

    /// <summary>
    ///     The Property Value Observer Builder With Action And Getter interface.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IPropertyValueObserverBuilderWithActionAndGetter<TParameter1, TResult> :
        IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithActionAndGetter<TParameter1, TResult>>,
        IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionAndGetter<TParameter1, TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Property Observer.</returns>
        IPropertyValueObserverWithGetter<TParameter1, TResult> Create();

        /// <summary>
        /// Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TParameter1, TResult>
            WithFallback(TResult fallback);
    }
}