﻿namespace LinkDev.Talabat.Core.Domain.Common
{
	public abstract class BaseEntity<TKey> where TKey : IEquatable<TKey>
	{
        public required TKey Id { get; set; }
        
        public required string CreatedBy { get; set; }
        public required string LastModifiedBy { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedOn { get; set; }
    }
}	
