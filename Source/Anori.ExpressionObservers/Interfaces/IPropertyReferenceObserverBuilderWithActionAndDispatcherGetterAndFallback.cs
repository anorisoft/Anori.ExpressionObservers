// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithActionAndDispatcherGetterAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using Anori.ExpressionObservers.Builder;

    /// <summary>
    /// The I Property Value Observer Builder With Action And Dispatcher Getter And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionAndDispatcherGetterAndFallback{TResult}}" />
    public interface IPropertyReferenceObserverBuilderWithActionAndDispatcherGetterAndFallback<out TResult> :
        IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithActionAndDispatcherGetterAndFallback<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Observer With Getter And Fallback.</returns>
        IPropertyObserverWithGetterAndFallback<TResult> Create();
    }
}