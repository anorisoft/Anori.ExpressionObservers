// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithActionOfTResultNullable.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    using Anori.ExpressionObservers.Builder;

    /// <summary>
    /// The I Property Value Observer Builder With Action Of T Result Nullable interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionOfTResultNullable{TResult}}" />
    /// <seealso cref="IPropertyObserverGetterTaskScheduler{TTarget}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionOfTResultNullable{TResult}}" />
    public interface IPropertyReferenceObserverBuilderWithActionOfTResultNullable<TResult> :
        IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithActionOfTResultNullable<TResult>>,
        IPropertyObserverGetterTaskScheduler<IPropertyReferenceObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyReferenceObserver<TResult> Build();

        // ToDo Not FallBack
        ///// <summary>
        ///// Withes the fallback.
        ///// </summary>
        ///// <param name="fallback">The fallback.</param>
        ///// <returns></returns>
        //IPropertyReferenceObserverBuilderWithActionOfTResultNullable<TResult>
        //    WithFallback(TResult fallback);
    }
}