// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using Anori.ExpressionObservers.Builder;

    /// <summary>
    /// The I Property Value Observer Builder With Action And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderBase{Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler{TResult}}" />
    public interface IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult> :
        IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler<TResult>>
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
        IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback<TResult>
            WithFallback(TResult fallback);
    }
}