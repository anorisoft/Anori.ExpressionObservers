// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionOfTResult.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    /// <summary>
    ///     The I Property Value Observer Builder With Action Of T Result interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResult{TResult}}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverGetterTaskScheduler{Anori.ExpressionObservers.Interfaces.Builder.IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}}" />
    public interface IPropertyValueObserverBuilderWithActionOfTResult<TResult> :
        IPropertyObserverBuilderBase<IPropertyValueObserverBuilderWithActionOfTResult<TResult>>,
        IPropertyObserverGetterTaskScheduler<
            IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult> WithFallback(TResult fallback);

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndGetter<TResult> WithGetter();
    }
}