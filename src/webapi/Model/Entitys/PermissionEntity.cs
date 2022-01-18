namespace miniapi_webapi.Model
{
    public class PermissionEntity
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public Guid? ParentId { get; set; }

        public DateTime GmtCreate { get; set; }

        public DateTime GmtModified { get; set; } 

        public bool IsDeleted { get; set; }

        public bool IsEnable { get; set; }

        public int OrderSort { get; set; }
    }
}
