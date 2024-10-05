using System.ComponentModel.DataAnnotations;

namespace Authenticator.Core.DBEntities
{
    public class ActivatorMenuMaster
    {
        [Key]
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int ParentId { get; set; }
        public string MenuApiUrl { get; set; }
    }
}
