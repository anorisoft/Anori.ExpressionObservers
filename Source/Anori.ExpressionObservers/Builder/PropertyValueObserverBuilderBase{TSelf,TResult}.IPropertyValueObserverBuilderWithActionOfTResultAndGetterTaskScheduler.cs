// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using Anori.ExpressionObservers.Exceptions;
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
            IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>
            IPropertyObserverBuilderBase<IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>
            >.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResultAndFallback<TResult>
            IPropertyValueObserverBuilderWithActionOfTResultAndGetterTaskScheduler<TResult>.WithFallback(
                TResult fallback)
        {
            if (this.Fallback.HasValue)
            {
                throw new FallbackAlreadyDefineException();
            }

            this.Fallback = fallback;
            return this;
        }
    }
}