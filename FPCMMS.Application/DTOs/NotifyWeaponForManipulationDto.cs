﻿namespace FPCMMS.Application.DTOs
{
    public abstract class NotifyWeaponForManipulationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }
    }
}

