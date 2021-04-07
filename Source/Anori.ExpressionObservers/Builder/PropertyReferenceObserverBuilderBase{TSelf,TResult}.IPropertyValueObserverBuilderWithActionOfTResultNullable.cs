// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase{TSelf,TResult}.IPropertyReferenceObserverBuilderWithActionOfTResultNullable.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithNotifyProperyChanged{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithValueChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithNotifyProperyChangedAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionOfTResultAndFallback{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithAction{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionOfTResult{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithValueChanged{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionOfTResultAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionAndGetterAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionOfTResultAndFallbackAndGetterTaskScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionOfTResultNullable{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilder{TResult}" />
    public abstract partial class
        PropertyReferenceObserverBuilderBase<TSelf, TResult> : IPropertyReferenceObserverBuilderWithActionOfTResultNullable<
            TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithActionOfTResultNullable<TResult> IPropertyObserverBuilderBase<
            IPropertyReferenceObserverBuilderWithActionOfTResultNullable<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyReferenceObserver<TResult> IPropertyReferenceObserverBuilderWithActionOfTResultNullable<TResult>.Create() =>
            this.CreatePropertyReferenceObserver();

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            IGetterTaskScheduler<IPropertyReferenceObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            >.WithGetterDispatcher()
        {
            this.IsDispached = true;
            return this.PropertyReferenceObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler();
        }

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyReferenceObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            IGetterTaskScheduler<IPropertyReferenceObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>
            >.WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            this.TaskScheduler = taskScheduler;
            return this.PropertyReferenceObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler();
        }
    }
}