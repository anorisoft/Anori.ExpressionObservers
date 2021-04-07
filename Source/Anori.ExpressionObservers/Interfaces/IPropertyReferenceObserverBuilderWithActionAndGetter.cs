// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithActionAndGetter.cs" company="AnoriSoft">
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
    /// <seealso cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionAndGetter{TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IGetterTaskScheduler{Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionAndGetterTaskScheduler{TResult}}" />
    public interface IPropertyReferenceObserverBuilderWithActionAndGetter<TResult> :
        IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithActionAndGetter<TResult>>,
        IGetterTaskScheduler<IPropertyReferenceObserverBuilderWithActionAndGetterTaskScheduler<TResult>>
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
        IPropertyReferenceObserverBuilderWithActionAndGetterAndFallback<TResult>
            WithFallback(TResult fallback);
    }
}