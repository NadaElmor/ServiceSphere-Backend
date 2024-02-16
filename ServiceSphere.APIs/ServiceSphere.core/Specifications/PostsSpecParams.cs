using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSphere.core.Specifications
{
    public class PostsSpecParams
    {
        public string? sort { get; set; }
        public int? CategoryId { get; set; }

        /*private int pageSize = 5;//default value l2ny kda kda h apply pagination

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > 10 ? 10 : value; }
        }
        public int PageIndex { get; set; } = 1;*/
    }
}
