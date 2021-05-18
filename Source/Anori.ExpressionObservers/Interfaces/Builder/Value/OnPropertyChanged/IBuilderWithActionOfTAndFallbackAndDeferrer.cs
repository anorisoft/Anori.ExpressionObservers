// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfTAndFallbackAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The Builder With Action Of T And Fallback And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithActionOfTAndFallbackAndDeferrer<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>>,
        ISchedulerBase<IBuilderWithActionOfTAndFallbackAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserverWithDeferrer<TResult> Build();

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IBuilderWithActionOfTAndGetterAndFallbackAndDeferrer<TResult> WithGetter();
    }
}