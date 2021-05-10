// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged
{
    /// <summary>
    ///     The Property Value Observer Builder With Action And Getter And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionAndFallback<out TResult> :
        IObserverBuilderBase<IBuilderWithActionAndFallback<TResult>>,
    IObserverBuilderSchedulerBase<IBuilderWithActionAndFallback<TResult>>
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Observer With Getter And Fallback.</returns>
        INotifyPropertyObserver<TResult> Build();
    }
}