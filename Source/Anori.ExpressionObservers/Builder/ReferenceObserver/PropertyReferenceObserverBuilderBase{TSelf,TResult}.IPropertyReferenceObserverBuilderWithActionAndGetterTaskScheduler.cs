// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase{TSelf,TResult}.IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithActionAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged;

    /// <summary>
    ///     The Property Value Observer Builder Base class.
    /// </summary>
    /// <typeparam name="TSelf">The type of the self.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IBuilderOnProperyChanged{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnValueChanged.IBuilderWithScheduler{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithScheduler{TResult}" />
    /// <seealso
    ///     cref="IPropertyReferenceObserverBuilderWithActionOfTAndFallback{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithAction{TResult}" />
    /// <seealso cref="IPropertyReferenceObserverBuilderWithActionOfT{TResult}" />
    /// <seealso cref="IBuilderWithActionAndGetter{TResult}" />
    /// <seealso cref="IBuilder{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndGetterAndFallback{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndScheduler{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionOfNullTAndScheduler{TResult}" />
    /// <seealso
    ///     cref="IBuilderWithActionAndGetterAndFallbackAndScheduler{TResult}" />
    /// <seealso
    ///     cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndFallbackAndScheduler{TResult}" />
    /// <seealso cref="Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullT{TResult}" />
    /// <seealso cref="IReferenceObserverBuilder{TResult}" />
    internal abstract partial class
        BuilderBase<TSelf, TResult> : Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionAndScheduler<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Value Observer Builder.
        /// </returns>
        Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionAndScheduler<TResult> IObserverBuilderBase<Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionAndScheduler<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterReferencePropertyObserver<TResult> Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionAndScheduler<TResult>.Build() =>
            this.CreatePropertyReferenceObserverWithGetter();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionAndGetterAndFallback2<TResult> Interfaces.Builder.Reference.OnValueChanged.IBuilderWithActionAndScheduler<TResult>.WithFallback(TResult fallback) =>
            this.WithFallback(fallback);
    }
}