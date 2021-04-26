// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    /// The I Property Value Observer Builder With Action And Dispatcher Getter And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionAndDispatcherGetterAndFallback{TResult}}" />
    public interface IBuilderWithActionAndDispatcherGetterAndFallback<out TResult> :
        IObserverBuilderBase<IBuilderWithActionAndDispatcherGetterAndFallback<TResult>>
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Observer With Getter And Fallback.</returns>
        IGetterValuePropertyObserver<TResult> Build();
    }
}