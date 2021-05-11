// -----------------------------------------------------------------------
// <copyright file="BuilderBase{TSelf,TResult}.OnValueChanged.IBuilderWithDefferer.cs" company="AnoriSoft">
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
    ///     cref="IBuilderWithActionAndDispatcherGetterAndFallback{TResult}" />
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
    internal abstract partial class BuilderBase<TSelf, TResult> : IBuilderWithDeferrer<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>
        ///     The Property Observer Builder.
        /// </returns>
        IBuilderWithDeferrer<TResult> IObserverBuilderBase<IBuilderWithDeferrer<TResult>>.AutoActivate() =>
            this.AutoActivate();
        
        IBuilderWithDeferrer<TResult> IObserverBuilderSchedulerBase<IBuilderWithDeferrer<TResult>>.WithGetterDispatcher()
        {
            throw new System.NotImplementedException();
        }
        IBuilderWithDeferrer<TResult> IObserverBuilderSchedulerBase<IBuilderWithDeferrer<TResult>>.WithScheduler(TaskScheduler taskScheduler)
        {
            throw new System.NotImplementedException();
        }
       

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     Property Value Observer On Notify Property Changed.
        /// </returns>
        INotifyReferencePropertyObserverWithDeferrer<TResult> IBuilderWithDeferrer<TResult>.Build() =>
            this.CreateNotifyReferencePropertyObserverWithDeferrer();
    }
}