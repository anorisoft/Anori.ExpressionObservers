// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnValueChanged.IBuilderWithAction.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder.PropertyObserver.Reference
{
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged;

    /// <summary>
    /// The Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Builder.PropertyObserver.BuilderBase{TSelf}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfT{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionOfTAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithFallbackAndDeferrerAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithAction{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithAction{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionOfT{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithDeferrerAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionAndGetterAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionOfNullT{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithDeferrerAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionOfNullTAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullTAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IReferenceObserverBuilder{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithFallbackAndDeferrer{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetter{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilder{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullT{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionOfTAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithFallbackAndScheduler{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilder{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithDeferrer{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithDeferrer{TResult}" />
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
        INotifyReferencePropertyObserver<TResult> IBuilderWithAction<TResult>.Build() =>
            this.CreateNotifyReferencePropertyObserverWithAction();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionAndFallback<TResult> IBuilderWithAction<TResult>.WithFallback(TResult fallback) =>
            this.WithFallback(fallback);

        /// <summary>
        ///     Withes the getter dispatcher.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        IBuilderWithActionAndScheduler<TResult> IPropertyObserverScheduler<IBuilderWithActionAndScheduler<TResult>>.
            WithGetterDispatcher() =>
            this.WithGetterDispatcher();

        /// <summary>
        ///     Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderWithActionAndScheduler<TResult> IPropertyObserverScheduler<IBuilderWithActionAndScheduler<TResult>>.
            WithScheduler(TaskScheduler taskScheduler) =>
            this.WithScheduler(taskScheduler);
    }
}