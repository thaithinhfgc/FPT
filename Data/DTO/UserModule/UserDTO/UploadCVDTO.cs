using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO.UserModule.UserDTO
{
    public class UploadCVDTO
    {
        public IFormFile CV { get; set; }
    }

    public class UploadCVDTOValidator : AbstractValidator<UploadCVDTO>
    {
        public UploadCVDTOValidator()
        {
            RuleFor(x => x.CV).NotNull();
        }
    }
}
