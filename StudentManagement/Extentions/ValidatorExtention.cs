using FluentValidation;
using StudentManagement.Common;
using StudentManagement.DataAccess.Interfaces;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Extentions
{
    public static class ValidatorExtention
    {
        public static IRuleBuilderOptionsConditions<T, string> IsCapitalizeFirstLetter<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Custom((sequence, context) => {
                var firstLetter = sequence.Trim().Substring(0, 1);

                if (firstLetter != firstLetter.ToUpper())
                    {
                        context.AddFailure("Chữ cái đầu viết hoa");
                    }
                });
        }
        public static IRuleBuilderOptions<T, TElement> IsExistId<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder, IRepository<T, TElement> repository) where T : class
        {
            return ruleBuilder.SetValidator(new CustomValidator<T, TElement>(repository)); ;
        }
    }
}
