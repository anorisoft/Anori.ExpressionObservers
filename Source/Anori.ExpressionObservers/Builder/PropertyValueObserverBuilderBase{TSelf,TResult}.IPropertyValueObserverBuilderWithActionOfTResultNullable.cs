﻿// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderWithActionOfTResultNullable.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyValueObserverBuilderWithNotifyProperyChanged{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionOfTResultAndFallback{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithAction{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResult{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithValueChanged{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilderWithActionOfTResultNullable{TResult}" />
    /// <seealso cref="IPropertyValueObserverBuilder{TResult}" />
    internal abstract partial class
        PropertyValueObserverBuilderBase<TSelf, TResult> : IPropertyValueObserverBuilderWithActionOfTResultNullable<
            TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultNullable<TResult> IPropertyObserverBuilderBase<
            IPropertyValueObserverBuilderWithActionOfTResultNullable<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyValueObserver<TResult> IPropertyValueObserverBuilderWithActionOfTResultNullable<TResult>.Build() =>
            this.CreatePropertyValueObserver();

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            IPropertyObserverGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            >.WithGetterDispatcher()
        {
            this.IsDispached = true;
            return this.PropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler();
        }

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            IPropertyObserverGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            >.WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            this.TaskScheduler = taskScheduler;
            return this.PropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler();
        }
    }
}