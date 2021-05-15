// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionAndGetterAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    /// <summary>
    ///     The Builder With Action And Getter And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionAndGetterAndDeferrer<TResult> :
        IObserverBuilderBase<IBuilderWithActionAndGetterAndDeferrer<TResult>>,
        ISchedulerBase<IBuilderWithActionAndGetterAndDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Property Observer.</returns>
        IGetterReferencePropertyObserverWithDeferrer<TResult> Build();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Property Observer Builder.</returns>
        IBuilderWithActionAndGetterAndFallbackAndDeferrer<TResult> WithFallback(TResult fallback);
    }
}