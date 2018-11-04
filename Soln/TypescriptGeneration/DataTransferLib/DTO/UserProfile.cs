using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferLib.DTO
{
    [DTOModel]
    public class UserProfile
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime WhenGenerated { get; set; }

    }
}
