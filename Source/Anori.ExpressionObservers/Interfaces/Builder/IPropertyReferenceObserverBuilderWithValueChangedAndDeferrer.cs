﻿// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithValueChangedAndDeferrer.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder
{
    /// <summary>
    /// The Property Reference Observer Builder With Value Changed And Deferrer interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IPropertyReferenceObserverBuilderWithValueChangedAndDeferrer<TResult> :
    IPropertyObserverBuilderBase<IPropertyReferenceObserverBuilderWithValueChangedAndDeferrer<TResult>>
        where TResult : class
    {
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        IPropertyReferenceObserverOnValueChangedWithDeferrer<TResult> Build();
    }
}