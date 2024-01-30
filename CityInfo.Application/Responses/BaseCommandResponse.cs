﻿using System.Collections.Generic;

namespace CityInfo.Application.Responses
{
    public abstract class BaseCommandResponse
    {
        public int Id { get; set; }

        public bool Success { get; set; } = true;

        public string? Message { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
    }
}
