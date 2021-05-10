// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnPropertyChanged.IBuilderWithAction.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
{
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="BuilderBase{TSelf}" />
    /// <seealso cref="IBuilderOnNotifyProperyChanged{TResult}" />
    /// <seealso cref="IBuilderWithScheduler{TResult}" />
    /// <seealso cref="IBuilderOnValueChangedAndDeferrer{TResult}" />
    /// <seealso cref="IBuilderOnNotifyProperyChanged{TResult}" />
    /// <seealso cref="IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithActionOfTAndGetterAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithAction{TResult}" />
    /// <seealso cref="IBuilderWithActionOfT{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="IBuilderOnValueChanged{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithAction{TResult}" />
    /// <seealso cref="IBuilderWithActionOfTAndGetter{TResult}" />
    /// <seealso cref="IBuilderWithActionOfT{TResult}" />
    /// <seealso cref="IBuilderWithActionOfNullT{TResult}" />
    /// <seealso cref="IBuilderOnValueChangedAndDeferrer{TResult}" />
    /// <seealso cref="IBuilderWithActionOfTAndGetterAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithActionOfNullT{TResult}" />
    /// <seealso cref="IBuilder{TResult}" />
    // ReSharper disable UnusedTypeParameter
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithAction<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IBuilderWithAction<TResult> IObserverBuilderBase<IBuilderWithAction<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserver<TResult> IBuilderWithAction<TResult>.Build() => this.CreatePropertyObserverWithAction();

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IBuilderWithActionAndGetter<TResult> IBuilderWithAction<TResult>.WithGetter() => this;
    }
}