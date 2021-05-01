// -----------------------------------------------------------------------
// <copyright file="IBuilderWithAction.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    /// <summary>
    ///     The Property Value Observer Builder With Action And Getter interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionAndGetter{TResult}}" />
    /// <seealso
    ///     cref="IPropertyObserverScheduler{TTarget}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionAndScheduler{TResult}}" />
    public interface IBuilderWithAction<TResult> : IObserverBuilderBase<IBuilderWithAction<TResult>>,
                                                   IPropertyObserverScheduler<IBuilderWithActionAndScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Property Observer.</returns>
        INotifyReferencePropertyObserver<TResult> Build();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Property Observer Builder.</returns>
        IBuilderWithActionAndFallback<TResult> WithFallback(TResult fallback);
    }
}