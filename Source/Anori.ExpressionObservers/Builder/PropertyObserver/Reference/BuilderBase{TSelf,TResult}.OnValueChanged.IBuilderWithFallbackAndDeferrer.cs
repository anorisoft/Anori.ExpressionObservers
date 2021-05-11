// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnValueChanged.IBuilderWithFallbackAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
{
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="BuilderBase{TSelf}" />
    /// <seealso
    ///     cref="IBuilderOnNotifyPropertyChanged{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithAction{TResult}" />
    /// <seealso cref="IBuilder{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfNullT{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetter{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="IBuilderOnNotifyPropertyChanged{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfT{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfNullT{TResult}" />
    /// <seealso cref="IBuilderOnValueChanged{TResult}" />
    /// <seealso cref="IBuilderWithAction{TResult}" />
    /// <seealso cref="IBuilderWithActionOfT{TResult}" />
    /// <seealso
    ///     cref="IBuilderOnValueChangedAndDeferrer{TResult}" />
    /// <seealso
    ///     cref="IBuilderOnValueChangedAndDeferrer{TResult}" />
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithFallbackAndDeferrer<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Observer Builder.
        /// </returns>
        IBuilderWithFallbackAndDeferrer<TResult> IObserverBuilderBase<IBuilderWithFallbackAndDeferrer<TResult>>.
            AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Property Changed.
        /// </returns>
        INotifyPropertyObserverWithDeferrer<TResult> IBuilderWithFallbackAndDeferrer<TResult>.Build() =>
            this.CreateNotifyPropertyObserverWithFallbackAndDeferrer();
    }
}