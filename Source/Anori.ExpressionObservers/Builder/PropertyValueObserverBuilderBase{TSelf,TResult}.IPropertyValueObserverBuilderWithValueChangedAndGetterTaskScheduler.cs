﻿// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyValueObserverBuilderWithNotifyProperyChanged{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResultAndFallback{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithAction{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResult{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithValueChanged{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResultNullable{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilder{TResult}" />
    internal abstract partial class
        PropertyValueObserverBuilderBase<TSelf, TResult> :
            IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult> IPropertyObserverBuilderBase<
            IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        IPropertyValueObserverOnValueChanged<TResult>
            IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>.Build() =>
            this.CreatePropertyValueObserverBuilderWithValueChanged();

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>
            IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>.Cached(
                LazyThreadSafetyMode safetyMode)
        {
            return this.Cached(safetyMode);
        }

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>
            IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler<TResult>.Cached()
        {
            return this.Cached();
        }
    }
}