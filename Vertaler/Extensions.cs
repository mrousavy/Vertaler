using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Vertaler
{
    public static class Extensions
    {
        public static bool Set<T>(this PropertyChangedEventHandler handler, ref T field, T value,
            Expression<Func<T>> memberExpression)
        {
            if (memberExpression == null) throw new ArgumentNullException(nameof(memberExpression));

            if (!(memberExpression.Body is MemberExpression body))
                throw new ArgumentException("Lambda must return a property.");
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            if (body.Expression is ConstantExpression vmExpression)
            {
                var lambda = Expression.Lambda(vmExpression);
                var vmFunc = lambda.Compile();
                var sender = vmFunc.DynamicInvoke();

                handler?.Invoke(sender, new PropertyChangedEventArgs(body.Member.Name));
            }

            field = value;
            return true;
        }
    }
}