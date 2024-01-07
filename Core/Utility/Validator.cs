using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Scheduler.Core.Utility
{
    public class ValidationRule<T>
    {
        public Expression<Func<T, bool>> Rule { get; set; }
        public string ErrorMessage { get; set; }
        public string PropertyName { get; set; }
    }

    public class ValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class Validator<T>
    {
        private readonly T _entity;
        private readonly List<ValidationRule<T>> _rules = new List<ValidationRule<T>>();

        public Validator(T entity)
        {
            _entity = entity;
        }

        public Validator<T> Required(Expression<Func<T, string>> propertySelector, string errorMessage)
        {
            var propertyName = GetPropertyName(propertySelector);

            Expression<Func<T, bool>> requiredRule = entity =>
                propertySelector.Compile()(entity) != null && !string.IsNullOrWhiteSpace(propertySelector.Compile()(entity));

            _rules.Add(new ValidationRule<T> { Rule = requiredRule, ErrorMessage = errorMessage, PropertyName = propertyName });

            return this;
        }

        public Validator<T> MustBeTrue(Expression<Func<T, bool>> condition, string errorMessage)
        {
            var propertyName = GetPropertyName(condition);
            _rules.Add(new ValidationRule<T>
            {
                Rule = condition,
                PropertyName = propertyName,
                ErrorMessage = errorMessage
            });
            return this;
        }

        public Validator<T> CustomRule(Expression<Func<T, bool>> condition, string errorMessage)
        {
            _rules.Add(new ValidationRule<T>
            {
                Rule = condition,
                ErrorMessage = errorMessage
            });
            return this;
        }

        public List<ValidationError> Validate()
        {
            var validationErrors = new List<ValidationError>();

            foreach (var rule in _rules)
            {
                var compiledRule = rule.Rule.Compile();
                if (!compiledRule(_entity))
                {
                    var errorDetails = new ValidationError
                    {
                        PropertyName = rule.PropertyName,
                        ErrorMessage = rule.ErrorMessage
                    };

                    validationErrors.Add(errorDetails);
                }
            }

            return validationErrors;
        }

        private string GetPropertyName<TProperty>(Expression<Func<T, TProperty>> propertySelector)
        {
            if (propertySelector.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }
            else if (propertySelector.Body is MethodCallExpression methodCallExpression &&
                     methodCallExpression.Object is MemberExpression methodCallMemberExpression)
            {
                return methodCallMemberExpression.Member.Name;
            }
            else if (propertySelector.Body is BinaryExpression binaryExpression)
            {
                if (binaryExpression.Left is MemberExpression me)
                {
                    if (me.Member.Name == "Length")
                    {
                        var ex = me.Expression as MemberExpression;
                        return ex.Member.Name;
                    }
                    return me.Member.Name;
                }
            }

            throw new ArgumentException("Invalid property selector expression.");
        }
    }
}
