using System;
using RulesEngine.Actions;

namespace RuleEnginePOCPublicContracts.Extensions
{
    public static class ActionContextExtensions
    {
        public static TSource GetValueOrFallback<TSource>(this ActionContext context, string contextKey, TSource fallback)
        {
            TSource contextValue;

            try
            {
                contextValue = context.GetContext<TSource>(contextKey);
            }
            catch (Exception ex)
            {
                return fallback;
            }

            return contextValue;
        }
    }
}