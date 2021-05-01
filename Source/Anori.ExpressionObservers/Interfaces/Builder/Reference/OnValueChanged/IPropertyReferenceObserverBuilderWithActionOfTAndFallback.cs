// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithActionOfTAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.OnValueChanged
{
    /// <summary>
    ///     The I Property Value Observer Builder With Action Of T Result And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTAndFallback{TResult}}" />
    /// <seealso
    ///     cref="IPropertyObserverGetterTaskScheduler{TTarget}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionOfTAndFallback{TResult}}" />
    public interface IPropertyReferenceObserverBuilderWithActionOfTAndFallback<out TResult> :
        IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithActionOfTAndFallback<TResult>>,
        IPropertyObserverGetterTaskScheduler<
            IPropertyReferenceObserverBuilderWithActionOfTAndFallbackAndGetterTaskScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserverOnValueChanged<TResult> Build();

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyReferenceObserverBuilderWithActionOfTAndGetterAndFallback<TResult> WithGetter();
    }
}