// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    /// <summary>
    ///     The Property Value Observer Builder With Action Of T Result And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfTAndFallback<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndFallback<TResult>>,
        IObserverBuilderSchedulerBase<IBuilderWithActionOfTAndFallback<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserver<TResult> Build();

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallback<TResult> WithGetter();


        /// <summary>
        ///     Deferreds this instance.
        /// </summary>
        /// <returns></returns>
        IBuilderWithActionOfTAndFallbackAndDeferrer<TResult> Deferred();
    }
}