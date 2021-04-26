// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithActionOfT.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.OnValueChanged
{

    /// <summary>
    ///     The I Property Reference Observer Builder With Action Of T Result interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfT{TResult}}" />
    /// <seealso
    ///     cref="IPropertyObserverGetterTaskScheduler{TTarget}.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}}" />
    public interface IPropertyReferenceObserverBuilderWithActionOfT<TResult> :
        IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithActionOfT<TResult>>,
        IPropertyObserverGetterTaskScheduler<
            IPropertyReferenceObserverBuilderWithActionOfTAndGetterTaskScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithActionOfTAndFallback<TResult> WithFallback(TResult fallback);

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithActionOfTAndGetter<TResult> WithGetter();
    }
}