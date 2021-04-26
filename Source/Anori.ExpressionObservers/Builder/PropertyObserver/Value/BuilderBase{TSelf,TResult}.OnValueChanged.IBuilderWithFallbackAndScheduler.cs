// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilderBase{TSelf,TResult}.IPropertyValueObserverBuilderOnValueChangedAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Value
{
    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IBuilderOnNotifyProperyChanged{TResult}" />
    /// <seealso cref="IBuilderWithScheduler{TResult}" />
    /// <seealso cref="IBuilderOnNotifyProperyChangedAndScheduler{TResult}" />
    /// <seealso cref="IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithAction{TResult}" />
    /// <seealso cref="IBuilderWithActionOfT{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="IBuilderOnValueChanged{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="IBuilderWithActionAndScheduler{TResult}" />
    /// <seealso cref="IBuilderWithActionOfTAndScheduler{TResult}" />
    /// <seealso cref="IBuilderWithActionOfNullTAndScheduler{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="IBuilderWithActionOfTAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="IBuilderWithActionOfNullT{TResult}" />
    /// <seealso cref="IBuilder{TResult}" />
    internal abstract partial class
        BuilderBase<TSelf, TResult> :
            IBuilderWithFallbackAndScheduler<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithFallbackAndScheduler<TResult> IObserverBuilderBase<
            IBuilderWithFallbackAndScheduler<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Propery Changed.
        /// </returns>
        INotifyValuePropertyObserver<TResult>
            IBuilderWithFallbackAndScheduler<TResult>.Build() =>
            this.CreateNotifyValuePropertyObserverWithFallbackAndScheduler();


        IBuilderWithFallbackAndScheduler<TResult> IBuilderWithFallbackAndScheduler<TResult>.Cached(LazyThreadSafetyMode safetyMode)
        {
            return this.Cached(safetyMode);
        }
        /// <summary>
        /// Cacheds the specified safety mode.
        /// </summary>
        /// <returns>
        /// The Property Value Observer Builder.
        /// </returns>
        IBuilderWithFallbackAndScheduler<TResult>
            IBuilderWithFallbackAndScheduler<TResult>.Cached()
        {
            return this.Cached();
        }
        /// <summary>
        /// Defers this instance.
        /// </summary>
        /// <returns>
        /// The Property Value Observer Builder.
        /// </returns>
        IBuilderWithFallbackAndDeferrerAndScheduler<TResult> IBuilderWithFallbackAndScheduler<TResult>.Deferred() =>
            this;
    }
}