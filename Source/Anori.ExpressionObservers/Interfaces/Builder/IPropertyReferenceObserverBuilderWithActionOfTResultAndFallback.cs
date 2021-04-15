// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    /// <summary>
    ///     The I Property Value Observer Builder With Action Of T Result And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback{TResult}}" />
    /// <seealso
    ///     cref="IPropertyObserverGetterTaskScheduler{TTarget}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback{TResult}}" />
    public interface IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback<out TResult> :
        IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback<TResult>>,
        IPropertyObserverGetterTaskScheduler<
            IPropertyReferenceObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserverWithFallback<TResult> Build();

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterAndFallback<TResult> WithGetter();
    }
}