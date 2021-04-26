// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderWithAction.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using Anori.ExpressionObservers.Builder.PropertyObserver;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged;

    /// <summary>
    /// The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="BuilderBase{TSelf}" />
    /// <seealso cref="IBuilderOnNotifyProperyChanged{TResult}" />
    /// <seealso cref="IBuilderWithScheduler{TResult}" />
    /// <seealso cref="IBuilderOnValueChangedAndDeferrerAndScheduler{TResult}" />
    /// <seealso cref="IBuilderOnNotifyProperyChangedAndScheduler{TResult}" />
    /// <seealso cref="IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithActionOfTAndGetterAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithAction{TResult}" />
    /// <seealso cref="IBuilderWithActionOfT{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="IBuilderOnValueChanged{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithActionAndScheduler{TResult}" />
    /// <seealso cref="IBuilderWithActionOfTAndGetter{TResult}" />
    /// <seealso cref="IBuilderWithActionOfTAndScheduler{TResult}" />
    /// <seealso cref="IBuilderWithActionOfNullTAndScheduler{TResult}" />
    /// <seealso cref="IBuilderOnValueChangedAndDeferrer{TResult}" />
    /// <seealso cref="IBuilderWithActionOfTAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="IBuilderWithActionOfTAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="IBuilderWithActionOfNullT{TResult}" />
    /// <seealso cref="IBuilder{TResult}" />
    // ReSharper disable UnusedTypeParameter
    internal abstract partial class
        BuilderBase<TSelf, TResult> : IBuilderWithAction<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IBuilderWithAction<TResult> IObserverBuilderBase<
            IBuilderWithAction<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserver<TResult> IBuilderWithAction<TResult>.Build() =>
            this.CreatePropertyObserverWithAction();

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IBuilderWithActionAndGetter<TResult> IBuilderWithAction<TResult>.
            WithGetter() =>
            this;
    }
}