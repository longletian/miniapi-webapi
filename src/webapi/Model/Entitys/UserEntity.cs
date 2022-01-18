namespace miniapi_webapi.Model.Entitys
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }
        
        public string? NickName { get; set; }

        public DateTime GmtCreate { get; set; }

        public DateTime GmtModified { get; set; }

        public bool IsDeleted { get; set; }

        public int OrderSort { get; set; }
    }
}
