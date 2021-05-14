// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionAndGetter.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    using Anori.Common;

    /// <summary>
    ///     The Property Value Observer Builder With Action And Getter interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionAndGetter<TResult> : IObserverBuilderBase<IBuilderWithActionAndGetter<TResult>>,
                                                            IObserverBuilderSchedulerBase<IBuilderWithActionAndGetter<TResult>>,
    IObserverBuilderCacheBase<IBuilderWithActionAndGetter<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Property Observer.</returns>
        IGetterReferencePropertyObserver<TResult> Build();

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Property Observer Builder.</returns>
        IBuilderWithActionAndGetterAndFallback<TResult> WithFallback(TResult fallback);

        /// <summary>
        ///     Deferreds this instance.
        /// </summary>
        /// <returns>The Property Observer Builder.</returns>
        IBuilderWithActionAndGetterAndDeferrer<TResult> Deferred();


       
    }
}