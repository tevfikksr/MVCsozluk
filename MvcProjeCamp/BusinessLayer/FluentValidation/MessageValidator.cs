using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
       public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş olamaz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("3 karakteden az olamaz");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("100 karakterden fazla olamaz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj İçeriği boş olamaz");
        }
    }
}
