using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdmissionCommittee.Infrostructure
{
    public static class Extension
    {
        public static void AddBinding<TControl, TSourse>(this TControl control,
            Expression<Func<TControl, object>> destinationProperty,
            TSourse source,
            Expression<Func<TSourse, object>> sourceProperty,
            ErrorProvider? errorProvider = null)
            where TControl : Control
            where TSourse : class
        {
            var destProName = GetPropertyName(destinationProperty);
            var sourceProName = GetPropertyName(sourceProperty);
            var binding = new Binding(destProName, source, sourceProName, true);
            control.DataBindings.Add(binding);

            if (errorProvider != null)
            {
                var context = new ValidationContext(source);
                var results = new List<ValidationResult>();
                if (!Validator.TryValidateObject(source, context, results, true))
                {
                    var propError = results.FirstOrDefault(x => x.MemberNames.Contains(sourceProName));
                    if (propError != null)
                    {
                        errorProvider.SetError(control, "error");
                    }
                }
                else
                {
                    errorProvider.SetError(control, string.Empty);
                }
            }
        }

        static string GetPropertyName<TType>(Expression<Func<TType, object>> expression)
        {
            Expression body = expression.Body;
            if (body.NodeType == ExpressionType.Convert)
            {
                body = ((UnaryExpression)body).Operand;
            }

            if (body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            throw new ArgumentException("Invalid expression");
        }
    }
}
