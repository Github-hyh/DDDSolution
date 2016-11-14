using DDD.Infrastructure.LamdaFilterConvert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.LamdaFilterConvert
{
    public static class WhereLamdaConverter
    {
        private class ParameterReplacer : ExpressionVisitor
        {
            public ParameterExpression ParameterExpression { get; private set; }

            public ParameterReplacer(ParameterExpression paramExp)
            {
                this.ParameterExpression = paramExp;
            }

            public Expression Replace(Expression exp)
            {
                return this.Visit(exp);
            }

            protected override Expression VisitParameter(ParameterExpression p)
            {
                return this.ParameterExpression;
            }
        }

        public static Expression<Func<T, bool>> True<T>()
        {
            return item => true;
        }

        public static Expression<Func<T, bool>> False<T>()
        {
            return item => false;
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expLeft, Expression<Func<T, bool>> expRight)
        {
            var candidateExpr = Expression.Parameter(typeof(T), "item");
            var parameterReplacer = new ParameterReplacer(candidateExpr);

            var left = parameterReplacer.Replace(expLeft.Body);
            var right = parameterReplacer.Replace(expRight.Body);
            var body = Expression.And(left, right);

            return Expression.Lambda<Func<T, bool>>(body, candidateExpr);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expLeft, Expression<Func<T, bool>> expRight)
        {
            var candidateExpr = Expression.Parameter(typeof(T), "item");
            var parameterReplacer = new ParameterReplacer(candidateExpr);
            var left = parameterReplacer.Replace(expLeft.Body);
            var right = parameterReplacer.Replace(expRight.Body);
            var body = Expression.Or(left, right);
            return Expression.Lambda<Func<T, bool>>(body, candidateExpr);
        }
        public static Expression<Func<T, bool>> Parse<T>(string member, string logic, string matchValue)
        {
            if (string.IsNullOrEmpty(member))
            {
                throw new ArgumentNullException("member");
            }
            PropertyInfo keyProperty;
            ParameterExpression pExp;
            keyProperty = typeof(T).GetProperties().FirstOrDefault(item => item.Name.ToLower().Equals(member.Trim().ToLower()));
            pExp = Expression.Parameter(typeof(T), "p");

            if (keyProperty == null)
            {
                throw new ArgumentException("member不存在");
            }

            Expression memberExp = Expression.MakeMemberAccess(pExp, keyProperty);
            if (logic != "Contains")
            {
                bool memberIsNullableType = keyProperty.PropertyType.IsGenericType && keyProperty.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>);

                if (memberIsNullableType)
                {
                    memberExp = Expression.MakeMemberAccess(memberExp, keyProperty.PropertyType.GetProperty("Value"));
                }

                Type valueType = keyProperty.PropertyType;
                if (memberIsNullableType == true)
                {
                    valueType = valueType.GetGenericArguments().FirstOrDefault();
                }

                object value = matchValue;
                if (valueType == typeof(string) == false)
                {
                    if (valueType != null)
                        value = valueType.GetMethod("Parse", new[] { typeof(string) }).Invoke(null, new[] { value });
                }

                var valueExp = Expression.Constant(value, valueType);

                var expMethod = typeof(Expression).GetMethod(logic, new Type[] { typeof(Expression), typeof(Expression) });


                var body = expMethod.Invoke(null, new object[] { memberExp, valueExp }) as Expression;
                var lamdaexpression = Expression.Lambda(body, pExp) as Expression<Func<T, bool>>;
                return lamdaexpression;
            }
            else
            {
                MethodCallExpression body = null;
                body = Expression.Call(memberExp, typeof(string).GetMethod(logic), Expression.Constant(matchValue, typeof(string)));
                var lamdaexpression = Expression.Lambda(body, pExp) as Expression<Func<T, bool>>;
                return lamdaexpression;
            }
        }


        public static Expression<Func<T, bool>> Where<T>(List<Conditions> conditions)
        {
            Expression<Func<T, bool>> expression = null;
            if (conditions != null && conditions.Count > 0)
            {
                var firstexpression =
                    Parse<T>(conditions[0].Field, conditions[0].Operator, conditions[0].Value);
                if (conditions.Count <= 1)
                    return firstexpression;
                for (var i = 1; i < conditions.Count; i++)
                {
                    var rightexpression =
                        Parse<T>(conditions[i].Field, conditions[i].Operator, conditions[i].Value);
                    expression = conditions[i - 1].Relation.ToUpper().Equals("AND")
                        ? firstexpression.And(rightexpression)
                        : firstexpression.Or(rightexpression);
                }
            }
            return expression;
        }
    }
}
