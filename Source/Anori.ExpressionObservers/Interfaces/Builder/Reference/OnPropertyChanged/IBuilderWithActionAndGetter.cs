// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    /// <summary>
    ///     The property value observer builder With Action And Getter interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionAndGetter<TResult> : IObserverBuilderBase<IBuilderWithActionAndGetter<TResult>>,
                                                            ISchedulerBase<IBuilderWithActionAndGetter<TResult>>,
                                                            ICacheBase<IBuilderWithActionAndGetter<TResult>>,
                                                            IDeferBase<IBuilderWithActionAndGetterAndDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The property observer.</returns>
        IGetterReferencePropertyObserver<TResult> Build();

        /// <summary>
        ///     Builder With fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The property observer builder.</returns>
        IBuilderWithActionAndGetterAndFallback<TResult> WithFallback(TResult fallback);
    }
}