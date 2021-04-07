// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using Anori.ExpressionObservers.Builder;

    /// <summary>
    /// The Property Value Observer Builder With Action And Getter interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndGetter{TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IGetterTaskScheduler{Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler{TResult}}" />
    public interface IPropertyValueObserverBuilderWithActionAndGetter<TResult> :
        IPropertyObserverBuilderBase<IPropertyValueObserverBuilderWithActionAndGetter<TResult>>,
        IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Property Observer.</returns>
        IPropertyValueObserverWithGetter<TResult> Create();

        /// <summary>
        /// Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TResult>
            WithFallback(TResult fallback);
    }
}