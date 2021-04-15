// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase{TSelf,TResult}.IPropertyReferenceObserverBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System;

    using Anori.ExpressionObservers.Interfaces.Builder;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyReferenceObserverBuilderWithNotifyProperyChanged{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithAction{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfTResult{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithValueChanged{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderWithActionAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderWithActionOfTResultNullable{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilder{TResult}" />
    // ReSharper disable UnusedTypeParameter
    internal abstract partial class
        PropertyReferenceObserverBuilderBase<TSelf, TResult> : IPropertyReferenceObserverBuilder<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IPropertyReferenceObserverBuilder<TResult>
            IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilder<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithAction<TResult> IPropertyReferenceObserverBuilder<TResult>.WithAction(
            Action action)
        {
            return this.WithAction(action);
        }

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithActionOfTResult<TResult> IPropertyReferenceObserverBuilder<TResult>.
            WithAction(Action<TResult> action) =>
            this.WithActionOfTResultWithFallback(action);

        /// <summary>
        ///     Withes the notify propery changed.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithNotifyProperyChanged<TResult> IPropertyReferenceObserverBuilder<TResult>.
            WithNotifyProperyChanged() =>
            this.WithNotifyProperyChanged();

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithActionOfTResultNullable<TResult> IPropertyReferenceObserverBuilder<TResult>
            .WithNullableAction(Action<TResult?> action)
        {
            return this.WithActionOfTResult(action);
        }

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithValueChanged<TResult> IPropertyReferenceObserverBuilder<TResult>.
            WithValueChanged() =>
            this.WithValueChanged();
    }
}