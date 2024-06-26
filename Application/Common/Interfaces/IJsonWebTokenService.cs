﻿using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IJsonWebTokenService
    {
        Task<TokenDto> GenerateTokenAsync(string userName, string password);
    }
}
