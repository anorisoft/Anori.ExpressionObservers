// -----------------------------------------------------------------------
// <copyright file="PropertyValueObserverBuilder{TParameter1,TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Builder
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Anori.Common;
    using Anori.ExpressionObservers.Interfaces;
    using Anori.ExpressionObservers.Observers;
    using Anori.ExpressionObservers.ValueTypeObservers;

    /// <summary>
    ///     The Value Property Observer Builder class.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyValueObserverBuilder{TParameter1,TResult}" />
    /// <seealso
    ///     cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithActionOfTResult{TParameter1, TResult}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IValuePropertyObserverBuilderWithAction{TParameter1, TResult}" />
    public sealed class PropertyValueObserverBuilder<TParameter1, TResult> :
        PropertyValueObserverBuilderBase<PropertyValueObserverBuilder<TParameter1, TResult>, TResult>,
        IPropertyValueObserverBuilder<TParameter1, TResult>,
        IPropertyValueObserverBuilderWithActionOfTResult<TParameter1, TResult>,
        IPropertyValueObserverBuilderWithAction<TParameter1, TResult>,
        IPropertyValueObserverBuilderWithActionAndGetter<TParameter1, TResult>,
        IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TParameter1, TResult>,
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TParameter1, TResult>,
    IPropertyValueObserverBuilderWithValueChanged<TParameter1, TResult>
        where TParameter1 : INotifyPropertyChanged
        where TResult : struct
    {
        /// <summary>
        ///     The parameter1.
        /// </summary>
        private readonly TParameter1 parameter1;

        /// <summary>
        ///     The property expression.
        /// </summary>
        private readonly Expression<Func<TParameter1, TResult>> propertyExpression;

        /// <summary>
        ///     The fallback.
        /// </summary>
        private TResult fallback;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyValueObserverBuilder{TParameter1, TResult}"/> class.
        /// </summary>
        /// <param name="parameter1">The parameter1.</param>
        /// <param name="propertyExpression">The property expression.</param>
        public PropertyValueObserverBuilder(
            TParameter1 parameter1,
            Expression<Func<TParameter1, TResult>> propertyExpression)
        {
            this.parameter1 = parameter1;
            this.propertyExpression = propertyExpression;
        }

        /// <summary>
        ///     Gets the task scheduler.
        /// </summary>
        /// <value>
        ///     The task scheduler.
        /// </value>
        public TaskScheduler TaskScheduler { get; private set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is cached.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is cached; otherwise, <c>false</c>.
        /// </value>
        public bool IsCached { get; set; }

        /// <summary>
        ///     Gets or sets the safety mode.
        /// </summary>
        /// <value>
        ///     The safety mode.
        /// </value>
        protected LazyThreadSafetyMode SafetyMode { get; set; }

        /// <summary>
        ///     Cacheds the specified safety mode.
        /// </summary>
        /// <param name="safetyMode">The safety mode.</param>
        /// <returns></returns>
        public IPropertyValueObserverBuilderWithNotifyProperyChanged<TParameter1, TResult> Cached(
            LazyThreadSafetyMode safetyMode = LazyThreadSafetyMode.None)
        {
            this.IsCached = true;
            this.SafetyMode = safetyMode;
            return this;
        }

        /// <summary>
        ///     Withes the notify propery changed.
        /// </summary>
        /// <returns></returns>
        public IPropertyValueObserverBuilderWithNotifyProperyChanged<TParameter1, TResult> WithNotifyProperyChanged()
        {
            return this;
        }
        public IPropertyValueObserverBuilderWithValueChanged<TParameter1, TResult> WithValueChanged()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns></returns>
        IPropertyValueObserverBuilder<TParameter1, TResult>
            IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilder<TParameter1, TResult>>.AutoActivate()
        {
            this.AutoActivate();
            return this;
        }

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithActionOfTResult<TParameter1, TResult> IPropertyValueObserverBuilderBase<
            IPropertyValueObserverBuilderWithActionOfTResult<TParameter1, TResult>>.AutoActivate()
        {
            this.AutoActivate();
            return this;
        }

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithAction<TParameter1, TResult> IPropertyValueObserverBuilderBase<
            IPropertyValueObserverBuilderWithAction<TParameter1, TResult>>.AutoActivate()
        {
            this.AutoActivate();
            return this;
        }

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithActionAndGetter<TParameter1, TResult> IPropertyValueObserverBuilderBase<
            IPropertyValueObserverBuilderWithActionAndGetter<TParameter1, TResult>>.AutoActivate()
        {
            this.AutoActivate();
            return this;
        }

        /// <summary>
        ///     Automatics the activate.
        /// </summary>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TParameter1, TResult>
            IPropertyValueObserverBuilderBase<
                IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TParameter1, TResult>>.AutoActivate()
        {
            this.AutoActivate();
            return this;
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyValueGetterObserver<TParameter1, TResult>
            IPropertyValueObserverBuilderWithActionOfTResult<TParameter1, TResult>.Create()
        {
            var observer = new PropertyValueGetterObserver<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.ActionOfTResult!);
            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyValueObserverWithGetter<TParameter1, TResult>
            IPropertyValueObserverBuilderWithActionAndGetter<TParameter1, TResult>.Create()
        {
            var observer = new PropertyValueObserverWithGetter<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.Action!);
            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyObserver<TParameter1, TResult> IPropertyValueObserverBuilderWithAction<TParameter1, TResult>.Create()
        {
            var observer = new PropertyObserver<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.Action!);
            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyObserverWithGetterAndFallback<TParameter1, TResult>
            IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TParameter1, TResult>.Create()
        {
            var observer = new PropertyObserverWithGetterAndFallback<TParameter1, TResult>(
                this.parameter1,
                this.propertyExpression,
                this.Action!,
                this.fallback);
            if (this.IsAutoActivate)
            {
                observer.Subscribe(this.IsSilentActivate);
            }

            return observer;
        }

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Value Property Observer Builder.
        /// </returns>
        IPropertyValueObserverBuilderWithActionOfTResult<TParameter1, TResult>
            IPropertyValueObserverBuilder<TParameter1, TResult>.WithAction(Action<TResult?> action)
        {
            this.ActionOfTResult = action;
            return this;
        }

        /// <summary>
        ///     Withes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyValueObserverBuilderWithAction<TParameter1, TResult>
            IPropertyValueObserverBuilder<TParameter1, TResult>.WithAction(Action action)
        {
            this.Action = action;
            return this;
        }

        /// <summary>
        ///     Withes the fallback.
        /// </summary>
        /// <param name="fallback">The fallback.</param>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TParameter1, TResult>
            IPropertyValueObserverBuilderWithActionAndGetter<TParameter1, TResult>.WithFallback(TResult fallback)
        {
            this.fallback = fallback;
            return this;
        }

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>The Value Property Observer Builder.</returns>
        IPropertyValueObserverBuilderWithActionAndGetter<TParameter1, TResult>
            IPropertyValueObserverBuilderWithAction<TParameter1, TResult>.WithGetter() =>
            this;

        /// <summary>
        /// Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithActionOfTResult<TParameter1, TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResult<TParameter1, TResult>>.
            WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            return this.WithGetterTaskScheduler(taskScheduler);
        }

        /// <summary>
        /// Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns></returns>
        private PropertyValueObserverBuilder<TParameter1, TResult> WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            this.TaskScheduler = taskScheduler;
            return this;
        }

        /// <summary>
        /// Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithActionAndGetter<TParameter1, TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionAndGetter<TParameter1, TResult>>.
            WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            return this.WithGetterTaskScheduler(taskScheduler);
        }

        /// <summary>
        /// Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TParameter1, TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TParameter1, TResult>>.
            WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            return this.WithGetterTaskScheduler(taskScheduler);
        }

        /// <summary>
        /// Withes the getter task scheduler.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler.</param>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithNotifyProperyChanged<TParameter1, TResult>
            IGetterTaskScheduler<IPropertyValueObserverBuilderWithNotifyProperyChanged<TParameter1, TResult>>.
            WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            return this.WithGetterTaskScheduler(taskScheduler);
        }
        IPropertyValueObserverBuilderWithValueChanged<TParameter1, TResult> IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithValueChanged<TParameter1, TResult>>.AutoActivate()
        {
            return AutoActivate();
        }
        IPropertyValueObserverBuilderWithValueChanged<TParameter1, TResult> IGetterTaskScheduler<IPropertyValueObserverBuilderWithValueChanged<TParameter1, TResult>>.WithGetterTaskScheduler(TaskScheduler taskScheduler)
        {
            return this.WithGetterTaskScheduler(taskScheduler);
        }
        IPropertyValueObserverBuilderWithValueChanged<TParameter1, TResult> IPropertyValueObserverBuilderWithValueChanged<TParameter1, TResult>.Cached(LazyThreadSafetyMode safetyMode)
        {
            throw new NotImplementedException();
        }
    }
}