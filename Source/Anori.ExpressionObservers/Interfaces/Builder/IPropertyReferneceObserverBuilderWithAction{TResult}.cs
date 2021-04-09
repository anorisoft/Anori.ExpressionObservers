// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithAction.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    /// <summary>
    /// The I Value Property Observer Builder With Action interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.Builder.IPropertyObserverBuilderBase{Anori.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithAction{TResult}}" />
    /// <seealso cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithAction{TResult}}" />
    public interface IPropertyReferenceObserverBuilderWithAction<TResult> : IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithAction<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Property Observer.</returns>
        IPropertyObserver<TResult> Build();

        /// <summary>
        /// Withes the getter.
        /// </summary>
        /// <returns>The Property Observer Builder.</returns>
        IPropertyReferenceObserverBuilderWithActionAndGetter<TResult> WithGetter();
    }
}