// -----------------------------------------------------------------------
// <copyright file="PropertyReferenceObserverBuilderBase{TSelf,TResult}.IPropertyReferenceObserverBuilder.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System;
    using System.Threading.Tasks;

    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Interfaces.Builder;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged;
    using Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged;

    internal abstract partial class
        BuilderBase<TSelf, TResult> : IReferenceObserverBuilder<TResult>
    {
        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns>The Property Value Observer Builder.</returns>
        IReferenceObserverBuilder<TResult>
            IObserverBuilderBase<IReferenceObserverBuilder<TResult>>.AutoActivate() =>
            this.AutoActivate();

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithAction<TResult> IReferenceObserverBuilder<TResult>.WithAction(
            Action action) =>
            this.WithAction(action);

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfT<TResult> IReferenceObserverBuilder<TResult>.
            WithAction(Action<TResult> action) =>
            this.WithActionOfTWithFallback(action);

        /// <summary>
        ///     Withes the notify propery changed.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilderOnProperyChanged<TResult> IReferenceObserverBuilder<TResult>.
            OnNotifyProperyChanged() =>
            this.OnNotifyProperyChanged();

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullT<TResult> IReferenceObserverBuilder<TResult>
            .WithNullableAction(Action<TResult?> action) =>
            this.WithActionOfT(action);

        /// <summary>
        ///     Withes the value changed.
        /// </summary>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IBuilder<TResult> IReferenceObserverBuilder<TResult>.
            OnValueChanged() =>
            this.OnValueChanged();
    }


    internal abstract partial class BuilderBase<TSelf, TResult> : Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullT<TResult>
    {
        public Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullT<TResult> AutoActivate()
        {
            throw new NotImplementedException();
        }
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullTAndScheduler<TResult> IPropertyObserverScheduler<Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullTAndScheduler<TResult>>.WithGetterDispatcher()
        {
            throw new NotImplementedException();
        }
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<TResult> IPropertyObserverScheduler<Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<TResult>>.WithScheduler(
            TaskScheduler taskScheduler)
        {
            throw new NotImplementedException();
        }
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<TResult> IPropertyObserverScheduler<Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfTAndGetterAndFallbackAndScheduler<TResult>>.WithGetterDispatcher()
        {
            throw new NotImplementedException();
        }
        Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullTAndScheduler<TResult> IPropertyObserverScheduler<Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullTAndScheduler<TResult>>.WithScheduler(
            TaskScheduler taskScheduler)
        {
            throw new NotImplementedException();
        }
        IGetterReferencePropertyObserver<TResult> Interfaces.Builder.Reference.OnPropertyChanged.IBuilderWithActionOfNullT<TResult>.Build()
        {
            throw new NotImplementedException();
        }
    }
}