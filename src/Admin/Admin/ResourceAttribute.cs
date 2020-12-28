using System;

namespace IssueManage.Pages
{
    /// <summary>
    /// 为组件指定资源名
    /// </summary>
    public class ResourceAttribute : Attribute
    {
        /// <summary>
        /// 资源名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 资源Id
        /// </summary>
        public string Id { get; set; }

        public ResourceAttribute(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
