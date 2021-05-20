// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnValueChanged
{
    /// <summary>
    ///     The property value observer builder With Action And Getter And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionAndFallback<out TResult> :
        IObserverBuilderBase<IBuilderWithActionAndFallback<TResult>>,
        ISchedulerBase<IBuilderWithActionAndFallback<TResult>>,
        IDeferBase<IBuilderWithActionAndFallbackAndDeferrer<TResult>>
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Observer With Getter And Fallback.</returns>
        INotifyPropertyObserver<TResult> Build();
    }
}