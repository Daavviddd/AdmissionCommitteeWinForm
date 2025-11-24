using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdmissionCommittee.Infrostructure
{
    /// <summary>
    /// Предоставляет extension-методы для работы с data binding
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Создает двустороннюю привязку данных между свойством контрола и свойством источника данных
        /// </summary>
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
                control.Validating += (sender, e) =>
                {
                    var context = new ValidationContext(source);
                    var results = new List<ValidationResult>();

                    context.MemberName = sourceProName;

                    if (!Validator.TryValidateProperty(source.GetType().GetProperty(sourceProName)?.GetValue(source),
                        context,
                        results))
                    {
                        var error = results.FirstOrDefault()?.ErrorMessage ?? "Ошибка валидации";
                        errorProvider.SetError(control, error);
                        e.Cancel = false;
                    }
                    else
                    {
                        errorProvider.SetError(control, string.Empty);
                    }
                };

                control.TextChanged += (sender, e) =>
                {
                    errorProvider.SetError(control, string.Empty);
                };
            }
        }

        /// <summary>
        /// Извлекает имя свойства из expression tree
        /// </summary>
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
