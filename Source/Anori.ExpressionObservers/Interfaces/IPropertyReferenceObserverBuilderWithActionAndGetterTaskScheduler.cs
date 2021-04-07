// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithActionAndGetterTaskScheduler.cs" company="AnoriSoft">
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
    /// <seealso cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionAndGetterTaskScheduler{TResult}}" />
    public interface IPropertyReferenceObserverBuilderWithActionAndGetterTaskScheduler<TResult> :
        IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithActionAndGetterTaskScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Property Observer.</returns>
        IPropertyReferenceObserverWithGetter<TResult> Create();


        /// <summary>
        /// Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        IPropertyReferenceObserverBuilderWithActionAndDispatcherGetterAndFallback<TResult>
            WithFallback(TResult fallback);
    }
}