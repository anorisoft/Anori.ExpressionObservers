// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithActionOfTResultAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    /// <summary>
    ///     The I Property Reference Observer Builder With Action Of T Result And Getter interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfTResultAndGetter{TResult}}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverGetterTaskScheduler{Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}}" />
    public interface IPropertyReferenceObserverBuilderWithActionOfTResultAndGetter<TResult> :
        IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithActionOfTResultAndGetter<TResult>>,
        IPropertyObserverGetterTaskScheduler<
            IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterAndFallback<TResult>
            WithFallback(TResult fallback);
    }
}