using System;

namespace AI.M.P.Core.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
