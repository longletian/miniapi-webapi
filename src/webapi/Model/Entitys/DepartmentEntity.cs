﻿using System.Collections.Generic;

namespace miniapi_webapi.Model.Entitys
{
    [Table("t_department")]
    public class DepartmentEntity
    {
        public DepartmentEntity()
        {
            UserEntities = new List<UserEntity>();
        }

        public Guid  Id { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 部门编号
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// 部门负责人
        /// </summary>
        public string? Manager { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string? ContactNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 父级部门ID
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? GmtCreate { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        public int IsDeleted { get; set; }

        /// <summary>
        /// 包含用户
        /// </summary>
        public virtual ICollection<UserEntity> UserEntities { get; set; }
    }
}
