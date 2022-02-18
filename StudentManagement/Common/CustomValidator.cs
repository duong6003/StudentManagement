using FluentValidation;
using FluentValidation.Validators;
using StudentManagement.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Common
{
    public class CustomValidator<T, TCollectionElement> : PropertyValidator<T, TCollectionElement> where T: class
    {
        private readonly IRepository<T, TCollectionElement> _repository;

        public CustomValidator(IRepository<T, TCollectionElement> repository)
        {
            _repository = repository;
        }

        public override string Name => "CustomValidator";

        public override bool IsValid(ValidationContext<T> context, TCollectionElement value)
        {
            if (_repository.FindById(value) is null)
            {
                return false;
            }
            else return true;
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
            => "{PropertyName} must contain fewer than {MaxElements} items.";
    }
}
