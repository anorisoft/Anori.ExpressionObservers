// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderWithActionOfTResultAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces;

    /// <summary>
    /// The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithNotifyProperyChanged{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithValueChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithAction{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResult{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithValueChanged{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultNullable{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilder{TResult}" />
    public abstract partial class
        PropertyValueObserverBuilderBase<TSelf, TResult> : IPropertyValueObserverBuilderWithActionOfTResultAndFallback<
            TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>
            IPropertyObserverBuilderBase<IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserverWithFallback<TResult>
            IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>.Create() =>
            this.CreatePropertyGetterObserverWithFallback();

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<
                TResult>>.WithGetterDispatcher()
        {
            this.IsDispached = true;
            return this.PropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler();
        }

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler<
                TResult>>.WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            this.TaskScheduler = taskScheduler;
            return this.PropertyValueObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler();
        }
    }
}