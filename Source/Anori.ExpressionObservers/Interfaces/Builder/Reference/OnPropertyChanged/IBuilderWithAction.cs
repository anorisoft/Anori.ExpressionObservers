// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithAction.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    /// <summary>
    ///     The I Value Property Observer Builder With Action interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithAction{TResult}}" />
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderOnNotifyProperyChangedWithAction{TResult}}" />
    public interface IBuilderWithAction<TResult> :
        IObserverBuilderBase<IBuilderWithAction<TResult>>,
    IPropertyObserverScheduler<IBuilderWithScheduler<TResult>>

        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Property Observer.</returns>
        IPropertyObserver<TResult> Build();

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>The Property Observer Builder.</returns>
        IBuilderWithActionAndGetter<TResult> WithGetter();
    }
}