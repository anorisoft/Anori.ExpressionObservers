// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithActionOfTResultNullable.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    /// The I Property Value Observer Builder With Action Of T Result Nullable interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionOfTResultNullable{TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IGetterTaskScheduler{Anori.ExpressionObservers.Interfaces.IPropertyReferenceObserverBuilderWithActionOfTResultNullable{TResult}}" />
    public interface IPropertyReferenceObserverBuilderWithActionOfTResultNullable<TResult> :
        IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithActionOfTResultNullable<TResult>>,
        IGetterTaskScheduler<IPropertyReferenceObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyReferenceObserver<TResult> Create();

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